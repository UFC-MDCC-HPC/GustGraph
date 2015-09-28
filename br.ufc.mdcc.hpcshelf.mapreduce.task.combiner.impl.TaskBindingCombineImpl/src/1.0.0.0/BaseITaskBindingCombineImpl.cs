/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypePhases;
using br.ufc.mdcc.hpcshelf.mapreduce.task.combiner.TaskBindingCombine;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.combiner.impl.TaskBindingCombineImpl 
{
	public abstract class BaseITaskBindingCombineImpl: Synchronizer, BaseITaskBindingCombine
	{
		private ITaskPort<ITaskPorttypePhases> task_port = null;

		public ITaskPort<ITaskPorttypePhases> Task_port
		{
			get
			{
				if (this.task_port == null)
					this.task_port = (ITaskPort<ITaskPorttypePhases>) Services.getPort("task_port");
				return this.task_port;
			}
		}
	}
}