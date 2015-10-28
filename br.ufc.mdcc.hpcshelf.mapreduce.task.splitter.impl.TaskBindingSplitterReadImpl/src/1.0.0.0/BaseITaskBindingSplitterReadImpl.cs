/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeSplitterRead;
using br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitterRead;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.impl.TaskBindingSplitterReadImpl 
{
	public abstract class BaseITaskBindingSplitterReadImpl: Synchronizer, BaseITaskBindingSplitterRead
	{
		private ITaskPort<ITaskPortTypeSplitterRead> task_port = null;

		public ITaskPort<ITaskPortTypeSplitterRead> Task_port
		{
			get
			{
				if (this.task_port == null)
					this.task_port = (ITaskPort<ITaskPortTypeSplitterRead>) Services.getPort("data_source_split");
				return this.task_port;
			}
		}
	}
}