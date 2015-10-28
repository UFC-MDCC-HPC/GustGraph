using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitterRead;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.impl.TaskBindingSplitterReadImpl
{
	public class ITaskBindingSplitterReadImpl : BaseITaskBindingSplitterReadImpl, ITaskBindingSplitterRead
	{
		public override void main()
		{
		}
		public override void on_initialize ()
		{
			ActionDef.action_ids[ITaskBindingSplitterReadAction.PERFORM]     = 3;
			ActionDef.action_ids[ITaskBindingSplitterReadAction.READ_SOURCE]  = 1;
		}
	}
}
