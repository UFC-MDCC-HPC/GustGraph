/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Shuffler;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvancePerform;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvanceChunkReady;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.ShufflerImpl 
{
	public abstract class BaseIShufflerFeederImpl<TKey, TValue>: Synchronizer, BaseIShufflerFeeder<TKey, TValue>
		where TKey:IData
		where TValue:IData	
	{
		static protected int FACET_FEED = 0;
		static protected int FACET_COLLECT = 1;


		private ITaskPort<ITaskPortTypeAdvancePerform> task_binding_shuffle_perform = null;
		public ITaskPort<ITaskPortTypeAdvancePerform> Task_binding_shuffle_perform
		{
			get
			{
				if (this.task_binding_shuffle_perform == null)
					this.task_binding_shuffle_perform = (ITaskPort<ITaskPortTypeAdvancePerform>) Services.getPort("task_binding_shuffle_perform");
				return this.task_binding_shuffle_perform;
			}
		}

		private ITaskPort<ITaskPortTypeAdvanceChunkReady> task_binding_shuffle_chunk_ready = null;
		public ITaskPort<ITaskPortTypeAdvanceChunkReady> Task_binding_shuffle_chunk_ready
		{
			get
			{
				if (this.task_binding_shuffle_chunk_ready == null)
					this.task_binding_shuffle_chunk_ready = (ITaskPort<ITaskPortTypeAdvanceChunkReady>) Services.getPort("task_binding_shuffle_chunk_ready");
				return this.task_binding_shuffle_chunk_ready;
			}
		}


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

		private IIterator<IKVPair<TKey,IIterator<TValue>>> output = null;
		protected IIterator<IKVPair<TKey,IIterator<TValue>>> Output {
			get {
				if (this.output == null)
					this.output = (IIterator<IKVPair<TKey,IIterator<TValue>>>)Services.getPort("output");
				return this.output;
			}
		}

		private IIterator<TValue> value_factory = null;
		protected IIterator<TValue> Value_factory {
			get {
				if (this.value_factory == null)
					this.value_factory = (IIterator<TValue>)Services.getPort("value_factory");
				return this.value_factory;
			}
		}
	}
}