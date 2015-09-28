using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.task.reducer.TaskBindingReduce;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.reducer.impl.TaskBindingReduceImpl
{
	public class ITaskBindingReduceImpl : BaseITaskBindingReduceImpl, ITaskBindingReduce
	{
		public override void main()
		{
		}
		public override void on_initialize ()
		{
			ActionDef.action_ids[ITaskBindingReduceAction.READ_CHUNK]  = 0;
			ActionDef.action_ids[ITaskBindingReduceAction.PERFORM]   = 0;
			ActionDef.action_ids[ITaskBindingReduceAction.CHUNK_READY] = 0;
		}
	}
}
