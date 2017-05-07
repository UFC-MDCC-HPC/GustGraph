using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using mapreduce.gust.tc3.System;
using br.ufc.mdcc.hpcshelf.mapreduce.computation.Mapper;
using System.Threading;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Shuffler;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.hpcshelf.platform.maintainer.ComputeHost;

namespace mapreduce.gust.tc3.SystemImpl
{
	public class IPeer1Impl : br.ufc.pargo.hpe.kinds.Application, IPeer_1
	{
		private void Go(Object o) {
			((Activate)(o)).go();
		}

		public override void main()
		{
//			IMapper<IComputeHost, IInteger, IString, IString, IInteger, IWordCounter> mapper = ((IMapper<IComputeHost, IInteger, IString, IString, IInteger, IWordCounter>)(this.Services.getPort("mapper")));
//			Thread go_mapper = new Thread(new ParameterizedThreadStart(this.Go));
//			go_mapper.Start(mapper);
//			ISplitterFeeder<IInteger, IString> splitter_input = (ISplitterFeeder<IInteger, IString>)(this.Services.getPort("splitter_input"));
//			Thread go_splitter_input = new Thread(new ParameterizedThreadStart(this.Go));
//			go_splitter_input.Start(splitter_input);
//			IShufflerCollector<IString, IInteger, IPartitionFunction<IString>> shuffler = ((IShufflerCollector<IString, IInteger, IPartitionFunction<IString>>)(this.Services.getPort("shuffler")));
//			Thread go_shuffler = new Thread(new ParameterizedThreadStart(this.Go));
//			go_shuffler.Start(shuffler);
//			go_mapper.Join();
//			go_splitter_input.Join();
//			go_shuffler.Join();
//
//			Console.WriteLine ("FINISH PEER 1");
//			AutoResetEvent e = new AutoResetEvent (false);
//			e.WaitOne ();
		}
	}
}
