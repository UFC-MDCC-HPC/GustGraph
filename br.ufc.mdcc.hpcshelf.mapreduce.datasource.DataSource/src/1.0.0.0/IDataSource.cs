using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.datasource.DataSource
{
	public interface IDataSource<P> : BaseIDataSource<P>
		where P:IPlatform
	{
	}
}