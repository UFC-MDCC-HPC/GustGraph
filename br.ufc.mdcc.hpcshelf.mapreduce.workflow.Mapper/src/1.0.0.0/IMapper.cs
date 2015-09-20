using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.MapFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Mapper
{
	public interface IMapper<M, IMV, IMK, OMV, OMK, P> : BaseIMapper<M, IMV, IMK, OMV, OMK, P>
		where M:IMapFunction<IMV, IMK, OMV, OMK>
		where IMV:IData
		where IMK:IData
		where OMV:IData
		where OMK:IData
		where P:IPlatform
	{
	}
}