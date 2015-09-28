/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeShuffle;
using br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.TaskBindingShuffle;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.impl.TaskBindingShuffleImpl 
{
	public abstract class BaseITaskBindingShuffleImpl: Synchronizer, BaseITaskBindingShuffle
	{
		private ITaskPort<ITaskPorttypeShuffle> task_port = null;

		public ITaskPort<ITaskPorttypeShuffle> Task_port
		{
			get
			{
				if (this.task_port == null)
					this.task_port = (ITaskPort<ITaskPorttypeShuffle>) Services.getPort("task_port");
				return this.task_port;
			}
		}
	}
}