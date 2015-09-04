/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.basic.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.Connector
{
	public interface BaseIConnectorServer<O> : ISynchronizerKind 
		where O:IData
	{
		O Output {get;}
	}
}