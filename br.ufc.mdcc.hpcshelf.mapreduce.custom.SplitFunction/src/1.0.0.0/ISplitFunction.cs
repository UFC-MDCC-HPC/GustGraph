using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.SplitFunction
{
	public interface ISplitFunction<IMV, IMK, IN> : BaseISplitFunction<IMV, IMK, IN>
		where IMV:IData
		where IMK:IData
		where IN:IData
	{
	}
}