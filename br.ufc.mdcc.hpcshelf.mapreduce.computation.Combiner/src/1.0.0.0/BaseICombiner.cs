/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvance;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.CombineFunction;

namespace br.ufc.mdcc.hpcshelf.mapreduce.computation.Combiner
{
	public interface BaseICombiner<CF, OMK, OMV> : IComputationKind 
		where CF:ICombineFunction<OMK, OMV>
		where OMK:IData
		where OMV:IData
	{
		IKVPair<OMK, ISet<OMV>> Input_data {get;}
		IKVPair<OMK, OMV> Output_data {get;}
	}
}