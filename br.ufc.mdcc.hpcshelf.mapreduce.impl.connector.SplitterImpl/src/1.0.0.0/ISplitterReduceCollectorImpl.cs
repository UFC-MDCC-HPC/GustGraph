using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using System.Collections.Generic;
using br.ufc.mdcc.common.Integer;
using System.Threading;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.TerminateFunction;
using br.ufc.mdcc.hpcshelf.platform.Maintainer;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvance;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.SplitterImpl
{
	public class ISplitterReduceCollectorImpl<M0,IKey, IValue, OKey, OValue, BF, TF> : BaseISplitterReduceCollectorImpl<M0,IKey, IValue, OKey, OValue, BF, TF>, ISplitterReduceCollector<M0,IKey, IValue, OKey, OValue, BF, TF>
		where M0:IMaintainer
		where IKey:IData
		where IValue:IData
		where OKey:IData
		where OValue:IData
		where BF:IPartitionFunction<IKey>
		where TF:ITerminateFunction<IKey,IValue,OKey,OValue>
	{
		static private int TAG_SPLIT_NEW_CHUNK = 246;
		static private int TAG_SPLIT_END_CHUNK = 247;
		static private int TAG_SPLIT_END_COMPUTATION = 247;

		private void terminate_go()
		{
			Terminate_function.go ();
		}

		public override void main()
		{


			IIteratorInstance<IKVPair<IKey,IValue>> input_instance = (IIteratorInstance<IKVPair<IKey,IValue>>) Input_pairs.Instance;

			object bin_object = null;

			IDictionary<int,Tuple<int,int>> unit_ref = new Dictionary<int, Tuple<int,int>> ();
			int m_size = 0;
			foreach (int i in this.FacetIndexes[FACET_MAP]) 
			{   
				int nr0 = m_size;
				m_size += this.UnitSizeInFacet [i] ["map_feeder"];
				for (int k = 0, j = nr0; j < m_size; k++, j++)
					unit_ref [j] = new Tuple<int,int> (i/*,0 index of MAP_FEEDER*/, k);
			}
				
			IActionFuture sync_perform;

			bool end_iteration = false;
			while (!end_iteration) // new iteration
			{    
				end_iteration = true;

				// SEND BACK TO MAPPER (new iteration)

				Bin_function_iterate.NumberOfPartitions = m_size;

				IList<IKVPairInstance<OKey,OValue>>[] buffer = new IList<IKVPairInstance<OKey,OValue>>[m_size];
				for (int i = 0; i < m_size; i++)
					buffer [i] = new List<IKVPairInstance<OKey,OValue>> ();

				end_iteration = !input_instance.has_next();

				Task_binding_split_next.invoke (ITaskPortAdvance.READ_CHUNK);
				Task_binding_split_next.invoke (ITaskPortAdvance.PERFORM, out sync_perform);

				int count = 0;
				while (input_instance.fetch_next (out bin_object)) 
				{
					IKVPairInstance<OKey,OValue> item = (IKVPairInstance<OKey,OValue>)bin_object;

					this.Input_key_iterate.Instance = item.Key;
					Bin_function_iterate.go ();
					int index = ((IIntegerInstance)this.Output_key_iterate.Instance).Value;

					buffer [index].Add (item);

					count++;
				}

				for (int i = 0; i < m_size; i++) 
				{
					Split_channel.Send (buffer [i], unit_ref [i], TAG_SPLIT_NEW_CHUNK);
					buffer [i].Clear();
				}

				sync_perform.wait ();

				Task_binding_split_next.invoke (ITaskPortAdvance.CHUNK_READY);

				Task_binding_split_next.invoke (ITaskPortAdvance.READ_CHUNK);
				Task_binding_split_next.invoke (ITaskPortAdvance.PERFORM, out sync_perform);

				// SEND REMAINING PAIRS AND CLOSES THE CHUNK LIST
				for (int i = 0; i < m_size; i++) 
					Split_channel.Send (buffer [i], unit_ref [i], TAG_SPLIT_END_CHUNK);

				sync_perform.wait ();

				Task_binding_split_next.invoke (ITaskPortAdvance.CHUNK_READY);
			}

			Console.WriteLine (this.Rank + ": ISplitterReduceCollector END COMPUTATION ");

			input_instance.finish ();
		}
			
	}
}
