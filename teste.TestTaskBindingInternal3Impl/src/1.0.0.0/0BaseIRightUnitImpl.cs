/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeMap;
using br.ufc.mdcc.hpcshelf.mapreduce.task.mapper.TaskBindingMap;
using teste.TestTaskBindingInternal3;

namespace teste.TestTaskBindingInternal3Impl 
{
	public abstract class BaseIRightUnitImpl: Computation, BaseIRightUnit
	{
		private ITaskPort<ITaskPortTypeMap> task_port = null;

		public ITaskPort<ITaskPortTypeMap> Task_port
		{
			get
			{
				if (this.task_port == null)
					this.task_port = (ITaskPort<ITaskPortTypeMap>) Services.getPort("task_port");
				return this.task_port;
			}
		}
		private ITaskBindingMap<ITaskPortTypeMap> task_binding = null;

		protected ITaskBindingMap<ITaskPortTypeMap> Task_binding
		{
			get
			{
				if (this.task_binding == null)
					this.task_binding = (ITaskBindingMap<ITaskPortTypeMap>) Services.getPort("task_binding");
				return this.task_binding;
			}
		}
	}
}