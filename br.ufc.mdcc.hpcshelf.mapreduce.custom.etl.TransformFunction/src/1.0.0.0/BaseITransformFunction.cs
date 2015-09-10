/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.etl.TransformFunction
{
	public interface BaseITransformFunction<TOT, TIT> : IComputationKind 
		where TOT:IData
		where TIT:IData
	{
		TOT Output {get;}
		TIT Input {get;}
	}
}