using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.TaskBindingShuffleReduce;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.impl.TaskBindingShuffleReduceImpl
{
	public class ITaskBindingShuffleReduceImpl : BaseITaskBindingShuffleReduceImpl, ITaskBindingShuffleReduce
	{
		public override void main()
		{
		}
		public override void on_initialize ()
		{
			ActionDef.action_ids[ITaskBindingShuffleReduceAction.READ_CHUNK]  = 0;
			ActionDef.action_ids[ITaskBindingShuffleReduceAction.PROCESS]   = 1;
		}
	}
}
