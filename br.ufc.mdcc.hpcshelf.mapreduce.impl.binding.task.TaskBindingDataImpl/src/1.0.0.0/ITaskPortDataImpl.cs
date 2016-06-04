using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingData;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.binding.task.TaskBindingDataImpl
{
	public class ITaskPortDataImpl : BaseITaskPortDataImpl, ITaskBindingData
	{
		public override void main()
		{
		}
		
		public override void on_initialize ()
		{
			ActionDef.action_ids[ITaskPortData.READ_SOURCE] = 10;
			ActionDef.action_ids[ITaskPortData.TERMINATE] = 11;
			ActionDef.action_ids[ITaskPortData.WRITE_SINK] = 12;
		}
	}
}
