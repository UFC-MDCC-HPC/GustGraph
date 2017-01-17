using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvance;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.port.task.TaskPortTypeAdvanceImpl
{
	public class ITaskPortTypeAdvanceImpl : BaseITaskPortTypeAdvanceImpl, ITaskPortTypeAdvance
	{
		public override void on_initialize ()
		{
			Console.WriteLine ("SETTING ADVANCE ACTIONS --- on_initialize of ITaskPortTypeAdvanceImpl");

			ActionDef.action_ids[ITaskPortAdvance.READ_CHUNK] = 20;
			ActionDef.action_ids[ITaskPortAdvance.PERFORM] = 21;
			ActionDef.action_ids[ITaskPortAdvance.CHUNK_READY] = 22;
		}
	}
}
