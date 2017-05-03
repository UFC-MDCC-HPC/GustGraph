using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBaseDirect;
using br.ufc.mdcc.hpcshelf.gust.port.environment.PortTypeDataSinkGraphInterface;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;

namespace br.ufc.mdcc.hpcshelf.gust.binding.environment.EnvironmentBindingWriteDataGraph
{
	public interface IWriteDataGraph<S> : BaseIWriteDataGraph<S>, IBindingDirect<IPortTypeDataSinkGraphInterface,S>
		where S:IPortTypeIterator
	{
	}
}