/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeDataSinkInterface;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
using br.ufc.mdcc.hpcshelf.mapreduce.datasource.DataSink;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingData;
using mapreduce.System;

namespace mapreduce.impl.SystemImpl 
{
	public abstract class BaseIPeer_1Impl: br.ufc.pargo.hpe.kinds.Application, BaseIPeer_1
	{
		private IClientBase<IPortTypeIterator> output_data_client = null;

		protected IClientBase<IPortTypeIterator> Output_data_client
		{
			get
			{
				if (this.output_data_client == null)
					this.output_data_client = (IClientBase<IPortTypeIterator>) Services.getPort("output_data");
				return this.output_data_client;
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
		private IServerBase<IPortTypeDataSinkInterface> output_data = null;

		protected IServerBase<IPortTypeDataSinkInterface> Output_data
		{
			get
			{
				if (this.output_data == null)
					this.output_data = (IServerBase<IPortTypeDataSinkInterface>) Services.getPort("output_data");
				return this.output_data;
			}
		}
		private ISplitterWriteSink splitter = null;

		protected ISplitterWriteSink Splitter
		{
			get
			{
				if (this.splitter == null)
					this.splitter = (ISplitterWriteSink) Services.getPort("splitter");
				return this.splitter;
			}
		}
		private IDataSink<IData, IPlatform> data_sink = null;

		protected IDataSink<IData, IPlatform> Data_sink
		{
			get
			{
				if (this.data_sink == null)
					this.data_sink = (IDataSink<IData, IPlatform>) Services.getPort("data_sink");
				return this.data_sink;
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
	}
}