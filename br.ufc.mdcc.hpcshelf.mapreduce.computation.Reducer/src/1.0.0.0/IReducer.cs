using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.ReduceFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.platform.Maintainer;

namespace br.ufc.mdcc.hpcshelf.mapreduce.computation.Reducer
{
	public interface IReducer<M,TKey, TValue, OKey, OValue, RF> : BaseIReducer<M,TKey, TValue, OKey, OValue, RF>
		where M:IMaintainer
		where RF:IReduceFunction<TKey, TValue, OKey, OValue>
		where TKey:IData
		where TValue:IData
		where OKey:IData
		where OValue:IData
	{
	}
}