/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypePhases;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.MapFunction;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Mapper
{
	public interface BaseIMapperLeft<C, MF, IMK, IMV, OMK, OMV> : IComputationKind 
		where C:IEnvironmentPortTypeMultiplePartner
		where MF:IMapFunction<IMK, IMV, OMK, OMV>
		where IMK:IData
		where IMV:IData
		where OMK:IData
		where OMV:IData
	{
		ISet<IKVPair<OMK, OMV>> Output_pairs {get;}
		IKVPair<IMK, IMV> Input_pair {get;}
	}
}