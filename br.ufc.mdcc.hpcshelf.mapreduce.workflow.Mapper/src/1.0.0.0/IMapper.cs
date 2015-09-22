using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.MapFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Mapper
{
	public interface IMapper<M, IMK, IMV, OMK, OMV, P> : BaseIMapper<M, IMK, IMV, OMK, OMV, P>
		where M:IMapFunction<IMK, IMV, OMK, OMV>
		where IMK:IData
		where IMV:IData
		where OMK:IData
		where OMV:IData
		where P:IPlatform
	{
	}
}