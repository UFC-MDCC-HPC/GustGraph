/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypePhases;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsServer;
using br.ufc.mdcc.hpcshelf.mapreduce.task.mapper.TaskBindingMap;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Mapper;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.MapperImpl 
{
	public abstract class BaseIMapperRightImpl<S>: Computation, BaseIMapperRight<S>
		where S:IEnvironmentPortTypeTakePairsServer
	{
		private ITaskPort<ITaskPorttypePhases> task_port = null;

		protected ITaskPort<ITaskPorttypePhases> Task_port
		{
			get
			{
				if (this.task_port == null)
					this.task_port = (ITaskPort<ITaskPorttypePhases>) Services.getPort("task_port");
				return this.task_port;
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
		private ITaskBindingMap task_mapper = null;

		protected ITaskBindingMap Task_mapper
		{
			get
			{
				if (this.task_mapper == null)
					this.task_mapper = (ITaskBindingMap) Services.getPort("task_mapper");
				return this.task_mapper;
			}
		}
	}
}