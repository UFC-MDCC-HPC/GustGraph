/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvance;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingData;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeData;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.environment.EnvironmentBindingReadData;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeDataSourceInterface;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.SplitterImpl 
{
	public abstract class BaseISplitterReadSourceImpl<IKey, IValue, BF>: Synchronizer, BaseISplitterReadSource<IKey, IValue, BF>
		where IKey:IData
		where IValue:IData
		where BF:IPartitionFunction<IKey>
	{
		static protected int FACET_REDUCE = 0;
		static protected int FACET_MAP = 1;
		static protected int FACET_SOURCE = 2;
		static protected int FACET_SINK = 3;

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
		private IReadData<IPortTypeDataSourceInterface> source = null;

		public IReadData<IPortTypeDataSourceInterface> Source
		{
			get
			{
				if (this.source == null)
					this.source = (IReadData<IPortTypeDataSourceInterface>) Services.getPort("source");
				return this.source;
			}
		}
		
		private ITaskBindingAdvance task_binding_split_first = null;
		public ITaskBindingAdvance Task_binding_split_first
		{
			get
			{
				if (this.task_binding_split_first == null)
					this.task_binding_split_first = (ITaskBindingAdvance) Services.getPort("task_binding_split_first");
				return this.task_binding_split_first;
			}
		}

		private ITaskPort<ITaskPortTypeAdvance> task_port_split_first = null;
		protected ITaskPort<ITaskPortTypeAdvance> Task_port_split_first
		{
			get
			{
				if (this.task_port_split_first == null)
					this.task_port_split_first = (ITaskPort<ITaskPortTypeAdvance>) Services.getPort("task_port_split_first");
				return this.task_port_split_first;
			}
		}

		private ITaskBindingData task_binding_data = null;
		public ITaskBindingData Task_binding_data
		{
			get
			{
				if (this.task_binding_data == null)
					this.task_binding_data = (ITaskBindingData) Services.getPort("task_binding_data");
				return this.task_binding_data;
			}
		}

		private ITaskPort<ITaskPortTypeData> task_port_data = null;
		protected ITaskPort<ITaskPortTypeData> Task_port_data
		{
			get
			{
				if (this.task_port_data == null)
					this.task_port_data = (ITaskPort<ITaskPortTypeData>) Services.getPort("task_port_data");
				return this.task_port_data;
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