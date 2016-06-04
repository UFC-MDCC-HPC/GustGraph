/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeData;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvance;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingData;

namespace mapreduce.Workflow
{
	public interface BaseIWorkflow : IComputationKind 
	{
		ITaskBindingAdvance Task_binding_shuffle {get;}
		ITaskBindingAdvance Task_binding_split_first {get;}
		ITaskBindingAdvance Task_binding_split_next {get;}
		ITaskBindingAdvance Task_reduce {get;}
		ITaskBindingAdvance Task_map {get;}
		ITaskBindingData Task_binding_data {get;}
	}
}