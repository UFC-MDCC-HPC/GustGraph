using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;
using System.Collections.Generic;
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeDataSinkInterface
{
	public interface IPortTypeDataSinkInterface : BaseIPortTypeDataSinkInterface, IEnvironmentPortTypeSinglePartner
	{
		ConcurrentQueue<Tuple<string,int>> readCounts();
		Semaphore NotEmpty { get; }
	}
}