using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.DataSource
{
	public interface IDataSource<IN> : BaseIDataSource<IN>
		where IN:IData
	{
	}
}