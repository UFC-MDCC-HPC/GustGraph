using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitterMap;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.impl.TaskBindingSplitterMapImpl
{
	public class ITaskBindingSplitterMapImpl : BaseITaskBindingSplitterMapImpl, ITaskBindingSplitterMap
	{
		public override void main()
		{
		}
		
		public override void on_initialize ()
		{
			ActionDef.action_ids[ITaskBindingSplitterMapAction.CHUNK_READY] = 20;
		}
	}
}
