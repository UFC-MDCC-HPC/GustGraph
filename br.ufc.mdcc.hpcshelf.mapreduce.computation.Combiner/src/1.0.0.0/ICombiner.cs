using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.CombineFunction;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.computation.Combiner
{
	public interface ICombiner<CF, OMK, OMV> : BaseICombiner<CF, OMK, OMV>
		where CF:ICombineFunction<OMK, OMV>
		where OMK:IData
		where OMV:IData
	{
	}
}