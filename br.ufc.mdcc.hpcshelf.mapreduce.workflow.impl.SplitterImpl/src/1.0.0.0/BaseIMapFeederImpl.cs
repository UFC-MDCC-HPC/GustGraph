/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitter;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsServer;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeSplitter;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Splitter;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.SplitterImpl 
{
	public abstract class BaseIMapFeederImpl<S>: Synchronizer, BaseIMapFeeder<S>
		where S:IEnvironmentPortTypeTakePairsServer
	{
		private ITaskBindingSplitter task_feed = null;

		protected ITaskBindingSplitter Task_feed
		{
			get
			{
				if (this.task_feed == null)
					this.task_feed = (ITaskBindingSplitter) Services.getPort("task_feed");
				return this.task_feed;
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
		private ITaskPort<ITaskPorttypeSplitter> task_port_feed = null;

		public ITaskPort<ITaskPorttypeSplitter> Task_port_feed
		{
			get
			{
				if (this.task_port_feed == null)
					this.task_port_feed = (ITaskPort<ITaskPorttypeSplitter>) Services.getPort("task_port_feed");
				return this.task_port_feed;
			}
		}
	}
}