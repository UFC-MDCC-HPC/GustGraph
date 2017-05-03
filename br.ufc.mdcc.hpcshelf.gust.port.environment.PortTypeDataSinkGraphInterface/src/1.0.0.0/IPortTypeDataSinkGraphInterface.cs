using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;
using System.Collections.Generic;
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace br.ufc.mdcc.hpcshelf.gust.port.environment.PortTypeDataSinkGraphInterface
{
	public interface IPortTypeDataSinkGraphInterface : BaseIPortTypeDataSinkGraphInterface, IEnvironmentPortTypeSinglePartner
	{
		ConcurrentQueue<Tuple<object,int>> readPairs();
		Semaphore NotEmpty { get; }
	}
}