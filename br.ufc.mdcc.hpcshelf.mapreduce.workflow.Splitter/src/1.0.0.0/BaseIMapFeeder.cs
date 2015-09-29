/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeSplitter;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Splitter
{
	public interface BaseIMapFeeder<S> : ISynchronizerKind 
		where S:IEnvironmentPortTypeMultiplePartner
	{
		IChannel Split_channel {get;}
		ITaskPort<ITaskPorttypeSplitter> Task_port_feed {get;}
	}
}