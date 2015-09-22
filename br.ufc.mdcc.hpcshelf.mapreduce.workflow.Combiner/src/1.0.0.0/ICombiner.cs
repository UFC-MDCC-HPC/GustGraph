using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Combiner
{
	public interface ICombiner<OMK, OMV, P> : BaseICombiner<OMK, OMV, P>
		where OMK:IData
		where OMV:IData
		where P:IPlatform
	{
	}
}