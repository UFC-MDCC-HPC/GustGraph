/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.etl.Strategy;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.etl.SplitFunction
{
	public interface BaseISplitFunction<SOT, SIT, ETL> : IComputationKind 
		where SOT:IData
		where SIT:IData
		where ETL:IStrategy
	{
		SOT Output {get;}
		SIT Input {get;}
	}
}