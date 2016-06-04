using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.ReduceFunction
{
	public interface IReduceFunction<TKey, TValue, OKey, OValue> : BaseIReduceFunction<TKey, TValue, OKey, OValue>
		where TKey:IData
		where TValue:IData
		where OKey:IData
		where OValue:IData
	{
		IKVPair<TKey,IIterator<TValue>> Input_values { get; }
		OValue Continuation_value { get;} 
		IKVPair<OKey,OValue> Output_value { get;} 
	}
}