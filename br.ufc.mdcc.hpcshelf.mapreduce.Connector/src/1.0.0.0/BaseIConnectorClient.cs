/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.basic.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.Connector
{
	public interface BaseIConnectorClient<I> : ISynchronizerKind 
		where I:IData
	{
		I Input {get;}
	}
}