using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeData;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.port.task.TaskPortTypeDataImpl
{
	public class ITaskPortTypeDataImpl : BaseITaskPortTypeDataImpl, ITaskPortTypeData
	{
		public override void on_initialize ()
		{
			Console.WriteLine ("SETTING DATA ACTIONS --- on_initialize of ITaskPortTypeDataImpl");
	
			ActionDef.action_ids[ITaskPortData.READ_SOURCE] = 10;
			ActionDef.action_ids[ITaskPortData.TERMINATE] = 11;
			ActionDef.action_ids[ITaskPortData.WRITE_SINK] = 12;
		}
	}
}
