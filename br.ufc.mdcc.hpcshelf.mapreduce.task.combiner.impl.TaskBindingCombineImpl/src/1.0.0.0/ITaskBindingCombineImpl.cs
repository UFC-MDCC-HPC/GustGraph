using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.task.combiner.TaskBindingCombine;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.combiner.impl.TaskBindingCombineImpl
{
	public class ITaskBindingCombineImpl : BaseITaskBindingCombineImpl, ITaskBindingCombine
	{
		public override void main()
		{
		}
		public override void on_initialize ()
		{
			ActionDef.action_ids[ITaskBindingCombineAction.READ_CHUNK]  = 0;
			ActionDef.action_ids[ITaskBindingCombineAction.PERFORM]   = 0;
			ActionDef.action_ids[ITaskBindingCombineAction.CHUNK_READY] = 0;
		}
	}
}
