/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeDataSourceInterface;
using br.ufc.mdcc.hpcshelf.mapreduce.datasource.DataSource;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingData;
using mapreduce.System;

namespace mapreduce.impl.SystemImpl 
{
	public abstract class BaseIPeer_0Impl: br.ufc.pargo.hpe.kinds.Application, BaseIPeer_0
	{
		private IServerBase<IPortTypeDataSourceInterface> input_data_server = null;

		protected IServerBase<IPortTypeDataSourceInterface> Input_data_server
		{
			get
			{
				if (this.input_data_server == null)
					this.input_data_server = (IServerBase<IPortTypeDataSourceInterface>) Services.getPort("input_data");
				return this.input_data_server;
			}
		}
		private IDataSource<IData, IPlatform> data_source = null;

		protected IDataSource<IData, IPlatform> Data_source
		{
			get
			{
				if (this.data_source == null)
					this.data_source = (IDataSource<IData, IPlatform>) Services.getPort("data_source");
				return this.data_source;
			}
		}
		private IClientBase<IPortTypeIterator> input_data_client = null;

		protected IClientBase<IPortTypeIterator> Input_data_client
		{
			get
			{
				if (this.input_data_client == null)
					this.input_data_client = (IClientBase<IPortTypeIterator>) Services.getPort("input_data");
				return this.input_data_client;
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
		private ISplitterReadSource<IInteger, IString, IPartitionFunction<IInteger>> splitter = null;

		protected ISplitterReadSource<IInteger, IString,IPartitionFunction<IInteger>> Splitter
		{
			get
			{
				if (this.splitter == null)
					this.splitter = (ISplitterReadSource<IInteger, IString, IPartitionFunction<IInteger>>) Services.getPort("splitter");
				return this.splitter;
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