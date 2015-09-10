using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.etl.LoadFunction
{
	public interface ILoadFunction<LOT, LIT> : BaseILoadFunction<LOT, LIT>
		where LOT:IData
		where LIT:IData
	{
	}
}