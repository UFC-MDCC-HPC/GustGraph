using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.basic.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.Connector
{
	public interface IConnectorServer<O> : BaseIConnectorServer<O>
		where O:IData
	{
	}
}