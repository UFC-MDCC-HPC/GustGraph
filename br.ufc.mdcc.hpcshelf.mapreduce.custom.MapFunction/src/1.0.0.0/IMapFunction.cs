using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.MapFunction
{
	public interface IMapFunction<IMV, IMK, OMV, OMK> : BaseIMapFunction<IMV, IMK, OMV, OMK>
		where IMV:IData
		where IMK:IData
		where OMV:IData
		where OMK:IData
	{
	}
}