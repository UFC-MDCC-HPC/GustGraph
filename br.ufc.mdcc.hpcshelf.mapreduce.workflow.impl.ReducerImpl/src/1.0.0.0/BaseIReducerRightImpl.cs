/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypePhases;
using br.ufc.mdcc.hpcshelf.mapreduce.task.reducer.TaskBindingReduce;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsServer;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Reducer;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.ReducerImpl 
{
	public abstract class BaseIReducerRightImpl<S>: Computation, BaseIReducerRight<S>
		where S:IEnvironmentPortTypeTakePairsServer
	{
		private ITaskPort<ITaskPorttypePhases> task_port_reduce = null;

		protected ITaskPort<ITaskPorttypePhases> Task_port_reduce
		{
			get
			{
				if (this.task_port_reduce == null)
					this.task_port_reduce = (ITaskPort<ITaskPorttypePhases>) Services.getPort("task_port_reduce");
				return this.task_port_reduce;
			}
		}
		private ITaskBindingReduce task_reduce = null;

		protected ITaskBindingReduce Task_reduce
		{
			get
			{
				if (this.task_reduce == null)
					this.task_reduce = (ITaskBindingReduce) Services.getPort("task_reduce");
				return this.task_reduce;
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