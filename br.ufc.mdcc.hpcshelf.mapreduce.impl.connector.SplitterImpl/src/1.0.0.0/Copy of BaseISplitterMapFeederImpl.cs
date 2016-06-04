/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvance;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.SplitterImpl 
{
	public abstract class BaseISplitterMapFeederImpl<IMK, IMV>: Synchronizer, BaseISplitterMapFeeder<IMK, IMV>
		where IMK:IData
		where IMV:IData
	{
		static protected int FACET_REDUCE = 0;
		static protected int FACET_MAP = 1;
		static protected int FACET_SOURCE = 2;
		static protected int FACET_SINLK = 3;

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
		private ITaskPort<ITaskPortTypeAdvance> task_port_split = null;
		public ITaskPort<ITaskPortTypeAdvance> Task_port_split
		{
			get
			{
				if (this.task_port_split == null)
					this.task_port_split = (ITaskPort<ITaskPortTypeAdvance>) Services.getPort("task_port_split");
				return this.task_port_split;
			}
		}

		private IServerBase<IPortTypeIterator> feed_pairs = null;

		protected IServerBase<IPortTypeIterator> Feed_pairs
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

		private IIterator<IKVPair<IMK,IMV>> output = null;
		protected IIterator<IKVPair<IMK,IMV>> Output {
			get {
				if (this.output == null)
					this.output = (IIterator<IKVPair<IMK,IMV>>)Services.getPort("output");
				return this.output;
			}
		}
	}
}