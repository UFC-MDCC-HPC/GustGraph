using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Shuffler;
using System.Diagnostics;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using System.Collections.Generic;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.ShufflerImpl	
{
	public class IShufflerMapCollectorImpl<OMK,OMV,PF> : BaseIShufflerMapCollectorImpl<OMK,OMV,PF>, IShufflerMapCollector<OMK,OMV,PF>
		where PF:IPartitionFunction<OMK>
		where OMK:IData
		where OMV:IData
	{
		static private int TAG_SHUFFLE_OMV = 345;
		static private int TAG_SHUFFLE_OMV_FINISH = 347;

		public override void main()
		{
			Console.WriteLine (this.GlobalRank + ": STARTING SHUFFLER ...1");
			IIteratorInstance<IKVPair<OMK,OMV>> input_instance = (IIteratorInstance<IKVPair<OMK,OMV>>) Collect_pairs.Client;
			object bin_object = null;

			IActionFuture sync_perform;

			// DETERMINE COMMMUNICATION TARGETs
			IDictionary<int,Tuple<int,int>> unit_ref = new Dictionary<int, Tuple<int,int>> ();
			int nf = this.FacetMultiplicity [FACET_REDUCE];
			int reduce_size = 1;
			Console.WriteLine (this.GlobalRank + ": STARTING SHUFFLER ...2");
			foreach (int i in this.FacetIndexes[FACET_REDUCE]) 
			{   
				int nr0 = reduce_size;
				Console.WriteLine (this.GlobalRank + ": STARTING SHUFFLER ...3 - BEGIN 1 - i=" + i);
				foreach (KeyValuePair<int,IDictionary<string,int>> ttt in this.UnitSizeInFacet) 
				{
					Console.WriteLine (this.GlobalRank + ": STARTING SHUFFLER ...3 - " + (ttt.Value == null));
					foreach (KeyValuePair<string,int> tttt in ttt.Value)
						Console.WriteLine (this.GlobalRank + ": STARTING SHUFFLER ...3 --- " + ttt.Key + " / " + tttt.Key + " / " + tttt.Value);
				}														 
				reduce_size += this.UnitSizeInFacet [i] ["reduce_feeder"];
				Console.WriteLine (this.GlobalRank + ": STARTING SHUFFLER ...3 - BEGIN 2 - " + i);
				for (int k=0, j=nr0; j < reduce_size; k++, j++) 
					unit_ref [j] = new Tuple<int,int> (i/*,0 INDEX OF reduce_feeder*/,k);
				Console.WriteLine (this.GlobalRank + ": STARTING SHUFFLER ...3 - END - " + i);
			}

			Partition_function.NumberOfPartitions = reduce_size;

			while (true) // next iteration
			{   
				bool end_iteration = false;
				while (!end_iteration) // take next chunk ...
				{  
					Task_port_shuffle.invoke (ITaskPortAdvance.READ_CHUNK);
					Task_port_shuffle.invoke (ITaskPortAdvance.PERFORM, out sync_perform);

					IList<IKVPairInstance<OMK,OMV>>[] buffer = new IList<IKVPairInstance<OMK,OMV>>[reduce_size];
					for (int i = 0; i < reduce_size; i++)
						buffer [i] = new List<IKVPairInstance<OMK,OMV>> ();
				
					IKVPairInstance<OMK,OMV> item = null;

					int count = 0;
					while (input_instance.fetch_next (out bin_object)) 
					{
						item = (IKVPairInstance<OMK,OMV>)bin_object;
						this.Input_key.Instance = item.Key;
						Partition_function.go ();
						int index = ((IIntegerInstance)this.Output_key.Instance).Value;
						buffer [index].Add (item);
						count++;
					}

					if (count == 0)
						end_iteration = true;

					sync_perform.wait ();

					// PERFORM
					for (int i = 0; i < reduce_size; i++)
						Shuffler_channel.Send (buffer [i], unit_ref [i], end_iteration ? TAG_SHUFFLE_OMV_FINISH : TAG_SHUFFLE_OMV);
				}			
			}		
		}
	}
}
