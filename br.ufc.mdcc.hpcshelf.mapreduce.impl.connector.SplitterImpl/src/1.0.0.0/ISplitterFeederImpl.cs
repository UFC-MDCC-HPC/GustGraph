using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using System.Collections.Generic;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.common.Data;
using System.Diagnostics;
using System.Threading;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.ChunkReadyActionType;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.PerformActionType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.SplitterImpl
{
	public class ISplitterFeederImpl<IKey, IValue>: BaseISplitterFeederImpl<IKey, IValue>, ISplitterFeeder<IKey, IValue>
		where IKey:IData
		where IValue:IData
	{
		static private int TAG_SPLIT_NEW_CHUNK = 246;
		static private int TAG_SPLIT_END_CHUNK = 247;

		private IIteratorInstance<IKVPair<IKey,IValue>> output_instance = null;

		public override void main()
		{
			// Feed_pairs.TraceFlag = true; Split_channel.TraceFlag = true; Task_binding_split_perform.TraceFlag = true; Task_binding_split_chunk_ready.TraceFlag = true;

			output_instance = (IIteratorInstance<IKVPair<IKey,IValue>>)Output.Instance;
			Feed_pairs.Server = output_instance;

			IDictionary<int,Tuple<int,int>> unit_ref = new Dictionary<int, Tuple<int,int>> ();
			// RECEIVE PAIRS FROM THE REDUCERS (next iterations)
			int senders_size = 0;
			foreach (int i in this.FacetIndexes[FACET_COLLECT]) 
			{   
				int nr0 = senders_size;
				senders_size += this.UnitSizeInFacet [i] ["collector"];
				for (int k = 0, j = nr0; j < senders_size; k++, j++)
					unit_ref [j] = new Tuple<int,int> (i, k);
			}				
				
            Console.WriteLine ("<{0},{1}>: ISplitterFeeder : ENTER LOOP", this.Rank, this.ThisFacetInstance);

			CompletedStatus status;

			bool end_computation = false;
			while (!end_computation)
			{
				end_computation = true;

				Console.WriteLine ("<{0},{1}>: ISplitterFeeder : TRY READ CHUNK !", this.Rank, this.ThisFacetInstance);

				IList<int> inactive_senders = new List<int>();
				IList<int> active_senders = new List<int>();
				for (int i = 0; i < senders_size; i++)
					active_senders.Add (i);

				bool has_chunk = false;
				while (active_senders.Count > 0) 
				{
					IActionFuture sync_perform;

					Task_binding_split_perform.invoke (PERFORM.name, out sync_perform);

					Console.WriteLine ("<{0},{1}>: ISplitterFeeder : PERFORM started !",this.Rank, this.ThisFacetInstance);

					foreach (int i in active_senders) 
					{					
                        Console.WriteLine ("<{0},{1}>: ISplitterFeeder : BEGIN RECEIVE FROM SENDER <{2},{3}> !",this.Rank, this.ThisFacetInstance, unit_ref[i].Item1, unit_ref[i].Item2);

						IList<IKVPairInstance<IKey,IValue>> buffer;

						Split_channel.Receive (unit_ref[i], MPI.Communicator.anyTag, out buffer, out status);

						// In practice, it is expected that all senders send TAG_SPLIT_END_CHUNK in the same (last) iteration.
						if (status.Tag == TAG_SPLIT_END_CHUNK)
							inactive_senders.Add(i);
						else
							has_chunk = true;

						foreach (IKVPairInstance<IKey,IValue> kv in buffer)
							output_instance.put (kv);
						
						Console.WriteLine ("<{0},{1}>: ISplitterFeeder : END RECEIVE FROM SENDER {2} !",this.Rank, this.ThisFacetInstance, i);
					}

					if (has_chunk)
						end_computation = false;


					foreach (int i in inactive_senders)
						active_senders.Remove (i);

					Console.WriteLine ("<{0},{1}>: ISplitterFeeder : FINISH CHUNK !",this.Rank, this.ThisFacetInstance);

					output_instance.finish ();

					sync_perform.wait ();

					// CHUNK_READY
					Task_binding_split_chunk_ready.invoke (CHUNK_READY.name);
				}
			}
			Console.WriteLine ("<{0},{1}>: ISplitterFeeder : END !",this.Rank, this.ThisFacetInstance);
		}
	}
}
