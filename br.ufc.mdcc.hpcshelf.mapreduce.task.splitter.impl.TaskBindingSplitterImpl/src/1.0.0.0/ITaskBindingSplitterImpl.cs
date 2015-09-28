using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitter;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.impl.TaskBindingSplitterImpl
{
	public class ITaskBindingSplitterImpl : BaseITaskBindingSplitterImpl, ITaskBindingSplitter
	{
		public override void main()
		{
		}
		public override void on_initialize ()
		{
			ActionDef.action_ids[ITaskBindingSplitterAction.READ_SOURCE]  = 1;
			ActionDef.action_ids[ITaskBindingSplitterAction.READ_CHUNK_J] = 2;
			ActionDef.action_ids[ITaskBindingSplitterAction.PARTITION]    = 3;
			ActionDef.action_ids[ITaskBindingSplitterAction.CHUNK_READY_I]= 20;
			ActionDef.action_ids[ITaskBindingSplitterAction.WRITE_SINK]   = 21;
			ActionDef.action_ids[ITaskBindingSplitterAction.TERMINATE]    = 22;
		}
	}
}
