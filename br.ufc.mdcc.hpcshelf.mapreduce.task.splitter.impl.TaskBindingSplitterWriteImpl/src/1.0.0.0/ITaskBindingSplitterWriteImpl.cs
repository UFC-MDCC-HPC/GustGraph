using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitterWrite;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeSplitterWrite;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.impl.TaskBindingSplitterWriteImpl
{
	public class ITaskBindingSplitterWriteImpl : BaseITaskBindingSplitterWriteImpl, ITaskBindingSplitterWrite
	{
		public override void main()
		{
		}
		public override void on_initialize ()
		{
			ActionDef.action_ids[ITaskBindingSplitterWriteAction.WRITE_SINK]   = 21;
		}
	}
}
