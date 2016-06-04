/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvance;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.TerminateFunction;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.SplitterImpl 
{
	public abstract class BaseISplitterReduceCollectorImpl<IMK,IMV,ORK,ORV,BF>: Synchronizer, BaseISplitterReduceCollector<IMK,IMV,ORK, ORV, BF>
		where IMK:IData
		where IMV:IData
		where ORK:IData
		where ORV:IData
		where BF:IPartitionFunction<IMK>
	{
		static protected int FACET_REDUCE = 0;
		static protected int FACET_MAP = 1;
		static protected int FACET_SOURCE = 2;
		static protected int FACET_SINK = 3;

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

		private IClientBase<IPortTypeIterator> collect_pairs = null;

		protected IClientBase<IPortTypeIterator> Collect_pairs
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

		private BF bin_function_iterate = default(BF);
		protected BF Bin_function_iterate
		{
			get
			{
				if (this.bin_function_iterate == null)
					this.bin_function_iterate = (BF) Services.getPort("bin_function_iterate");
				return this.bin_function_iterate;
			}
		}

		private ORK input_key = default(ORK);
		protected ORK Input_key
		{
			get
			{
				if (this.input_key == null)
					this.input_key = (ORK) Services.getPort("input_key");
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

		private ORK input_key_iterate = default(ORK);
		protected ORK Input_key_iterate
		{
			get
			{
				if (this.input_key_iterate == null)
					this.input_key_iterate = (ORK) Services.getPort("input_key_iterate");
				return this.input_key_iterate;
			}
		}

		private IInteger output_key_iterate = null;
		protected IInteger Output_key_iterate
		{
			get
			{
				if (this.output_key_iterate == null)
					this.output_key_iterate = (IInteger) Services.getPort("output_key_iterate");
				return this.output_key_iterate;
			}
		}

		private ITerminateFunction<IMK,IMV,ORK,ORV> terminate_function = null;
		protected ITerminateFunction<IMK,IMV,ORK,ORV> Terminate_function
		{
			get
			{
				if (this.terminate_function == null)
					this.terminate_function = (ITerminateFunction<IMK,IMV,ORK,ORV>) Services.getPort("terminate_function");
				return this.terminate_function;
			}
		}
		private IIterator<IKVPair<ORK, ORV>> output_pairs = null;

		public IIterator<IKVPair<ORK, ORV>> Output_pairs
		{
			get
			{
				if (this.output_pairs == null)
					this.output_pairs = (IIterator<IKVPair<ORK, ORV>>) Services.getPort("output_pairs");
				return this.output_pairs;
			}
		}


		private IIterator<IKVPair<IMK, IMV>> input_pairs = null;

		public IIterator<IKVPair<IMK, IMV>> Input_pairs
		{
			get
			{
				if (this.input_pairs == null)
					this.input_pairs = (IIterator<IKVPair<IMK, IMV>>) Services.getPort("input_pairs");
				return this.input_pairs;
			}
		}
			}
}