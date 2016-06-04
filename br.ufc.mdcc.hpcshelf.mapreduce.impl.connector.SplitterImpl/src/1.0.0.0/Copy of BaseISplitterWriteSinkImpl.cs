/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvance;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingData;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeData;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.environment.EnvironmentBindingWriteData;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeDataSinkInterface;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.SplitterImpl 
{
	public abstract class BaseISplitterWriteSinkImpl/*<ORK,ORV>*/: Synchronizer, BaseISplitterWriteSink/*<ORK,ORV>*/
		//where ORK:IData
		//where ORV:IData
	{
		static protected int FACET_REDUCE = 0;
		static protected int FACET_MAP = 1;
		static protected int FACET_SOURCE = 2;
		static protected int FACET_SINLK = 3;

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
		private IWriteData<IPortTypeDataSinkInterface> sink = null;

		protected IWriteData<IPortTypeDataSinkInterface> Sink
		{
			get
			{
				if (this.sink == null)
					this.sink = (IWriteData<IPortTypeDataSinkInterface>) Services.getPort("sink");
				return this.sink;
			}
		}

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

		private ITaskBindingData task_binding_data = null;
		protected ITaskBindingData Task_binding_data
		{
			get
			{
				if (this.task_binding_data == null)
					this.task_binding_data = (ITaskBindingData) Services.getPort("task_binding_data");
				return this.task_binding_data;
			}
		}

		private ITaskPort<ITaskPortTypeData> task_port_data = null;
		public ITaskPort<ITaskPortTypeData> Task_port_data
		{
			get
			{
				if (this.task_port_data == null)
					this.task_port_data = (ITaskPort<ITaskPortTypeData>) Services.getPort("task_port_data");
				return this.task_port_data;
			}
		}

	}
}