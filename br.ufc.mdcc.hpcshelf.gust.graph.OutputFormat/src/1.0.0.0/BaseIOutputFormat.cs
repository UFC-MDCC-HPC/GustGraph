/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.gust.graph.OutputFormat
{
	public interface BaseIOutputFormat<IKey, IValue> : BaseIData, IDataStructureKind
		where IKey:IData
		where IValue:IData
	{
		IIterator<IKVPair<IKey, IValue>> Output_pairs {get;}
	}
}