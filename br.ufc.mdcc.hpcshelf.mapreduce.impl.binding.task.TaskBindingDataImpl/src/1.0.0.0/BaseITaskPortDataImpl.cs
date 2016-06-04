/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeData;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingData;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.binding.task.TaskBindingDataImpl 
{
	public abstract class BaseITaskPortDataImpl: Synchronizer, BaseITaskBindingData
	{
		private ITaskPort<ITaskPortTypeData> task_port = null;

		public ITaskPort<ITaskPortTypeData> Task_port
		{
			get
			{
				if (this.task_port == null)
					this.task_port = (ITaskPort<ITaskPortTypeData>) Services.getPort("task_port");
				return this.task_port;
			}
		}
	}
}