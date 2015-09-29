/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitter;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsClient;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeSplitter;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Splitter;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.SplitterImpl 
{
	public abstract class BaseIReduceCollectorImpl<C>: Synchronizer, BaseIReduceCollector<C>
		where C:IEnvironmentPortTypeTakePairsClient
	{
		private ITaskBindingSplitter task_collect = null;

		protected ITaskBindingSplitter Task_collect
		{
			get
			{
				if (this.task_collect == null)
					this.task_collect = (ITaskBindingSplitter) Services.getPort("task_collect");
				return this.task_collect;
			}
		}
		private IChannel split_channel = null;

		public IChannel Split_channel
		{
			get
			{
				if (this.split_channel == null)
					this.split_channel = (IChannel) Services.getPort("split_channel");
				return this.split_channel;
			}
		}
		private IClientBase<C> collect_pairs = null;

		protected IClientBase<C> Collect_pairs
		{
			get
			{
				if (this.collect_pairs == null)
					this.collect_pairs = (IClientBase<C>) Services.getPort("collect_pairs");
				return this.collect_pairs;
			}
		}
		private ITaskPort<ITaskPorttypeSplitter> task_port_collect = null;

		public ITaskPort<ITaskPorttypeSplitter> Task_port_collect
		{
			get
			{
				if (this.task_port_collect == null)
					this.task_port_collect = (ITaskPort<ITaskPorttypeSplitter>) Services.getPort("task_port_collect");
				return this.task_port_collect;
			}
		}
	}
}