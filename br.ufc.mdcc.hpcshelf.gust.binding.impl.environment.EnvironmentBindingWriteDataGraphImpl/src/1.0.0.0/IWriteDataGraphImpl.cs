using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.gust.binding.environment.EnvironmentBindingWriteDataGraph;//
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBaseDirect;
using br.ufc.mdcc.hpcshelf.gust.port.environment.PortTypeDataSinkGraphInterface;
using System.Threading;
using System.Collections.Generic;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;
using System.Collections.Concurrent;

namespace br.ufc.mdcc.hpcshelf.gust.binding.impl.environment.EnvironmentBindingWriteDataGraphImpl
{
	public class IWriteDataGraphImpl<S>: BaseIWriteDataGraphImpl<S>, IWriteDataGraph<S>
		where S:IPortTypeIterator
	{
		private ConcurrentQueue<Tuple<object,int>> lines = new ConcurrentQueue<Tuple<object,int>>();

		public override void main()
		{
		}

		private Thread thread_file_writer = null;

		public override void after_initialize()
		{
			client = new IPortTypeDataSinkGraphInterfaceImpl (lines);
		}

		internal class IPortTypeDataSinkGraphInterfaceImpl : IPortTypeDataSinkGraphInterface
		{
			private Semaphore not_empty = new Semaphore(0,int.MaxValue);
			private S server;
			private ConcurrentQueue<Tuple<object,int>> lines;
			AutoResetEvent e = new AutoResetEvent(false);
			private int index = 0;

			public S Server { set {	server = value; e.Set (); } }

			public IPortTypeDataSinkGraphInterfaceImpl(ConcurrentQueue<Tuple<object,int>> lines)
			{
				this.e = e;
				this.lines = lines;
				this.server = server;
			}


			public ConcurrentQueue<Tuple<object,int>> readPairs ()
			{

				Thread t = new Thread(new ThreadStart(() =>
				{
					e.WaitOne();
					object bin_object = null;

					Console.WriteLine("READ COUNTS START");
					// SINGLE ITERATION (Count Words)
					bool end_iteration = false;
					while (!end_iteration)
					{
					    Console.WriteLine("READ COUNTS - ITERATION " + (server==null));
						if (!server.has_next ())
							end_iteration = true;

						int count = 0;
						IKVPairInstance<IString,IInteger> bin;
						while (server.fetch_next (out bin_object))
						{
							Console.WriteLine("READ COUNTS - READ " + count);
							//bin = (IKVPairInstance<IString,IInteger>)bin_object;
							//string s = ((IStringInstance)bin.Key).Value;
							//int c = (int) bin.Value;

							Tuple<object,int> tt = new Tuple<object,int> (bin_object, (++index));
							lines.Enqueue (tt);
							count = not_empty.Release();
						}
						Console.WriteLine("READ COUNTS - END CHUNK ");
					}

					Console.WriteLine("READ COUNTS - END ITERATION ");

					lines.Enqueue(new Tuple<object,int>(null,0));
					not_empty.Release();
				}));

				t.Start();

				return lines;
			}

			public Semaphore NotEmpty { get { return not_empty; } }
		}



		private IPortTypeDataSinkGraphInterface client = null;
		public IPortTypeDataSinkGraphInterface Client { get {	return client; } }

		private S server = default(S);
		public S Server { set {	server = value; ((IPortTypeDataSinkGraphInterfaceImpl)client).Server = server; } }

	}
}











