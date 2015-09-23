using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.EnvironmentBindingReadData
{
	public interface IServerReadData<S> : BaseIServerReadData<S>, IServerBase<S>
		where S:IEnvironmentPortTypeSinglePartner
	{
	}
}