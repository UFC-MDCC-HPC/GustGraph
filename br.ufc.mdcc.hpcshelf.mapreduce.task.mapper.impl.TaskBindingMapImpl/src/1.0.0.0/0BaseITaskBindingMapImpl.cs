/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeMap;
using br.ufc.mdcc.hpcshelf.mapreduce.task.mapper.TaskBindingMap;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.mapper.impl.TaskBindingMapImpl 
{
	public abstract class BaseITaskBindingMapImpl<T>: Synchronizer, BaseITaskBindingMap<T>
		where T:ITaskPortTypeMap
	{
		private ITaskPort<T> task_port = null;

		public ITaskPort<T> Task_port
		{
			get
			{
				if (this.task_port == null)
					this.task_port = (ITaskPort<T>) Services.getPort("task_port");
				return this.task_port;
			}
		}
	}
}