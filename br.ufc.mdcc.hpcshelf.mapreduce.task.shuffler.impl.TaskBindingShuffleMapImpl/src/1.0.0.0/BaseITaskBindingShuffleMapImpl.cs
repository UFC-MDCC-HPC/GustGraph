/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeShuffleMap;
using br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.TaskBindingShuffleMap;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.impl.TaskBindingShuffleMapImpl 
{
	public abstract class BaseITaskBindingShuffleMapImpl: Synchronizer, BaseITaskBindingShuffleMap
	{
		private ITaskPort<ITaskPortTypeShuffleMap> task_port = null;

		public ITaskPort<ITaskPortTypeShuffleMap> Task_port
		{
			get
			{
				if (this.task_port == null)
					this.task_port = (ITaskPort<ITaskPortTypeShuffleMap>) Services.getPort("reducer_shuffle");
				return this.task_port;
			}
		}
	}
}