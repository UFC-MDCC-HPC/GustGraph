using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Reducer
{
	public interface IReducerRight<S> : BaseIReducerRight<S>
		where S:IEnvironmentPortTypeMultiplePartner
	{
	}
}