using br.ufc.pargo.hpe.kinds;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.MapFunction
{
	public interface IMapFunction<IMK, IMV, OMK, OMV> : BaseIMapFunction<IMK, IMV, OMK, OMV>
		where IMK:IData
		where IMV:IData
		where OMK:IData
		where OMV:IData
}