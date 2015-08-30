/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBinding;
using teste.TestTaskBindingInternal;

namespace teste.impl.TestTaskBindingInternalImpl 
{
	public abstract class BaseILeftUnitImpl: Application, BaseILeftUnit
	{
		private IPeerLeft task_binding = null;

		protected IPeerLeft Task_binding
		{
			get
			{
				if (this.task_binding == null)
					this.task_binding = (IPeerLeft) Services.getPort("task_binding");
				return this.task_binding;
			}
		}
	}
}