using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.Connector
{
	public interface IConnectorServer<OCK, OCV> : BaseIConnectorServer<OCK, OCV>
		where OCV:IData
		where OCK:IData
	{
	}
}