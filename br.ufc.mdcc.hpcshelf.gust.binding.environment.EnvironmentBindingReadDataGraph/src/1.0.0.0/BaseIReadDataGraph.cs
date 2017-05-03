/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBaseDirect;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.gust.port.environment.PortTypeDataSourceGraphInterface;

namespace br.ufc.mdcc.hpcshelf.gust.binding.environment.EnvironmentBindingReadDataGraph
{
	public interface BaseIReadDataGraph<S> : BaseIBindingDirect<IPortTypeIterator,S>, ISynchronizerKind
		where S:IPortTypeDataSourceGraphInterface
	{
	}
}