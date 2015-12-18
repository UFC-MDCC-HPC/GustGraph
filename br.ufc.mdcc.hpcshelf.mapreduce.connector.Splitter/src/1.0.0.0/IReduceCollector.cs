using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter
{
	public interface IReduceCollector<C> : BaseIReduceCollector<C>
		where C:IEnvironmentPortTypeMultiplePartner
	{
	}
}