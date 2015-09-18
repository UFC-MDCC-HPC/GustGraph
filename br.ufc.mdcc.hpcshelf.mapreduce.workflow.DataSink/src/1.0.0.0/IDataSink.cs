using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.DataSink
{
	public interface IDataSink<OUT> : BaseIDataSink<OUT>
		where OUT:IData
	{
	}
}