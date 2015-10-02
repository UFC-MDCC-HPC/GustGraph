/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.TaskBindingShuffle;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsServer;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeShuffle;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Shuffle;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.ShuffleImpl 
{
	public abstract class BaseIShuffleRightImpl<S>: Synchronizer, BaseIShuffleRight<S>
		where S:IEnvironmentPortTypeTakePairsServer
	{
		private IChannel shuffler_channel = null;

		public IChannel Shuffler_channel
		{
			get
			{
				if (this.shuffler_channel == null)
					this.shuffler_channel = (IChannel) Services.getPort("shuffler_channel");
				return this.shuffler_channel;
			}
		}
		private ITaskBindingShuffle task_shuffle = null;

		protected ITaskBindingShuffle Task_shuffle
		{
			get
			{
				if (this.task_shuffle == null)
					this.task_shuffle = (ITaskBindingShuffle) Services.getPort("task_shuffle");
				return this.task_shuffle;
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
		private ITaskPort<ITaskPorttypeShuffle> task_port_shuffle = null;

		protected ITaskPort<ITaskPorttypeShuffle> Task_port_shuffle
		{
			get
			{
				if (this.task_port_shuffle == null)
					this.task_port_shuffle = (ITaskPort<ITaskPorttypeShuffle>) Services.getPort("task_port_shuffle");
				return this.task_port_shuffle;
			}
		}
	}
}