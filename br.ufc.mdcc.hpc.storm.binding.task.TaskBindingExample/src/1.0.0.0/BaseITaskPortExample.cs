/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortTypeExample;

namespace br.ufc.mdcc.hpc.storm.binding.task.TaskBindingExample
{
	public interface BaseITaskPortExample : ISynchronizerKind 
	{
		ITaskPort<ITaskPortTypeExample> Task_port {get;}
	}
}