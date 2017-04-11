using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Shuffler;
using System.Diagnostics;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using System.Collections.Generic;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.ReadChunkActionType;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.PerformActionType;
namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.ShufflerImpl	
{
	public class IShufflerCollectorImpl<TKey,TValue,PF> : BaseIShufflerCollectorImpl<TKey,TValue,PF>, IShufflerCollector<TKey,TValue,PF>
		where PF:IPartitionFunction<TKey>
		where TKey:IData
		where TValue:IData
	{
		static private int TAG_SHUFFLE_NEW_CHUNK = 345;
		static private int TAG_SHUFFLE_EOS_CHUNK = 347;

		public override void main()
		{
			//Collect_pairs.TraceFlag = true;	Shuffler_channel.TraceFlag = true;	Task_binding_shuffle_perform.TraceFlag = true; Task_binding_shuffle_read_chunk.TraceFlag = true;

			IIteratorInstance<IKVPair<TKey,TValue>> input_instance = (IIteratorInstance<IKVPair<TKey,TValue>>) Collect_pairs.Client;
			object bin_object = null;

			IActionFuture sync_perform;

			// DETERMINE COMMMUNICATION TARGETs
			IDictionary<int,Tuple<int,int>> unit_ref = new Dictionary<int, Tuple<int,int>> ();
			int nf = this.FacetMultiplicity [FACET_FEED];
			int reduce_size = 0;
			foreach (int i in this.FacetIndexes[FACET_FEED]) 
			{   
				int nr0 = reduce_size;
				reduce_size += this.UnitSizeInFacet [i] ["feeder"];
				for (int k=0, j=nr0; j < reduce_size; k++, j++) 
					unit_ref [j] = new Tuple<int,int> (i,k);
			}

			Partition_function.NumberOfPartitions = reduce_size;


			bool end_computation = false;
			while (!end_computation) // next iteration
			{   
				end_computation = true;

				Console.WriteLine ("{0}: IShufflerCollector - ENTER ITERATION", this.Rank);

				bool end_iteration = false;
				while (!end_iteration) // take next chunk ...
				{  
					Console.WriteLine ("{0}: IShufflerCollector - BEFORE READ CHUNK", this.Rank);

					Task_binding_shuffle_read_chunk.invoke (READ_CHUNK.name);
					Task_binding_shuffle_perform.invoke (PERFORM.name, out sync_perform);

					Console.WriteLine ("{0}: IShufflerCollector - AFTER PERFORM", this.Rank);

					IList<IKVPairInstance<TKey,TValue>>[] buffer = new IList<IKVPairInstance<TKey,TValue>>[reduce_size];
					for (int i = 0; i < reduce_size; i++)
						buffer [i] = new List<IKVPairInstance<TKey,TValue>> ();				

					if (!input_instance.has_next ())
						end_iteration = true;
					else
						end_computation = false;

					int count = 0;
					while (input_instance.fetch_next (out bin_object)) 
					{
						//Console.WriteLine ("{0}: IShufflerCollector - CHUNK ITEM {1}", this.Rank, count);

						IKVPairInstance<TKey,TValue> item = (IKVPairInstance<TKey,TValue>)bin_object;
						this.Input_key.Instance = item.Key;
						Partition_function.go ();
						int index = ((IIntegerInstance)this.Output_key.Instance).Value;
						buffer [index].Add (item);
						count++;
					}
						
					Console.WriteLine ("{0}: IShufflerCollector - END CHUNK", this.Rank);

					// PERFORM
					for (int i = 0; i < reduce_size; i++)
						Shuffler_channel.Send (buffer [i], unit_ref [i], end_iteration ? TAG_SHUFFLE_EOS_CHUNK : TAG_SHUFFLE_NEW_CHUNK);

					Console.WriteLine ("{0}: IShufflerCollector - AFTER SEND CHUNK", this.Rank);

					sync_perform.wait ();

					Console.WriteLine ("{0}: IShufflerCollector - AFTER PERFORM WAIT", this.Rank);
				}			
			}		
		}
	}
}
