/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortTypeExample;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingExample;

namespace br.ufc.mdcc.hpc.storm.binding.task.impl.TaskBindingExampleImpl 
{
	public abstract class BaseTaskPortExample: Synchronizer, BaseITaskPortExample
	{
		private ITaskPort<ITaskPortTypeExample> task_port = null;

		public ITaskPort<ITaskPortTypeExample> Task_port
		{
			get
			{
				if (this.task_port == null)
					this.task_port = (ITaskPort<ITaskPortTypeExample>) Services.getPort("task_port");
				return this.task_port;
			}
		}
	}
}