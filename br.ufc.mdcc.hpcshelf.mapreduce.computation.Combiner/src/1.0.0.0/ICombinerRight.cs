using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Combiner
{
	public interface ICombinerRight<S> : BaseICombinerRight<S>
		where S:IEnvironmentPortTypeMultiplePartner
	{
	}
}