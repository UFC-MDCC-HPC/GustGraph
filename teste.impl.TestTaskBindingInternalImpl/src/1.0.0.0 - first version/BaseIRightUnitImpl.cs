/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBinding;
using teste.TestTaskBindingInternal;

namespace teste.impl.TestTaskBindingInternalImpl 
{
	public abstract class BaseIRightUnitImpl: Application, BaseIRightUnit
	{
		private IPeerRight task_binding = null;

		protected IPeerRight Task_binding
		{
			get
			{
				if (this.task_binding == null)
					this.task_binding = (IPeerRight) Services.getPort("task_binding");
				return this.task_binding;
			}
		}
	}
}