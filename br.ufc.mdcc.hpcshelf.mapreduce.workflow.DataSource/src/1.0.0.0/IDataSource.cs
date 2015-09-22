using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.DataSource
{
	public interface IDataSource<IN, P> : BaseIDataSource<IN, P>
		where IN:IData
		where P:IPlatform
	{
	}
}