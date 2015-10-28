/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeSplitterReduce;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitterReduce
{
	public interface BaseITaskBindingSplitterReduce : ISynchronizerKind 
	{
		ITaskPort<ITaskPortTypeSplitterReduce> Task_port {get;}
	}
}