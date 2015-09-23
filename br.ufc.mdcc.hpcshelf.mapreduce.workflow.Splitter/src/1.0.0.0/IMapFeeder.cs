using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Splitter
{
	public interface IMapFeeder<S> : BaseIMapFeeder<S>
		where S:IEnvironmentPortTypeMultiplePartner
	{
	}
}