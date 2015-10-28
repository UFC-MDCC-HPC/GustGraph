/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeSplitterWrite;
using br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitterWrite;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.impl.TaskBindingSplitterWriteImpl 
{
	public abstract class BaseITaskBindingSplitterWriteImpl: Synchronizer, BaseITaskBindingSplitterWrite
	{
		private ITaskPort<ITaskPortTypeSplitterWrite> task_port = null;

		public ITaskPort<ITaskPortTypeSplitterWrite> Task_port
		{
			get
			{
				if (this.task_port == null)
					this.task_port = (ITaskPort<ITaskPortTypeSplitterWrite>) Services.getPort("data_sink_split");
				return this.task_port;
			}
		}
	}
}