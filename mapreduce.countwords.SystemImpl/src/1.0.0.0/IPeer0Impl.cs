using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using mapreduce.countwords.System;
using br.ufc.mdcc.hpcshelf.mapreduce.datasource.DataSource;
using System.Threading;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
using br.ufc.mdcc.hpcshelf.platform.maintainer.DataHost;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;

namespace mapreduce.countwords.SystemImpl
{
	public class IPeer0Impl : br.ufc.pargo.hpe.kinds.Application, IPeer_0
	{
		private void Go(Object o) {
			((Activate)(o)).go();
		}

		public override void main()
		{
			//IDataSource<IDataHost> source = ((IDataSource<IDataHost>)(this.Services.getPort("source")));
			//Thread go_source = new Thread(new ParameterizedThreadStart(this.Go));
   //         go_source.Start(source);
   //         ISplitterCollector<IInteger, IString, IPartitionFunction<IInteger>> splitter_input = ((ISplitterCollector<IInteger, IString, IPartitionFunction<IInteger>>)(this.Services.getPort("splitter_input")));
			//Thread go_splitter_input = new Thread(new ParameterizedThreadStart(this.Go));
			//go_splitter_input.Start(splitter_input);
   //         go_source.Join();
   //         go_splitter_input.Join();		

			//Console.WriteLine ("FINISH PEER 0");
			//AutoResetEvent e = new AutoResetEvent (false);
			//e.WaitOne ();
		}
	}
}
