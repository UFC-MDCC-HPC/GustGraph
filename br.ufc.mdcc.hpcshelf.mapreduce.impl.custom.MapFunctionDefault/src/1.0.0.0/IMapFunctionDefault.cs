using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.MapFunction;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.custom.MapFunctionDefault
{
	public class IMapFunctionDefault<IKey, IValue, TKey, TValue> : BaseIMapFunctionDefault<IKey, IValue, TKey, TValue>, IMapFunction<IKey, IValue, TKey, TValue>
where IKey:IData
where IValue:IData
where TKey:IData
where TValue:IData
	{
		public override void main()
		{
			IIteratorInstance<IKVPair<TKey,TValue>> outputs = (IIteratorInstance<IKVPair<TKey,TValue>>) Output_data.Instance;
			IKVPairInstance<TKey,TValue> item = (IKVPairInstance<TKey,TValue>) Output_data.createItem();
			item.Key = Input_key.Instance;
			item.Value = Input_value.Instance;
			outputs.put(item);
		}
	}
}
