/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeShuffle;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Shuffle
{
	public interface BaseIShuffleLeft<C, PF, OMK> : ISynchronizerKind 
		where C:IEnvironmentPortTypeMultiplePartner
		where PF:IPartitionFunction<OMK>
		where OMK:IData
	{
		IChannel Shuffler_channel {get;}
		IInteger Output_key {get;}
		OMK Input_key {get;}
	}
}