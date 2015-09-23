using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingMbyN;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.EnvironmentBindingMbyNTakePairs
{
	public interface IServerTakePairs<S> : BaseIServerTakePairs<S>, IServerMbyN<S>
		where S:IEnvironmentPortTypeMultiplePartner
	{
	}
}