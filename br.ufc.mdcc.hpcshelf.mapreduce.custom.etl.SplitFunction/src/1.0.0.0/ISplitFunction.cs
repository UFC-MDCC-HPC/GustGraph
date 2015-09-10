using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.etl.Strategy;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.etl.SplitFunction
{
	public interface ISplitFunction<SOT, SIT, ETL> : BaseISplitFunction<SOT, SIT, ETL>
		where SOT:IData
		where SIT:IData
		where ETL:IStrategy
	{
	}
}