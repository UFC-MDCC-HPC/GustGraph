using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Combiner
{
	public interface ICombiner<OMK, OMV, S, C, P> : BaseICombiner<OMK, OMV, S, C, P>
		where OMK:IData
		where OMV:IData
		where S:IEnvironmentPortTypeMultiplePartner
		where C:IEnvironmentPortTypeMultiplePartner
		where P:IPlatform
	{
	}
}