/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvance;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.MapFunction;

namespace br.ufc.mdcc.hpcshelf.mapreduce.computation.Mapper
{
	public interface BaseIMapper<IKey, IValue, TKey, TValue, MF> : IComputationKind 
		where MF:IMapFunction<IKey, IValue, TKey, TValue>
		where IKey:IData
		where IValue:IData
		where TKey:IData
		where TValue:IData
	{
	}
}