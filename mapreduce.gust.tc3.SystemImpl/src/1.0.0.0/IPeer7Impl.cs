using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using mapreduce.gust.tc3.System;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
using System.Threading;
using br.ufc.mdcc.hpcshelf.platform.maintainer.DataHost;

namespace mapreduce.gust.tc3.SystemImpl
{
	public class IPeer7Impl : br.ufc.pargo.hpe.kinds.Application, IPeer_7
	{
		private void Go(Object o) {
			((Activate)(o)).go();
		}

		public override void main()
		{
//			IDataSink<IDataHost> sink = ((IDataSink<IDataHost>)(this.Services.getPort("sink")));
//			Thread go_sink = new Thread(new ParameterizedThreadStart(this.Go));
//			go_sink.Start(sink);
//			ISplitterFeeder<IString, IInteger> splitter_output = ((ISplitterFeeder<IString, IInteger>)(this.Services.getPort("splitter_output")));
//			Thread go_splitter_output = new Thread(new ParameterizedThreadStart(this.Go));
//			go_splitter_output.Start(splitter_output);
//			go_sink.Join();
//			go_splitter_output.Join();
//
//			Console.WriteLine ("FINISH PEER 3");
//			AutoResetEvent e = new AutoResetEvent (false);
//			e.WaitOne ();
		}
	}
}
