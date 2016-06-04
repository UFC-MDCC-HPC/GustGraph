/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using mapreduce.Application;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using mapreduce.Workflow;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingData;
using mapreduce.System;

namespace mapreduce.impl.SystemImpl 
{
	public abstract class BaseIRootImpl: br.ufc.pargo.hpe.kinds.Application, BaseIRoot
	{
		private IApplication application = null;

		protected IApplication Application
		{
			get
			{
				if (this.application == null)
					this.application = (IApplication) Services.getPort("application");
				return this.application;
			}
		}
		private ITaskBindingAdvance task_map = null;

		protected ITaskBindingAdvance Task_map
		{
			get
			{
				if (this.task_map == null)
					this.task_map = (ITaskBindingAdvance) Services.getPort("task_map");
				return this.task_map;
			}
		}
		private ITaskBindingAdvance task_binding_shuffle = null;

		protected ITaskBindingAdvance Task_binding_shuffle
		{
			get
			{
				if (this.task_binding_shuffle == null)
					this.task_binding_shuffle = (ITaskBindingAdvance) Services.getPort("task_binding_shuffle");
				return this.task_binding_shuffle;
			}
		}
		private ITaskBindingAdvance task_reduce = null;

		protected ITaskBindingAdvance Task_reduce
		{
			get
			{
				if (this.task_reduce == null)
					this.task_reduce = (ITaskBindingAdvance) Services.getPort("task_reduce");
				return this.task_reduce;
			}
		}
		private ITaskBindingAdvance task_binding_split = null;

		protected ITaskBindingAdvance Task_binding_split
		{
			get
			{
				if (this.task_binding_split == null)
					this.task_binding_split = (ITaskBindingAdvance) Services.getPort("task_binding_split");
				return this.task_binding_split;
			}
		}
		private IWorkflow workflow = null;

		protected IWorkflow Workflow
		{
			get
			{
				if (this.workflow == null)
					this.workflow = (IWorkflow) Services.getPort("workflow");
				return this.workflow;
			}
		}
		private ITaskBindingData task_binding_data = null;

		protected ITaskBindingData Task_binding_data
		{
			get
			{
				if (this.task_binding_data == null)
					this.task_binding_data = (ITaskBindingData) Services.getPort("task_binding_data");
				return this.task_binding_data;
			}
		}
	}
}