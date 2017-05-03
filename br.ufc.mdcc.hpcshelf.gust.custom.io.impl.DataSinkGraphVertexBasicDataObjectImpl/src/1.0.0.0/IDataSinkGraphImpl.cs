using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Collections.Concurrent;
using System.Threading;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;
using br.ufc.mdcc.hpcshelf.gust.graph.DataObject;
using br.ufc.mdcc.hpcshelf.gust.graph.OutputFormat;
using br.ufc.mdcc.hpcshelf.gust.custom.io.DataSinkGraph;
//using br.ufc.mdcc.hpcshelf.platform.maintainer.DataHost;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.gust.port.environment.PortTypeDataSinkGraphInterface;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;
using br.ufc.mdcc.hpcshelf.platform.Maintainer;

namespace br.ufc.mdcc.hpcshelf.gust.custom.io.impl.DataSinkGraphVertexBasicDataObjectImpl
{
	public class IDataSinkGraphImpl<M, IKey, IValue, GOF>: BaseIDataSinkGraphImpl<M, IKey, IValue, GOF>, IDataSinkGraph<M, IKey, IValue, GOF>
where M:IMaintainer
where IKey:IVertexBasic
where IValue:IDataObject
where GOF:IOutputFormat<IKey, IValue>
	{
		static string OUTPUT_FILE_PATH = System.Environment.GetFolderPath (System.Environment.SpecialFolder.UserProfile)+"/gust.output";//target to folder home
		public override void main()
		{   //Output_data.TraceFlag = true;
			long t0 = (long)(DateTime.UtcNow - (new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds;
			IOutputFormatInstance<IKey,IValue> gof = (IOutputFormatInstance<IKey,IValue>)Graph_output_format.Instance;
			Console.WriteLine ("IDataSinkGraph: START 1");
			IPortTypeDataSinkGraphInterface pair_reader = Output_data.Client;
			ConcurrentQueue<Tuple<object,int>> pairs = pair_reader.readPairs();
			Semaphore not_empty = pair_reader.NotEmpty;
			Console.WriteLine ("IDataSinkGraph: BEFORE LOOP");
			bool terminate = false;
			Tuple<object,int> pair;
			do 
			{
				not_empty.WaitOne ();
				pairs.TryDequeue (out pair);
				if (pair.Item2 > 0)
					gof.sendToFile(OUTPUT_FILE_PATH, pair.Item1); //Console.WriteLine ("{0}: {1}", pair.Item1.ToString());

			} while (pair.Item2 > 0);
			Console.WriteLine ("IDataSink: FINISH");
			long t1 = (long)(DateTime.UtcNow - (new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds;
			Console.WriteLine ("Time processing: " + (t1 - t0) + " ms");
			File.AppendAllText(OUTPUT_FILE_PATH+".time", (t1 - t0) + "" + System.Environment.NewLine);
		}
	}
}
