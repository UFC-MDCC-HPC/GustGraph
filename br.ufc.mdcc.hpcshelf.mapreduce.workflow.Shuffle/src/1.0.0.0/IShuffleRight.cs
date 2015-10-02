using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Shuffle
{
	public interface IShuffleRight<S> : BaseIShuffleRight<S>
		where S:IEnvironmentPortTypeMultiplePartner
	{
	}
}