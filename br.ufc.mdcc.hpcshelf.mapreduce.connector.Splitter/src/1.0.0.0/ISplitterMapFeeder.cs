using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter
{
	public interface ISplitterMapFeeder<IKey, IValue> : BaseISplitterMapFeeder<IKey, IValue>
		where IKey:IData
		where IValue:IData
	{
	}
}