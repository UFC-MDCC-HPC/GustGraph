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
using br.ufc.mdcc.hpcshelf.platform.Maintainer;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeData;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvance;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.SplitterImpl
{
	public class ISplitterMapFeederImpl<M1,IKey, IValue>: BaseISplitterMapFeederImpl<M1,IKey, IValue>, ISplitterMapFeeder<M1,IKey, IValue>
		where M1:IMaintainer
		where IKey:IData
		where IValue:IData
	{
		static private int TAG_SPLIT_NEW_CHUNK = 246;
		static private int TAG_SPLIT_END_CHUNK = 247;

		private IIteratorInstance<IKVPair<IKey,IValue>> output_instance = null;

		public override void main()
		{
			output_instance = (IIteratorInstance<IKVPair<IKey,IValue>>)Output.Instance;
			Feed_pairs.Server = output_instance;

			// RECEIVE PAIR FROM THE SOURCE (1st iteration)
			Tuple<int,int> unit_ref_source = new Tuple<int,int> (this.FacetIndexes[FACET_SOURCE][0],0);

			IDictionary<int,Tuple<int,int>> unit_ref = new Dictionary<int, Tuple<int,int>> ();
			// RECEIVE PAIRS FROM THE REDUCERS (next iterations)
			int senders_size = 0;
			foreach (int i in this.FacetIndexes[FACET_REDUCE]) 
			{   
				int nr0 = senders_size;
				senders_size += this.UnitSizeInFacet [i] ["reduce_collector"];
				for (int k=0, j=nr0; j < senders_size; k++, j++) 
					unit_ref[j] = new Tuple<int,int> (i,k);
			}
				

			IList<IKVPairInstance<IKey,IValue>> buffer;
			object buffer_obj;

			CompletedStatus status;

			bool end_computation = false;
			while (!end_computation)
			{
				end_computation = true;
				int count_finished_streams = 0;

				while (count_finished_streams < senders_size) 
				{
					IActionFuture sync_perform;

					Task_binding_split_next.invoke (ITaskPortAdvance.READ_CHUNK);
					Task_binding_split_next.invoke (ITaskPortAdvance.PERFORM, out sync_perform);

					for (int i = 0; i < senders_size; i++) 
					{					
						Split_channel.Receive (unit_ref[i], MPI.Communicator.anyTag, out buffer_obj, out status);

						if (status.Tag == TAG_SPLIT_END_CHUNK)
							count_finished_streams++;
						else
							end_computation = false;
						
						try 
						{
							buffer = (IList<IKVPairInstance<IKey,IValue>>) buffer_obj;

							foreach (IKVPairInstance<IKey,IValue> kv in buffer)
								output_instance.put (kv);
						}
						catch (InvalidCastException e) 
						{
							count_finished_streams++;
						}
					}

					output_instance.finish ();

					sync_perform.wait ();

					// CHUNK_READY
					Task_binding_split_next.invoke (ITaskPortAdvance.CHUNK_READY);
				}
			}

			Task_binding_data.invoke (ITaskPortData.TERMINATE);
			Task_binding_data.invoke (ITaskPortData.WRITE_SINK);
		}
	}
}
