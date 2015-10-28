/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeSplitterReduce;
using br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitterReduce;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.impl.TaskBindingSplitterReduceImpl 
{
	public abstract class BaseITaskBindingSplitterReduceImpl: Synchronizer, BaseITaskBindingSplitterReduce
	{
		private ITaskPort<ITaskPortTypeSplitterReduce> task_port = null;

		public ITaskPort<ITaskPortTypeSplitterReduce> Task_port
		{
			get
			{
				if (this.task_port == null)
					this.task_port = (ITaskPort<ITaskPortTypeSplitterReduce>) Services.getPort("reducer_split");
				return this.task_port;
			}
		}
	}
}