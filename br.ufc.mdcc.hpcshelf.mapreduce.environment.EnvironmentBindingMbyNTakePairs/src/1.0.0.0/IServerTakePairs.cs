using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingMbyN;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.EnvironmentBindingMbyNTakePairs
{
	public interface IServerTakePairs : BaseIServerTakePairs, IServerMbyN<IEnvironmentPortTypeMultiplePartner>
	{
	}
}//