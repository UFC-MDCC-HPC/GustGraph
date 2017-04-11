using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.datasource.DataSink;
using System.Collections.Generic;
using System.IO;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeDataSinkInterface;
using br.ufc.mdcc.hpcshelf.platform.Maintainer;
using System.Collections;
using System.Collections.Concurrent;
using System.Threading;
          
namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.datasource.DataSinkImpl
{
	public class IDataSinkImpl<P> : BaseIDataSinkImpl<P>, IDataSink<P>
    where P:IMaintainer
	{
		public override void main()
		{
			//Output_data.TraceFlag = true;
			Console.WriteLine ("IDataSink: START 1");
			IPortTypeDataSinkInterface pair_reader = Output_data.Client;
			ConcurrentQueue<Tuple<string,int>> pairs = pair_reader.readCounts();
			Semaphore not_empty = pair_reader.NotEmpty;
			Console.WriteLine ("IDataSink: BEFORE LOOP");
			bool terminate = false;
			Tuple<string,int> pair;
			do 
			{
				not_empty.WaitOne ();
				pairs.TryDequeue (out pair);
				if (pair.Item2 > 0)
					Console.WriteLine ("{0}: {1}", pair.Item1, pair.Item2);
			
			} while (pair.Item2 > 0);
			Console.WriteLine ("IDataSink: FINISH");
		}
	}
}
