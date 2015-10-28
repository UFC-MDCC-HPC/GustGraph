/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeShuffleMap;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.TaskBindingShuffleMap
{
	public interface BaseITaskBindingShuffleMap : ISynchronizerKind 
	{
		ITaskPort<ITaskPortTypeShuffleMap> Task_port {get;}
	}
}