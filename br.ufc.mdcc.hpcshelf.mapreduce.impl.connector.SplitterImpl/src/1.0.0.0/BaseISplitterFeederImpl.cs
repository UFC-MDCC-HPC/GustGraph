/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvanceChunkReady;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvancePerform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.SplitterImpl 
{
	public abstract class BaseISplitterFeederImpl<IKey, IValue>: Synchronizer, BaseISplitterFeeder<IKey, IValue>
		where IKey:IData
		where IValue:IData
	{
		static protected int FACET_COLLECT = 0;
		static protected int FACET_FEED = 1;


		private IServerBase<IPortTypeIterator> feed_pairs = null;

		public IServerBase<IPortTypeIterator> Feed_pairs
		{
			get
			{
				if (this.feed_pairs == null)
					this.feed_pairs = (IServerBase<IPortTypeIterator>) Services.getPort("feed_pairs");
				return this.feed_pairs;
			}
		}

		private IChannel split_channel = null;

		protected IChannel Split_channel
		{
			get
			{
				if (this.split_channel == null)
					this.split_channel = (IChannel) Services.getPort("split_channel");
				return this.split_channel;
			}
		}

		private IIterator<IKVPair<IKey,IValue>> output = null;
		protected IIterator<IKVPair<IKey,IValue>> Output {
			get {
				if (this.output == null)
					this.output = (IIterator<IKVPair<IKey,IValue>>)Services.getPort("output");
				return this.output;
			}
		}

		private ITaskPort<ITaskPortTypeAdvancePerform> task_binding_split_perform = null;
		public ITaskPort<ITaskPortTypeAdvancePerform> Task_binding_split_perform
		{
			get
			{
				if (this.task_binding_split_perform == null)
					this.task_binding_split_perform = (ITaskPort<ITaskPortTypeAdvancePerform>) Services.getPort("task_binding_split_perform");
				return this.task_binding_split_perform;
			}
		}

		private ITaskPort<ITaskPortTypeAdvanceChunkReady> task_binding_split_chunk_ready = null;
		public ITaskPort<ITaskPortTypeAdvanceChunkReady> Task_binding_split_chunk_ready
		{
			get
			{
				if (this.task_binding_split_chunk_ready == null)
					this.task_binding_split_chunk_ready = (ITaskPort<ITaskPortTypeAdvanceChunkReady>) Services.getPort("task_binding_split_chunk_ready");
				return this.task_binding_split_chunk_ready;
			}
		}

	}
}