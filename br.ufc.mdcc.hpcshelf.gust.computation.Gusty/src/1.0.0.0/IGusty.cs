using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.platform.Maintainer;
using br.ufc.mdcc.hpcshelf.gust.custom.GustyFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.computation.Reducer;

namespace br.ufc.mdcc.hpcshelf.gust.computation.Gusty
{
	public interface IGusty<M, TKey, TValue, OKey, OValue, RF, G> : BaseIGusty<M, TKey, TValue, OKey, OValue, RF, G>, IReducer<M, TKey, TValue, OKey, OValue, RF>
		where M:IMaintainer
		where RF:IGustyFunction<TKey, TValue, OKey, OValue, G>
		where TKey:IData
		where TValue:IData
		where OKey:IData
		where OValue:IData
		where G:IData
	{
	}
}