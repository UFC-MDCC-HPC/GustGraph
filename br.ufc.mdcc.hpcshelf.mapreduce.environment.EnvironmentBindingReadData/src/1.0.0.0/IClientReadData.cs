using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.EnvironmentBindingReadData
{
	public interface IClientReadData<C> : BaseIClientReadData<C>, IClientBase<C>
		where C:IEnvironmentPortTypeSinglePartner
	{
	}
}