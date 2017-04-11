using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter
{
	public interface ISplitterFeeder<IKey, IValue> : BaseISplitterFeeder<IKey, IValue>
		where IKey:IData
		where IValue:IData
	{
	}
}