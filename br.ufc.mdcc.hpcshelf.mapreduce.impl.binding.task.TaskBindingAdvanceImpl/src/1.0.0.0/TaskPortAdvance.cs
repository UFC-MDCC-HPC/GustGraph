using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.binding.task.TaskBindingAdvanceImpl
{
	public class TaskPortAdvance : BaseTaskPortAdvance, ITaskBindingAdvance
	{
		public override void main()
		{
		}
		
		public override void on_initialize ()
		{
			ActionDef.action_ids[ITaskPortAdvance.READ_CHUNK] = 20;
			ActionDef.action_ids[ITaskPortAdvance.PERFORM] = 21;
			ActionDef.action_ids[ITaskPortAdvance.CHUNK_READY] = 22;
		}
	}
}
