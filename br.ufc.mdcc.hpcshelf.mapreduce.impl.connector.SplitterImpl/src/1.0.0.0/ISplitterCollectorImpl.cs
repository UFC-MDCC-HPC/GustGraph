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
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.ReadChunkActionType;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.PerformActionType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.SplitterImpl
{
	public class ISplitterCollectorImpl<IKey, IValue, BF> : BaseISplitterCollectorImpl<IKey, IValue, BF>, ISplitterCollector<IKey, IValue, BF>
		where IKey:IData
		where IValue:IData
		where BF:IPartitionFunction<IKey>
	{
		static private int TAG_SPLIT_NEW_CHUNK = 246;
		static private int TAG_SPLIT_EOS_CHUNK = 247;

		private static int CHUNK_SIZE = 50;

		public override void main()
		{
			//Collect_pairs.TraceFlag = true;	Split_channel.TraceFlag = true;	Task_binding_split_perform.TraceFlag = true; Task_binding_split_read_chunk.TraceFlag = true;

			IIteratorInstance<IKVPair<IKey,IValue>> input_instance = (IIteratorInstance<IKVPair<IKey,IValue>>) Collect_pairs.Client;

			object bin_object = null;

			IDictionary<int,Tuple<int,int>> unit_ref = new Dictionary<int, Tuple<int,int>> ();
			int m_size = 0;
			foreach (int i in this.FacetIndexes[FACET_FEED]) 
			{   
				int nr0 = m_size;
				m_size += this.UnitSizeInFacet [i] ["feeder"];
				for (int k = 0, j = nr0; j < m_size; k++, j++)
					unit_ref [j] = new Tuple<int,int> (i, k);
			}
				
			Bin_function.NumberOfPartitions = m_size;

			IActionFuture sync_perform;

			Console.WriteLine ("{0}: ISplitterCollector : ENTER LOOP", this.Rank);

			bool end_computation = false;
			while (!end_computation) // new iteration
			{    
				end_computation = true;
	
				bool end_iteration = false;
				while (!end_iteration) // take next chunk ...
				{  
					Console.WriteLine ("{0}: ISplitterCollector : TRY READ CHUNK !", this.Rank);

					Task_binding_split_read_chunk.invoke (READ_CHUNK.name);
					Task_binding_split_perform.invoke (PERFORM.name, out sync_perform);

					Console.WriteLine ("{0}: ISplitterCollector : PERFORM started !", this.Rank);	

					IList<IKVPairInstance<IKey,IValue>>[] buffer = new IList<IKVPairInstance<IKey,IValue>>[m_size];
					for (int i = 0; i < m_size; i++)
						buffer [i] = new List<IKVPairInstance<IKey,IValue>> ();

					if (!input_instance.has_next ())
						end_iteration = true;
					else
						end_computation = false;

					Console.WriteLine ("{0}: ISplitterCollector : START READING CHUNK ! {1}", this.Rank, end_iteration);

					int count = 0;
					while (input_instance.fetch_next (out bin_object)) 
					{
						//Console.WriteLine ("{0}: ISplitterCollector : CHUNK {1}!", this.Rank, count);
						IKVPairInstance<IKey,IValue> item = (IKVPairInstance<IKey,IValue>)bin_object;
						this.Input_key.Instance = item.Key;
						Bin_function.go ();
						int index = ((IIntegerInstance)this.Output_key.Instance).Value;
						buffer [index].Add (item);
						count++;
					}
						
					// SEND REMAINING PAIRS AND CLOSES THE CHUNK LIST
					for (int i = 0; i < m_size; i++) 
						Split_channel.Send (buffer [i], unit_ref [i], end_iteration ? TAG_SPLIT_EOS_CHUNK : TAG_SPLIT_NEW_CHUNK);

					sync_perform.wait ();
				}
			}

			Console.WriteLine ("{0}: ISplitterReduceCollector END COMPUTATION ", this.Rank);

			input_instance.finish ();
		}
			
	}
}
