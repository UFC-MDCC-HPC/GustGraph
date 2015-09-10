/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.etl.ExtractFunction
{
	public interface BaseIExtractFunction<EOT> : IComputationKind 
		where EOT:IData
	{
		EOT Output {get;}
	}
}