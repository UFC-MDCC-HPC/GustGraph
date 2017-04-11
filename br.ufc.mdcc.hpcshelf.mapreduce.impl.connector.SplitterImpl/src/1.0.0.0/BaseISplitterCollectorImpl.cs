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
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvancePerform;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvanceReadChunk;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.SplitterImpl 
{
	public abstract class BaseISplitterCollectorImpl<IKey,IValue,BF>: Synchronizer, BaseISplitterCollector<IKey,IValue, BF>
		where IKey:IData
		where IValue:IData
		where BF:IPartitionFunction<IKey>
	{
		static protected int FACET_COLLECT = 0;
		static protected int FACET_FEED = 1;

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
			
		private ITaskPort<ITaskPortTypeAdvanceReadChunk> task_binding_split_read_chunk = null;
		public ITaskPort<ITaskPortTypeAdvanceReadChunk> Task_binding_split_read_chunk
		{
			get
			{
				if (this.task_binding_split_read_chunk == null)
					this.task_binding_split_read_chunk = (ITaskPort<ITaskPortTypeAdvanceReadChunk>) Services.getPort("task_binding_split_read_chunk");
				return this.task_binding_split_read_chunk;
			}
		}

		private IClientBase<IPortTypeIterator> collect_pairs = null;

		public IClientBase<IPortTypeIterator> Collect_pairs
		{
			get
			{
				if (this.collect_pairs == null)
					this.collect_pairs = (IClientBase<IPortTypeIterator>) Services.getPort("collect_pairs");
				return this.collect_pairs;
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

		private BF bin_function = default(BF);
		protected BF Bin_function
		{
			get
			{
				if (this.bin_function == null)
					this.bin_function = (BF) Services.getPort("bin_function");
				return this.bin_function;
			}
		}

		private IKey input_key = default(IKey);
		protected IKey Input_key
		{
			get
			{
				if (this.input_key == null)
					this.input_key = (IKey) Services.getPort("input_key");
				return this.input_key;
			}
		}

		private IInteger output_key = null;
		protected IInteger Output_key
		{
			get
			{
				if (this.output_key == null)
					this.output_key = (IInteger) Services.getPort("output_key");
				return this.output_key;
			}
		}
	}
}