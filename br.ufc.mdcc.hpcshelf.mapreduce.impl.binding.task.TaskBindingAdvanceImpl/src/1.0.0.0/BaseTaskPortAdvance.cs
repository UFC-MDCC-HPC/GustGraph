/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvance;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.binding.task.TaskBindingAdvanceImpl 
{
	public abstract class BaseTaskPortAdvance: Synchronizer, BaseITaskBindingAdvance
	{
		private ITaskPort<ITaskPortTypeAdvance> task_port = null;

		public ITaskPort<ITaskPortTypeAdvance> Task_port
		{
			get
			{
				if (this.task_port == null)
					this.task_port = (ITaskPort<ITaskPortTypeAdvance>) Services.getPort("task_port");
				return this.task_port;
			}
		}
	}
}