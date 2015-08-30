using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingExample;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpc.storm.binding.task.impl.TaskBindingExampleImpl
{
	public class TaskPortExample : BaseTaskPortExample, ITaskPortExample
	{
		public override void main()
		{
		}

		public override void on_initialize ()
		{
			ActionDef.action_ids[ITaskPortExampleAction.ACTION_0] = 10;
			ActionDef.action_ids[ITaskPortExampleAction.ACTION_1] = 11;
			ActionDef.action_ids[ITaskPortExampleAction.ACTION_2] = 12;
		}

	}
}
