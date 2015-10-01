/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypePhases;
using br.ufc.mdcc.hpcshelf.mapreduce.task.combiner.TaskBindingCombine;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsServer;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Combiner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.CombinerImpl 
{
	public abstract class BaseICombinerRightImpl<S>: Computation, BaseICombinerRight<S>
		where S:IEnvironmentPortTypeTakePairsServer
	{
		private ITaskPort<ITaskPorttypePhases> task_port_combine = null;

		protected ITaskPort<ITaskPorttypePhases> Task_port_combine
		{
			get
			{
				if (this.task_port_combine == null)
					this.task_port_combine = (ITaskPort<ITaskPorttypePhases>) Services.getPort("task_port_combine");
				return this.task_port_combine;
			}
		}
		private ITaskBindingCombine task_combine = null;

		protected ITaskBindingCombine Task_combine
		{
			get
			{
				if (this.task_combine == null)
					this.task_combine = (ITaskBindingCombine) Services.getPort("task_combine");
				return this.task_combine;
			}
		}
		private IServerBase<S> feed_pairs = null;

		protected IServerBase<S> Feed_pairs
		{
			get
			{
				if (this.feed_pairs == null)
					this.feed_pairs = (IServerBase<S>) Services.getPort("feed_pairs");
				return this.feed_pairs;
			}
		}
	}
}