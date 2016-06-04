using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.SplitFunction
{
	public interface ISplitFunction<IMK, IMV, IN> : BaseISplitFunction<IMK, IMV, IN>
		where IMK:IData
		where IMV:IData
		where IN:IData
	{
	}
}