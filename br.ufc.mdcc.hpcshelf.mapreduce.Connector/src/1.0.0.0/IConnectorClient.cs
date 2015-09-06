using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.Connector
{
	public interface IConnectorClient<ICK, ICV> : BaseIConnectorClient<ICK, ICV>
		where ICV:IData
		where ICK:IData
	{
	}
}