using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.datasource.DataSink
{
	public interface IDataSink<P> : BaseIDataSink<P>
		where P:IPlatform
	{
	}
}