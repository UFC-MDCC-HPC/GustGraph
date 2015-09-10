/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.etl.LoadFunction
{
	public interface BaseILoadFunction<LOT, LIT> : IComputationKind 
		where LOT:IData
		where LIT:IData
	{
		LOT Output {get;}
		LIT Input {get;}
	}
}