using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.task.mapper.TaskBindingMap;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.mapper.impl.TaskBindingMapImpl
{
	public class ITaskBindingMapImpl : BaseITaskBindingMapImpl, ITaskBindingMap
	{
		public override void main()
		{
		}
		public override void on_initialize ()
		{
			ActionDef.action_ids[ITaskBindingMapAction.READ_CHUNK]  = 3;
			ActionDef.action_ids[ITaskBindingMapAction.PARTITION]   = 4;
			ActionDef.action_ids[ITaskBindingMapAction.CHUNK_READY] = 5;
		}
	}
}
