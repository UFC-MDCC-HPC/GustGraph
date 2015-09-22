using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.ReduceFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Reducer
{
	public interface IReducer<RF, OMK, OMV, ORK, ORV, P> : BaseIReducer<RF, OMK, OMV, ORK, ORV, P>
		where RF:IReduceFunction<OMK, OMV, ORK, ORV>
		where OMK:IData
		where OMV:IData
		where ORK:IData
		where ORV:IData
		where P:IPlatform
	{
	}
}