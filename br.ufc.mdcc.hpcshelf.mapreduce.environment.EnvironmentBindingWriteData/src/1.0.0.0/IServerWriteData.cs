using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.EnvironmentBindingWriteData
{
	public interface IServerWriteData<S> : BaseIServerWriteData<S>, IServerBase<S>
		where S:IEnvironmentPortTypeSinglePartner
	{
	}
}