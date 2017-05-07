using System;
using System.Threading;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using mapreduce.gust.tc3.System;
//using br.ufc.mdcc.hpcshelf.mapreduce.computation.Reducer;
//using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
//using br.ufc.mdcc.hpcshelf.mapreduce.connector.Shuffler;
//using br.ufc.mdcc.hpcshelf.platform.maintainer.ComputeHost;
//using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;

namespace mapreduce.gust.tc3.SystemImpl
{
	public class IPeer3Impl : br.ufc.pargo.hpe.kinds.Application, IPeer_3
	{
		private void Go(Object o) {
			((Activate)(o)).go();
		}

		public override void main()
		{
		}
	}
}

