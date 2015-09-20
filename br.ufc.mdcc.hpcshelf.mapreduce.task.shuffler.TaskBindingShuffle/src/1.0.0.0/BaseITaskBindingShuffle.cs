/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeShuffle;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.TaskBindingShuffle
{
	public interface BaseITaskBindingShuffle : ISynchronizerKind 
	{
		ITaskPort<ITaskPorttypeShuffle> Task_port {get;}
	}
}