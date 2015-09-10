using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.etl.TransformFunction
{
	public interface ITransformFunction<TOT, TIT> : BaseITransformFunction<TOT, TIT>
		where TOT:IData
		where TIT:IData
	{
	}
}