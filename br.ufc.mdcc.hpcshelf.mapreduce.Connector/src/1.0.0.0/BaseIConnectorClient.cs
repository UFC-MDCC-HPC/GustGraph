/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.Connector
{
	public interface BaseIConnectorClient<ICK, ICV> : ISynchronizerKind 
		where ICV:IData
		where ICK:IData
	{
		IKVPair<ICK, ICV> Input {get;}
	}
}