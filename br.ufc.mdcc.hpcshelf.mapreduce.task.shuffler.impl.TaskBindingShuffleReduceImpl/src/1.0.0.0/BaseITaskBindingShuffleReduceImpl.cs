/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeShuffleReduce;
using br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.TaskBindingShuffleReduce;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.impl.TaskBindingShuffleReduceImpl 
{
	public abstract class BaseITaskBindingShuffleReduceImpl: Synchronizer, BaseITaskBindingShuffleReduce
	{
		private ITaskPort<ITaskPortTypeShuffleReduce> task_port = null;

		public ITaskPort<ITaskPortTypeShuffleReduce> Task_port
		{
			get
			{
				if (this.task_port == null)
					this.task_port = (ITaskPort<ITaskPortTypeShuffleReduce>) Services.getPort("mapper_shuffle");
				return this.task_port;
			}
		}
	}
}