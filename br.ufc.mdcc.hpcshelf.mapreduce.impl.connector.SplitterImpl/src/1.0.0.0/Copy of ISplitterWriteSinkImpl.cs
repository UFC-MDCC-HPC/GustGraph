using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingData;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using System.Collections.Generic;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using System.Diagnostics;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.SplitterImpl
{
	public class ISplitterWriteSinkImpl/*<ORK,ORV>*/ : BaseISplitterWriteSinkImpl/*<ORK,ORV>*/, ISplitterWriteSink/*<ORK,ORV>*/
		//where ORK:IData
		//where ORV:IData
	{
		static private int TAG_SPLIT_PAIR = 246;
		static private int TAG_SPLIT_PAIR_FINISH = 247;

		public override void main()
		{
			IPortTypeIterator output_instance = (IPortTypeIterator) Sink.Client;

			Task_port_data.invoke (ITaskPortData.WRITE_SINK);
			Sink.startWriteSink ();

			// RECEIVE PAIRS FROM THE REDUCERS (next iterations)
			IDictionary<int,Tuple<int,int>> unit_ref = new Dictionary<int, Tuple<int,int>> ();
			unit_ref = new Dictionary<int, Tuple<int,int>> ();
			int senders_size = 0;
			foreach (int i in this.FacetIndexes[FACET_REDUCE]) 
			{   
				int nr0 = senders_size;
				senders_size += this.UnitSizeInFacet [i] ["reduce_collector"];
				for (int k=0, j=nr0; j < senders_size; k++, j++) 
					unit_ref [j] = new Tuple<int,int> (i/*,0 INDEX OF reduce_collector*/,k);
			}				
			receive_pairs_iteration (output_instance, senders_size, unit_ref);
		}

		private void receive_pairs_iteration(IPortTypeIterator output_instance, int senders_size, IDictionary<int,Tuple<int,int>> unit_ref)
		{
			while (true)    // next iteration
			{
				int count_finished_streams = 0;
				while (count_finished_streams == 0)     // take next chunk ... 
				{  
					// PERFORM
					for (int i = 0; i < senders_size; i++) 
					{
						IList<object /*IKVPairInstance<ORK,ORV>*/> buffer;
						CompletedStatus status;
						Split_channel.Receive (unit_ref [i], MPI.Communicator.anyTag, out buffer, out status);
						foreach (object /*IKVPairInstance<ORK,ORV>*/ kv in buffer)
							output_instance.put (kv);
						if (status.Tag == TAG_SPLIT_PAIR_FINISH)
							count_finished_streams++;
					}	
					output_instance.finish ();

					Debug.Assert (count_finished_streams == 0 || count_finished_streams == senders_size);

					// CHUNK_READY
					Task_port_split.invoke (ITaskPortAdvance.CHUNK_READY);
				}

				// send empty iterator to inform the mappers the end of the iteration ...
				output_instance.finish ();

			}
		}
			}
}
