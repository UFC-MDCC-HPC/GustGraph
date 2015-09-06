/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.Connector
{
	public interface BaseIConnectorServer<OCK, OCV> : ISynchronizerKind 
		where OCV:IData
		where OCK:IData
	{
		IKVPair<OCK, OCV> Output {get;}
	}
}