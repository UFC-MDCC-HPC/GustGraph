/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeSplitterMap;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitterMap
{
	public interface BaseITaskBindingSplitterMap : ISynchronizerKind 
	{
		ITaskPort<ITaskPortTypeSplitterMap> Task_port {get;}
	}
}