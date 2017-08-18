using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Shuffler;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using System.Collections.Generic;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using System.Diagnostics;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.PerformActionType;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.ChunkReadyActionType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.ShufflerImpl
{
	public class IShufflerFeederImpl<TKey, TValue> : BaseIShufflerFeederImpl<TKey, TValue>, IShufflerFeeder<TKey, TValue>
		where TKey:IData
		where TValue:IData
	{
		static private int TAG_SHUFFLE_NEW_CHUNK = 345;
		static private int TAG_SHUFFLE_END_CHUNK = 347;

		public override void main()
		{
			// Feed_pairs.TraceFlag = true; Shuffler_channel.TraceFlag = true;	Task_binding_shuffle_perform.TraceFlag = true;	Task_binding_shuffle_chunk_ready.TraceFlag = true;

			IIteratorInstance<IKVPair<TKey,IIterator<TValue>>> output_instance = (IIteratorInstance<IKVPair<TKey,IIterator<TValue>>>) Output.Instance;
			Feed_pairs.Server = output_instance;

			// DETERMINE COMMUNICATION SOURCEs
			IDictionary<int,Tuple<int,int>> unit_ref = new Dictionary<int, Tuple<int,int>> ();
			int nf = this.FacetMultiplicity [FACET_COLLECT];
			int senders_size = 0;
			foreach (int i in this.FacetIndexes[FACET_COLLECT]) 
			{   
				int nr0 = senders_size;
				senders_size += this.UnitSizeInFacet [i] ["collector"];
				for (int k = 0, j = nr0; j < senders_size; k++, j++)
					unit_ref [j] = new Tuple<int,int> (i, k);
			}

			bool end_computation = false;
			while (!end_computation)   // next iteration
			{
				Console.WriteLine ("{1}-{0}: IShufflerFeeder - ENTER ITERATION", this.Rank, this.CID);

				IList<int> inactive_senders = new List<int>();
				IList<int> active_senders = new List<int>();
				for (int i = 0; i < senders_size; i++)
					active_senders.Add (i);

				end_computation = true;

				bool has_chunk = false;
				while (active_senders.Count > 0)     // take next chunk ... 
				{  
					Console.WriteLine ("{1}-{0}: IShufflerFeeder - ENTER READ CHUNK", this.Rank, this.CID);

					IActionFuture sync_perform;

					Task_binding_shuffle_perform.invoke (PERFORM.name, out sync_perform);

					IDictionary<object,IIteratorInstance<TValue>> kv_cache = new Dictionary<object,IIteratorInstance<TValue>> ();

					// PERFORM
					foreach (int i in active_senders) 
					{
						Console.WriteLine ("{1}-{0}: IShufflerFeeder - RECEIVE CHUNK FROM {2}", this.Rank, this.CID, i);

						IList<IKVPairInstance<TKey,TValue>> buffer;
						CompletedStatus status;

						Shuffler_channel.Receive (unit_ref[i], MPI.Communicator.anyTag, out buffer, out status);

						// In practice, it is expected that all senders send TAG_SPLIT_END_CHUNK in the same (last) iteration.
						if (status.Tag == TAG_SHUFFLE_END_CHUNK) 
							inactive_senders.Add(i);
						else
							has_chunk = true;

						int count = 0;
						foreach (IKVPairInstance<TKey,TValue> kv in buffer)
						{	
							IIteratorInstance<TValue> iterator = null;
							if (!kv_cache.ContainsKey (kv.Key)) 
							{
								iterator = Value_factory.newIteratorInstance ();
								kv_cache.Add (kv.Key, iterator);
								IKVPairInstance<TKey,IIterator<TValue>> item = (IKVPairInstance<TKey,IIterator<TValue>>)Output.createItem ();
								item.Key = kv.Key;
								item.Value = iterator;
								output_instance.put (item);
							} 
							else 
								kv_cache.TryGetValue (kv.Key, out iterator);

							iterator.put (kv.Value);
							count++;
						}

					}	

					if (has_chunk)
						end_computation = false;

					foreach (int i in inactive_senders)
						active_senders.Remove (i);
					
                    Console.WriteLine ("{1}-{0}: IShufflerFeeder - BEFORE FINISH CHUNK", this.Rank, this.CID);

					output_instance.finish ();

					if (!end_computation)
						foreach (IIteratorInstance<TValue> iterator in kv_cache.Values) 
							iterator.finish ();

					sync_perform.wait ();

					Console.WriteLine ("{1}-{0}: IShufflerFeeder - AFTER PERFORM WAIT", this.Rank, this.CID);

					// CHUNK_READY
					Task_binding_shuffle_chunk_ready.invoke (CHUNK_READY.name);   //****

					Console.WriteLine ("{1}-{0}: IShufflerFeeder - AFTER CHUNK READY", this.Rank, this.CID);
				}
			}

            Console.WriteLine("{1}-{0}: IShufflerFeeder - END COMPUTATION", this.Rank, this.CID);

		}
	}
}
