/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitter;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.Base.EnvironmentPortTypeReadDataClient;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.SplitFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeSplitter;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Splitter;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.SplitterImpl 
{
	public abstract class BaseIReadInputImpl<SF, IMK, IMV, IN, BF, DSC>: Synchronizer, BaseIReadInput<SF, IMK, IMV, IN, BF, DSC>
		where SF:ISplitFunction<IMK, IMV, IN>
		where IMK:IData
		where IMV:IData
		where IN:IData
		where BF:IPartitionFunction<IMK>
		where DSC:IEnvironmentPortTypeReadDataClient
	{
		private ITaskBindingSplitter task_read = null;

		protected ITaskBindingSplitter Task_read
		{
			get
			{
				if (this.task_read == null)
					this.task_read = (ITaskBindingSplitter) Services.getPort("task_read");
				return this.task_read;
			}
		}
		private IClientBase<DSC> reader = null;

		protected IClientBase<DSC> Reader
		{
			get
			{
				if (this.reader == null)
					this.reader = (IClientBase<DSC>) Services.getPort("reader");
				return this.reader;
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
		private SF split_function = default(SF);

		protected SF Split_function
		{
			get
			{
				if (this.split_function == null)
					this.split_function = (SF) Services.getPort("split_function");
				return this.split_function;
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
		private IN input = default(IN);

		public IN Input
		{
			get
			{
				if (this.input == null)
					this.input = (IN) Services.getPort("input");
				return this.input;
			}
		}
		private ISet<IKVPair<IMK, IMV>> output_set = null;

		protected ISet<IKVPair<IMK, IMV>> Output_set
		{
			get
			{
				if (this.output_set == null)
					this.output_set = (ISet<IKVPair<IMK, IMV>>) Services.getPort("output_set");
				return this.output_set;
			}
		}
		private ITaskPort<ITaskPorttypeSplitter> task_port_read = null;

		public ITaskPort<ITaskPorttypeSplitter> Task_port_read
		{
			get
			{
				if (this.task_port_read == null)
					this.task_port_read = (ITaskPort<ITaskPorttypeSplitter>) Services.getPort("task_port_read");
				return this.task_port_read;
			}
		}
	}
}