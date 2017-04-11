using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using mapreduce.countwords.System;
using br.ufc.mdcc.hpcshelf.mapreduce.computation.Reducer;
using System.Threading;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Shuffler;
using br.ufc.mdcc.hpcshelf.platform.maintainer.ComputeHost;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.hpcshelf.mapreduce.example.cw.Tallier;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;

namespace mapreduce.countwords.SystemImpl
{
	public class IPeer2Impl : br.ufc.pargo.hpe.kinds.Application, IPeer_2
	{
		private void Go(Object o) {
			((Activate)(o)).go();
		}

		public override void main()
		{
			IReducer<IComputeHost, IString, IInteger, IString, IInteger, ITallier> reducer = ((IReducer<IComputeHost, IString, IInteger, IString, IInteger, ITallier>)(this.Services.getPort("reducer")));
			Thread go_reducer = new Thread(new ParameterizedThreadStart(this.Go));
			go_reducer.Start(reducer);
			ISplitterCollector<IString, IInteger, IPartitionFunction<IString>> splitter_output = ((ISplitterCollector<IString, IInteger, IPartitionFunction<IString>>)(this.Services.getPort("splitter_output")));
			Thread go_splitter_output = new Thread(new ParameterizedThreadStart(this.Go));
			go_splitter_output.Start(splitter_output);
			IShufflerFeeder<IString, IInteger> shuffler = ((IShufflerFeeder<IString, IInteger>)(this.Services.getPort("shuffler")));
			Thread go_shuffler = new Thread(new ParameterizedThreadStart(this.Go));
			go_shuffler.Start(shuffler);
			go_reducer.Join();
			go_splitter_output.Join();
			go_shuffler.Join();

			Console.WriteLine ("FINISH PEER 2");
			AutoResetEvent e = new AutoResetEvent (false);
			e.WaitOne ();
		}
	}
}
