using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBaseDirect;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.gust.port.environment.PortTypeDataSourceGraphInterface;

namespace br.ufc.mdcc.hpcshelf.gust.binding.environment.EnvironmentBindingReadDataGraph
{
	public interface IReadDataGraph<S> : BaseIReadDataGraph<S>, IBindingDirect<IPortTypeIterator,S>
		//where C:IPortTypeIterator
		where S:IPortTypeDataSourceGraphInterface
	{
		void startReadSource();
	}
}