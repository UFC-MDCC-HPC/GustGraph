using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Mapper
{
	public interface IMapperRight<S> : BaseIMapperRight<S>
		where S:IEnvironmentPortTypeMultiplePartner
	{
	}
}