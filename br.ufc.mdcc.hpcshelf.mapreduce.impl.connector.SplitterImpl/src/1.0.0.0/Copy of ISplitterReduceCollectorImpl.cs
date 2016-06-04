using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using System.Collections.Generic;
using br.ufc.mdcc.common.Integer;
using System.Threading;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.SplitterImpl
{
	public class ISplitterReduceCollectorImpl<IMK, IMV, ORK, ORV, BF> : BaseISplitterReduceCollectorImpl<IMK, IMV, ORK, ORV, BF>, ISplitterReduceCollector<IMK, IMV, ORK, ORV, BF>
		where IMK:IData
		where IMV:IData
		where ORK:IData
		where ORV:IData
		where BF:IPartitionFunction<IMK>
	{
		static private int TAG_SPLIT_PAIR = 246;
		static private int TAG_SPLIT_PAIR_FINISH = 247;

		static private int CHUNK_SIZE = 10;

		private void terminate_go()
		{
			Terminate_function.go ();
		}

		public override void main()
		{
			IIteratorInstance<IKVPair<ORK,ORV>> input_instance = (IIteratorInstance<IKVPair<ORK,ORV>>) Collect_pairs.Client;
			Terminate_function.Iterate_pairs = input_instance;

			Thread thread_terminate_function = new Thread (new ThreadStart(terminate_go));
			thread_terminate_function.Start ();

			Thread thread_send_to_mappers = new Thread (new ThreadStart (send_to_mappers));
			thread_send_to_mappers.Start ();

			Thread thread_send_to_sink = new Thread (new ThreadStart (send_to_sink));
			thread_send_to_sink.Start ();

		}

		private void send_to_sink ()
		{
			IIteratorInstance<IKVPair<ORK,ORV>> input_instance = (IIteratorInstance<IKVPair<ORK,ORV>>) Output_pairs.Instance;

			object bin_object = null;

			// DETERMINE COMMUNICATION TARGETs
			Tuple<int,int> sink_ref = new Tuple<int,int> (this.FacetIndexes [FACET_SOURCE] [0], 0);
		
			IActionFuture sync_perform;

			while (true) // new iteration
			{    
				bool end_iteration = false;
				while (!end_iteration) // take next chunk
				{ 
					Task_port_split.invoke (ITaskPortAdvance.READ_CHUNK);
					Task_port_split.invoke (ITaskPortAdvance.PERFORM, out sync_perform);

					IList<IKVPairInstance<ORK,ORV>> buffer = new List<IKVPairInstance<ORK,ORV>>();

					while (input_instance.fetch_next (out bin_object)) 
					{
						IKVPairInstance<ORK,ORV> item = (IKVPairInstance<ORK,ORV>)bin_object;
						buffer.Add (item);
					}

					Split_channel.Send (buffer, sink_ref, TAG_SPLIT_PAIR);

					sync_perform.wait ();
				}
			}

			// Inform the end of the iteration
			Split_channel.Send (new List<IKVPairInstance<ORK,ORV>> (), sink_ref, TAG_SPLIT_PAIR_FINISH);		
		}

		private void send_to_mappers ()
		{
			IIteratorInstance<IKVPair<ORK,ORV>> input_instance = (IIteratorInstance<IKVPair<ORK,ORV>>) Input_pairs.Instance;

			object bin_object = null;

			// DETERMINE COMMUNICATION TARGETs
			IDictionary<int,Tuple<int,int>> unit_ref = new Dictionary<int, Tuple<int,int>> ();
			int m_size = 0;
			foreach (int i in this.FacetIndexes[FACET_MAP]) 
			{   
				int nr0 = m_size;
				m_size += this.UnitSizeInFacet [i] ["map_feeder"];
				for (int k=0, j=nr0; j < m_size; k++, j++) 
					unit_ref [j] = new Tuple<int,int> (i/*,0 index of MAP_FEEDER*/,k);
			}

			IActionFuture sync_perform;

			while (true) // new iteration
			{    
				bool end_iteration = false;
				while (!end_iteration) // take next chunk
				{ 
					Task_port_split.invoke (ITaskPortAdvance.READ_CHUNK);
					Task_port_split.invoke (ITaskPortAdvance.PERFORM, out sync_perform);

					Bin_function_iterate.NumberOfPartitions = m_size;

					IList<IKVPairInstance<ORK,ORV>>[] buffer = new IList<IKVPairInstance<ORK,ORV>>[m_size];
					for (int i = 0; i < m_size; i++)
						buffer [i] = new List<IKVPairInstance<ORK,ORV>> ();

					int count = 0;
					while (input_instance.fetch_next (out bin_object) && count < CHUNK_SIZE) 
					{
						IKVPairInstance<ORK,ORV> item = (IKVPairInstance<ORK,ORV>)bin_object;

						this.Input_key_iterate.Instance = item.Key;
						Bin_function_iterate.go ();
						int index = ((IIntegerInstance)this.Output_key_iterate.Instance).Value;

						buffer [index].Add (item);

						count++;
					}

					sync_perform.wait ();

					// PERFORM
					for (int i = 0; i < m_size; i++)
						Split_channel.Send (buffer [i], unit_ref [i], TAG_SPLIT_PAIR);

					if (count < CHUNK_SIZE)
						end_iteration = true;
				}
			}

			// Inform the end of the iteration
			for (int i = 0; i < m_size; i++)
				Split_channel.Send (new List<IKVPairInstance<ORK,ORV>> (), unit_ref [i], TAG_SPLIT_PAIR_FINISH);		
		}

	}
}
