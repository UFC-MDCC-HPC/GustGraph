/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeSplitterMap;
using br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitterMap;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.impl.TaskBindingSplitterMapImpl 
{
	public abstract class BaseITaskBindingSplitterMapImpl: Synchronizer, BaseITaskBindingSplitterMap
	{
		private ITaskPort<ITaskPortTypeSplitterMap> task_port = null;

		public ITaskPort<ITaskPortTypeSplitterMap> Task_port
		{
			get
			{
				if (this.task_port == null)
					this.task_port = (ITaskPort<ITaskPortTypeSplitterMap>) Services.getPort("mapper_split");
				return this.task_port;
			}
		}
	}
}