/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.reducer.TaskBindingReduce
{
	public interface BaseITaskBindingReduce : ISynchronizerKind 
	{
		ITaskPort<ITaskPortType> Task_port {get;}
	}
}