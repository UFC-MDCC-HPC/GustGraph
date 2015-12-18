/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypePhases;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.ReduceFunction;

namespace br.ufc.mdcc.hpcshelf.mapreduce.computation.Reducer
{
	public interface BaseIReducerLeft<C, RF, OMK, OMV, ORK, ORV> : IComputationKind 
		where C:IEnvironmentPortTypeMultiplePartner
		where RF:IReduceFunction<OMK, OMV, ORK, ORV>
		where OMK:IData
		where OMV:IData
		where ORK:IData
		where ORV:IData
	{
		IKVPair<OMK, ISet<OMV>> Input_item {get;}
		IKVPair<ORK, ORV> Output_item {get;}
	}
}