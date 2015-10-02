/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.mapper.TaskBindingMap
{
	public interface BaseITaskBindingMap<T> : ISynchronizerKind 
		where T:ITaskPortType
	{
		ITaskPort<T> Task_port {get;}
	}
}