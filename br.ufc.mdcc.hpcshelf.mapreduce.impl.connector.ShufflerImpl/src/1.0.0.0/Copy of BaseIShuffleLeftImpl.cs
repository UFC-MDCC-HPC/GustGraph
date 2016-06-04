/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.TaskBindingShuffle;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsClient;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeShuffle;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Shuffle;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.ShuffleImpl 
{
	public abstract class BaseIShuffleLeftImpl<C, PF, OMK>: Synchronizer, BaseIShuffleLeft<C, PF, OMK>
		where C:IEnvironmentPortTypeTakePairsClient
		where PF:IPartitionFunction<OMK>
		where OMK:IData
	{
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
		private ITaskBindingShuffle task_shuffle = null;

		protected ITaskBindingShuffle Task_shuffle
		{
			get
			{
				if (this.task_shuffle == null)
					this.task_shuffle = (ITaskBindingShuffle) Services.getPort("task_shuffle");
				return this.task_shuffle;
			}
		}
		private IClientBase<C> collect_pairs = null;

		protected IClientBase<C> Collect_pairs
		{
			get
			{
				if (this.collect_pairs == null)
					this.collect_pairs = (IClientBase<C>) Services.getPort("collect_pairs");
				return this.collect_pairs;
			}
		}
		private PF partition_function = default(PF);

		protected PF Partition_function
		{
			get
			{
				if (this.partition_function == null)
					this.partition_function = (PF) Services.getPort("partition_function");
				return this.partition_function;
			}
		}
		private ITaskPort<ITaskPorttypeShuffle> task_port_shuffle = null;

		protected ITaskPort<ITaskPorttypeShuffle> Task_port_shuffle
		{
			get
			{
				if (this.task_port_shuffle == null)
					this.task_port_shuffle = (ITaskPort<ITaskPorttypeShuffle>) Services.getPort("task_port_shuffle");
				return this.task_port_shuffle;
			}
		}
		private IInteger output_key = null;

		public IInteger Output_key
		{
			get
			{
				if (this.output_key == null)
					this.output_key = (IInteger) Services.getPort("output_key");
				return this.output_key;
			}
		}
		private OMK input_key = default(OMK);

		public OMK Input_key
		{
			get
			{
				if (this.input_key == null)
					this.input_key = (OMK) Services.getPort("input_key");
				return this.input_key;
			}
		}
	}
}