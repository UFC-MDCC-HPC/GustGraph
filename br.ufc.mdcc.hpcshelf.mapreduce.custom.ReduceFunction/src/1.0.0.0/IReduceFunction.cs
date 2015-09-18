using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.ReduceFunction
{
	public interface IReduceFunction<ORV, ORK, OMV, OMK> : BaseIReduceFunction<ORV, ORK, OMV, OMK>
		where ORV:IData
		where ORK:IData
		where OMV:IData
		where OMK:IData
	{
	}
}