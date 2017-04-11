using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBaseDirect;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeDataSinkInterface;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.environment.EnvironmentBindingWriteData;
using System.Threading;
using System.Collections.Generic;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;
using System.Collections.Concurrent;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.binding.environment.EnvironmentBindingWriteData
{
	public class IWriteDataImpl<S> : BaseIWriteDataImpl<S>, IWriteData<S>
		where S:IPortTypeIterator
	{
		private ConcurrentQueue<Tuple<string,int>> lines = new ConcurrentQueue<Tuple<string, int>>();

		public override void main()
		{	
		}

		private Thread thread_file_writer = null;

		public override void after_initialize()
		{
			client = new IPortTypeDataSinkInterfaceImpl (lines);
		}

		internal class IPortTypeDataSinkInterfaceImpl : IPortTypeDataSinkInterface
		{
			private Semaphore not_empty = new Semaphore(0,int.MaxValue);
			private S server;
			private ConcurrentQueue<Tuple<string,int>> lines;
			AutoResetEvent e = new AutoResetEvent(false);

			public S Server { set {	server = value; e.Set (); } }

			public IPortTypeDataSinkInterfaceImpl(ConcurrentQueue<Tuple<string,int>> lines)
			{
				this.e = e;
				this.lines = lines;
				this.server = server;
			}


			public ConcurrentQueue<Tuple<string,int>> readCounts ()
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

							bin = (IKVPairInstance<IString,IInteger>)bin_object;
							string s = ((IStringInstance)bin.Key).Value;
							int c = (int) bin.Value;
							
							Tuple<string, int> tt = new Tuple<string, int> (s, c);
							lines.Enqueue (tt);
							count = not_empty.Release();
						}
						Console.WriteLine("READ COUNTS - END CHUNK ");
					}
					
					Console.WriteLine("READ COUNTS - END ITERATION ");
					
					lines.Enqueue(new Tuple<string,int>(null,0));
					not_empty.Release();
				}));

				t.Start();

				return lines;
			}

			public Semaphore NotEmpty { get { return not_empty; } }
		}



		private IPortTypeDataSinkInterface client = null;
		public IPortTypeDataSinkInterface Client { get {	return client; } }

		private S server = default(S);
		public S Server { set {	server = value; ((IPortTypeDataSinkInterfaceImpl)client).Server = server; } }

	}
}
