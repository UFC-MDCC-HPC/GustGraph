using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter
{
	public interface ISplitterWriteSink<OKey,OValue> : BaseISplitterWriteSink<OKey,OValue>
		where OKey:IData
		where OValue:IData	
	{
	}
}