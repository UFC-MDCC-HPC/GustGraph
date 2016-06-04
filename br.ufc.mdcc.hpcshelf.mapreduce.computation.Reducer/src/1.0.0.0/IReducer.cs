using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.ReduceFunction;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.computation.Reducer
{
	public interface IReducer<TKey, TValue, OKey, OValue, RF> : BaseIReducer<TKey, TValue, OKey, OValue, RF>
		where RF:IReduceFunction<TKey, TValue, OKey, OValue>
		where TKey:IData
		where TValue:IData
		where OKey:IData
		where OValue:IData
	{
	}
}