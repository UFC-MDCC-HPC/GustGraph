/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvance;

namespace br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance
{
	public interface BaseITaskBindingAdvance : ISynchronizerKind 
	{
		ITaskPort<ITaskPortTypeAdvance> Task_port {get;}
	}
}