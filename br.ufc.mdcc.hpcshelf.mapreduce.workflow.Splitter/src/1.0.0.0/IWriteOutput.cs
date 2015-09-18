using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Splitter
{
	public interface IWriteOutput<OUT> : BaseIWriteOutput<OUT>
		where OUT:IData
	{
	}
}