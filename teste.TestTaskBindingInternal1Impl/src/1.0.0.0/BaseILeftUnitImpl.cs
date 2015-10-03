/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortTypeExample;
using teste.TestTaskBindingInternal1;

namespace teste.TestTaskBindingInternal1Impl 
{
	public abstract class BaseILeftUnitImpl: Computation, BaseILeftUnit
	{
		private ITaskPort<ITaskPortTypeExample> task_binding = null;

		protected ITaskPort<ITaskPortTypeExample> Task_binding
		{
			get
			{
				if (this.task_binding == null)
					this.task_binding = (ITaskPort<ITaskPortTypeExample>) Services.getPort("task_binding");
				return this.task_binding;
			}
		}
	}
}