/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeSplitter;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Splitter
{
	public interface BaseIMapFeeder : ISynchronizerKind 
	{
		IChannel Split_channel {get;}
		ITaskPort<ITaskPorttypeSplitter> Task_port {get;}
	}
}