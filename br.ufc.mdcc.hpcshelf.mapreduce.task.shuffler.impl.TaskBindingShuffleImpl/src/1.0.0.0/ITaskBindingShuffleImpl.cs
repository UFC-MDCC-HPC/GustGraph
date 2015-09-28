using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.TaskBindingShuffle;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.impl.TaskBindingShuffleImpl
{
	public class ITaskBindingShuffleImpl : BaseITaskBindingShuffleImpl, ITaskBindingShuffle
	{
		public override void main()
		{
		}
		public override void on_initialize ()
		{
			ActionDef.action_ids[ITaskBindingShuffleAction.READ_CHUNK_I]  = 0;
			ActionDef.action_ids[ITaskBindingShuffleAction.PARTITION]   = 0;
			ActionDef.action_ids[ITaskBindingShuffleAction.CHUNK_READY_J] = 0;
		}
	}
}
