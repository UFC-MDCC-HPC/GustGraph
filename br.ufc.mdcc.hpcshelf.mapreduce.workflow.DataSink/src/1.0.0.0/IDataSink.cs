using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.DataSink
{
	public interface IDataSink<OUT, P> : BaseIDataSink<OUT, P>
		where OUT:IData
		where P:IPlatform
	{
	}
}