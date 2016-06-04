using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using System.Collections.Generic;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.common.Data;
using System.Diagnostics;
using System.Threading;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.SplitterImpl
{
	public class ISplitterMapFeederImpl<IMK, IMV>: BaseISplitterMapFeederImpl<IMK, IMV>, ISplitterMapFeeder<IMK, IMV>
		where IMK:IData
		where IMV:IData
	{
		static private int TAG_SPLIT_PAIR = 246;
		static private int TAG_SPLIT_PAIR_FINISH = 247;

		private IIteratorInstance<IKVPair<IMK,IMV>> output_instance = null;

		public override void main()
		{
			Console.WriteLine (this.GlobalRank + ": STARTING SPLITTER ...1");
			output_instance = (IIteratorInstance<IKVPair<IMK,IMV>>)Output.Instance;
			Feed_pairs.Server = output_instance;

			Console.WriteLine (this.GlobalRank + ": STARTING SPLITTER ...2");

			// RECEIVE PAIR FROM THE SOURCE (1st iteration)
			IDictionary<int,Tuple<int,int>> unit_ref = new Dictionary<int, Tuple<int,int>> ();
			unit_ref.Add (0, new Tuple<int,int> (this.FacetIndexes[FACET_SOURCE][0]/*,0 ?*/,0));

			Console.WriteLine (this.GlobalRank + ": STARTING SPLITTER ...3");
			// RECEIVE PAIRS FROM THE REDUCERS (next iterations)
			unit_ref = new Dictionary<int, Tuple<int,int>> ();
			int senders_size = 0;
			foreach (int i in this.FacetIndexes[FACET_REDUCE]) 
			{   
				Console.WriteLine (this.GlobalRank + ": STARTING SPLITTER ...4 -- i=" + i);
				int nr0 = senders_size;
				senders_size += this.UnitSizeInFacet [i] ["reduce_collector"];
				for (int k=0, j=nr0; j < senders_size; k++, j++) 
					unit_ref [j] = new Tuple<int,int> (i/*,0 INDEX OF reduce_collector*/,k);
			}

			Thread[] threads_receive = new Thread[senders_size];

			for (int i = 0; i < senders_size; i++) 
			{
				threads_receive [i] = new Thread ((ParameterizedThreadStart)delegate(object unit_ref_obj) { 
					Tuple<int,int> unit_ref_i = (Tuple<int,int>)unit_ref_obj;
					receive_pairs_iteration (unit_ref_i);
				});
			}

			for (int i = 0; i < senders_size; i++) 
				threads_receive [i].Start (unit_ref [i]);

			for (int i = 0; i < senders_size; i++) 
				threads_receive [i].Join ();
		}

		int count_finished_streams = 0;

		private Object thisLock = new Object();

		private void receive_pairs_iteration(Tuple<int,int> unit_ref)
		{
			IList<IKVPairInstance<IMK,IMV>> buffer;
			CompletedStatus status;

			Split_channel.Receive (unit_ref, MPI.Communicator.anyTag, out buffer, out status);

			lock (thisLock) 
			{
				foreach (IKVPairInstance<IMK,IMV> kv in buffer)
					output_instance.put (kv);
			
				if (status.Tag == TAG_SPLIT_PAIR_FINISH)
					count_finished_streams++;

				output_instance.finish ();

				// CHUNK_READY
				Task_port_split.invoke (ITaskPortAdvance.CHUNK_READY);
			}
		}
	}
}
