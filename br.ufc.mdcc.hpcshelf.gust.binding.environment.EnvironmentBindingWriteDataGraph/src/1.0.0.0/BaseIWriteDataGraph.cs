/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBaseDirect;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.gust.port.environment.PortTypeDataSinkGraphInterface;

namespace br.ufc.mdcc.hpcshelf.gust.binding.environment.EnvironmentBindingWriteDataGraph
{
	public interface BaseIWriteDataGraph<S> : BaseIBindingDirect<IPortTypeDataSinkGraphInterface,S>, ISynchronizerKind
		where S:IPortTypeIterator
	{
	}
}