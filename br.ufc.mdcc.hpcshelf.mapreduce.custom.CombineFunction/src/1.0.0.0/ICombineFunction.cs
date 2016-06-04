using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.CombineFunction
{
	public interface ICombineFunction<OMK, OMV> : BaseICombineFunction<OMK, OMV>
		where OMK:IData
		where OMV:IData
	{
	}
}