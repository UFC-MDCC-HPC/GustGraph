/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeSplitter;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.SplitFunction;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Splitter
{
	public interface BaseIReadInput<SF, IMK, IMV, IN, BF, DSC> : ISynchronizerKind 
		where SF:ISplitFunction<IMK, IMV, IN>
		where IMK:IData
		where IMV:IData
		where IN:IData
		where BF:IPartitionFunction<IMK>
		where DSC:IEnvironmentPortTypeSinglePartner
	{
		IChannel Split_channel {get;}
		IN Input {get;}
		ITaskPort<ITaskPorttypeSplitter> Task_port_read {get;}
	}
}