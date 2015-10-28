using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitterReduce;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.impl.TaskBindingSplitterReduceImpl
{
	public class ITaskBindingSplitterReduceImpl : BaseITaskBindingSplitterReduceImpl, ITaskBindingSplitterReduce
	{
		public override void main()
		{
		}
		public override void on_initialize ()
		{
			ActionDef.action_ids[ITaskBindingSplitterReduceAction.PARTITION]     = 3;
			ActionDef.action_ids[ITaskBindingSplitterReduceAction.READ_CHUNK]   = 21;
			ActionDef.action_ids[ITaskBindingSplitterReduceAction.TERMINATE]   = 22;
		}
	}
}
