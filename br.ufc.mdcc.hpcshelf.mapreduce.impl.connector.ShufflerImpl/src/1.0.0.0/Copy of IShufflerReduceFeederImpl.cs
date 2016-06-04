using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Shuffler;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using System.Collections.Generic;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using System.Diagnostics;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.ShufflerImpl
{
	public class IShufflerReduceFeederImpl<OMK, OMV> : BaseIShufflerReduceFeederImpl<OMK, OMV>, IShufflerReduceFeeder<OMK, OMV>
		where OMK:IData
		where OMV:IData
	{
		static private int TAG_SHUFFLE_OMV = 345;
		static private int TAG_SHUFFLE_OMV_FINISH = 347;

		public override void main()
		{
			IIteratorInstance<IKVPair<OMK,IIterator<OMV>>> output_instance = (IIteratorInstance<IKVPair<OMK,IIterator<OMV>>>) Output.Instance;
			Feed_pairs.Server = output_instance;

			// DETERMINE COMMUNICATION SOURCEs
			IDictionary<int,Tuple<int,int>> unit_ref = new Dictionary<int, Tuple<int,int>> ();
			int nf = this.FacetMultiplicity [FACET_MAP];
			int senders_size = 1;
			foreach (int i in this.FacetIndexes[FACET_MAP]) 
			{   
				int nr0 = senders_size;
				senders_size += this.UnitSizeInFacet [i] ["map_collector"];
				for (int k=0, j=nr0; j < senders_size; k++, j++) 
					unit_ref [j] = new Tuple<int,int> (i/*,0 INDEX OF map_collector*/,k);
			}


			while (true)   // next iteration
			{
				IDictionary<object,IIteratorInstance<OMV>> kv_cache = new Dictionary<object,IIteratorInstance<OMV>> ();

				bool[] finished_stream = new bool[senders_size];
				for (int i = 0; i < senders_size; i++)
					finished_stream [i] = false;

				int count_finished_streams = 0;

				while (count_finished_streams < senders_size)     // take next chunk ... 
				{  
					// PERFORM
					for (int i = 0; i < senders_size; i++) 
						if (!finished_stream[i])
						{
							IList<IKVPairInstance<OMK,OMV>> buffer;
							CompletedStatus status;
							Shuffler_channel.Receive (unit_ref[i], MPI.Communicator.anyTag, out buffer, out status);
							foreach (IKVPairInstance<OMK,OMV> kv in buffer)
							{	
								IIteratorInstance<OMV> iterator = null;
								if (!kv_cache.ContainsKey (kv.Key)) 
								{
									iterator = Value_factory.newIteratorInstance ();
									kv_cache.Add (kv.Key, iterator);
									IKVPairInstance<OMK,IIterator<OMV>> item = (IKVPairInstance<OMK,IIterator<OMV>>)Output.createItem ();
									item.Key = kv.Key;
									item.Value = iterator;
									output_instance.put (item);
								} 
								else 
									kv_cache.TryGetValue (kv.Key, out iterator);

								iterator.put (kv.Value);
							}

							if (status.Tag == TAG_SHUFFLE_OMV_FINISH) 
							{
								count_finished_streams++;
								finished_stream [i] = true;
							}

							output_instance.finish ();

						}	
					
					// CHUNK_READY
					Task_port_shuffle.invoke (ITaskPortAdvance.CHUNK_READY);
				}

				foreach (IIteratorInstance<OMV> iterator in kv_cache.Values) 
					iterator.finish ();

			}
		}
	}
}
