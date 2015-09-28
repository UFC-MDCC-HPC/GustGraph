/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeSplitter;
using br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitter;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.impl.TaskBindingSplitterImpl 
{
	public abstract class BaseITaskBindingSplitterImpl: Synchronizer, BaseITaskBindingSplitter
	{
		private ITaskPort<ITaskPorttypeSplitter> task_port = null;

		public ITaskPort<ITaskPorttypeSplitter> Task_port
		{
			get
			{
				if (this.task_port == null)
					this.task_port = (ITaskPort<ITaskPorttypeSplitter>) Services.getPort("task_port");
				return this.task_port;
			}
		}
	}
}