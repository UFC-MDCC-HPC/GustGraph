using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.ReduceFunction;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Reducer
{
	public interface IReducerLeft<C, RF, OMK, OMV, ORK, ORV> : BaseIReducerLeft<C, RF, OMK, OMV, ORK, ORV>
		where C:IEnvironmentPortTypeMultiplePartner
		where RF:IReduceFunction<OMK, OMV, ORK, ORV>
		where OMK:IData
		where OMV:IData
		where ORK:IData
		where ORV:IData
	{
	}
}