/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeShuffleReduce;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.TaskBindingShuffleReduce
{
	public interface BaseITaskBindingShuffleReduce : ISynchronizerKind 
	{
		ITaskPort<ITaskPortTypeShuffleReduce> Task_port {get;}
	}
}