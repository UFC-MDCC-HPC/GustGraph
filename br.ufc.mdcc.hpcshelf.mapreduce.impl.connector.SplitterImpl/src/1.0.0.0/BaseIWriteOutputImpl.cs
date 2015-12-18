/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitter;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.Base.EnvironmentPortTypeWriteDataClient;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeSplitter;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.SplitterImpl 
{
	public abstract class BaseIWriteOutputImpl<OUT, DWC>: Synchronizer, BaseIWriteOutput<OUT, DWC>
		where OUT:IData
		where DWC:IEnvironmentPortTypeWriteDataClient
	{
		private ITaskBindingSplitter task_write = null;

		protected ITaskBindingSplitter Task_write
		{
			get
			{
				if (this.task_write == null)
					this.task_write = (ITaskBindingSplitter) Services.getPort("task_write");
				return this.task_write;
			}
		}
		private IChannel split_channel = null;

		public IChannel Split_channel
		{
			get
			{
				if (this.split_channel == null)
					this.split_channel = (IChannel) Services.getPort("split_channel");
				return this.split_channel;
			}
		}
		private IClientBase<DWC> writer = null;

		protected IClientBase<DWC> Writer
		{
			get
			{
				if (this.writer == null)
					this.writer = (IClientBase<DWC>) Services.getPort("writer");
				return this.writer;
			}
		}
		private ITaskPort<ITaskPorttypeSplitter> task_port_write = null;

		public ITaskPort<ITaskPorttypeSplitter> Task_port_write
		{
			get
			{
				if (this.task_port_write == null)
					this.task_port_write = (ITaskPort<ITaskPorttypeSplitter>) Services.getPort("task_port_write");
				return this.task_port_write;
			}
		}
		private OUT output = default(OUT);

		public OUT Output
		{
			get
			{
				if (this.output == null)
					this.output = (OUT) Services.getPort("output");
				return this.output;
			}
		}
	}
}