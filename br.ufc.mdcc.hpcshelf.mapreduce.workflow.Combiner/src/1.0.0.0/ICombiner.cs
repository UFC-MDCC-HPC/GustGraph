using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Combiner
{
	public interface ICombiner<OMV, OMK> : BaseICombiner<OMV, OMK>
		where OMV:IData
		where OMK:IData
	{
	}
}