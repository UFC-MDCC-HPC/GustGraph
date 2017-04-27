/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.gust.graph.InputFormat;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.ReduceFunction;

namespace br.ufc.mdcc.hpcshelf.gust.custom.GustyFunction
{
	public interface BaseIGustyFunction<TKey, TValue, OKey, OValue, G, GIF> : BaseIReduceFunction<TKey, TValue, OKey, OValue>, IComputationKind
		where TKey:IData
		where TValue:IData
		where OKey:IData
		where OValue:IData
		where G:IData
		where GIF:IInputFormat
	{
		IIterator<IKVPair<OKey, OValue>> Output_messages {get;}
		G Graph {get;}
	}
}