using System;
using br.ufc.pargo.hpe.kinds;
using mapreduce.gust.tc3.System;

namespace mapreduce.gust.tc3.SystemImpl
{
    public class IPeer0Impl : br.ufc.pargo.hpe.kinds.Application, IPeer_0
	{
		private void Go(Object o) {
			((Activate)(o)).go();
		}

		public override void main()
		{
//			IDataSource<IDataHost> source = ((IDataSource<IDataHost>)(this.Services.getPort("source")));
//			Thread go_source = new Thread(new ParameterizedThreadStart(this.Go));
//            go_source.Start(source);
//            ISplitterCollector<IInteger, IString, IPartitionFunction<IInteger>> splitter_input = ((ISplitterCollector<IInteger, IString, IPartitionFunction<IInteger>>)(this.Services.getPort("splitter_input")));
//			Thread go_splitter_input = new Thread(new ParameterizedThreadStart(this.Go));
//			go_splitter_input.Start(splitter_input);
//            go_source.Join();
//            go_splitter_input.Join();
//
//			Console.WriteLine ("FINISH PEER 0");
//			AutoResetEvent e = new AutoResetEvent (false);
//			e.WaitOne ();
		}
	}
}
