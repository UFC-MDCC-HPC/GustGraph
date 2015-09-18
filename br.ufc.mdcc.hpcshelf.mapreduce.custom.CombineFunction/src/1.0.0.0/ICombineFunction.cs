using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.CombineFunction
{
	public interface ICombineFunction<OMV, OMK> : BaseICombineFunction<OMV, OMK>
		where OMV:IData
		where OMK:IData
	{
	}
}