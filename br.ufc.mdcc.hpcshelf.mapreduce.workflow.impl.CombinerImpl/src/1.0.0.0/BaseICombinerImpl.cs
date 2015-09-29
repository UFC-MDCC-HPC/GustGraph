/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypePhases;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsClient;
using br.ufc.mdcc.hpcshelf.mapreduce.task.combiner.TaskBindingCombine;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.CombineFunction;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsServer;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Combiner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.CombinerImpl 
{
	public abstract class BaseICombinerImpl<OMK, OMV, C, S, P>: Computation, BaseICombiner<OMK, OMV, C, S, P>
		where OMK:IData
		where OMV:IData
		where C:IEnvironmentPortTypeTakePairsClient
		where S:IEnvironmentPortTypeTakePairsServer
		where P:IPlatform
	{
		private P platform = default(P);

		protected P Platform
		{
			get
			{
				if (this.platform == null)
					this.platform = (P) Services.getPort("platform");
				return this.platform;
			}
		}
		private ITaskPort<ITaskPorttypePhases> task_port = null;

		public ITaskPort<ITaskPorttypePhases> Task_port
		{
			get
			{
				if (this.task_port == null)
					this.task_port = (ITaskPort<ITaskPorttypePhases>) Services.getPort("task_port");
				return this.task_port;
			}
		}
		private IKVPair<OMK, ISet<OMV>> input_data = null;

		public IKVPair<OMK, ISet<OMV>> Input_data
		{
			get
			{
				if (this.input_data == null)
					this.input_data = (IKVPair<OMK, ISet<OMV>>) Services.getPort("input_data");
				return this.input_data;
			}
		}
		private IKVPair<OMK, OMV> output_data = null;

		public IKVPair<OMK, OMV> Output_data
		{
			get
			{
				if (this.output_data == null)
					this.output_data = (IKVPair<OMK, OMV>) Services.getPort("output_data");
				return this.output_data;
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
		private ITaskBindingCombine task_combine = null;

		protected ITaskBindingCombine Task_combine
		{
			get
			{
				if (this.task_combine == null)
					this.task_combine = (ITaskBindingCombine) Services.getPort("task_combine");
				return this.task_combine;
			}
		}
		private ICombineFunction<OMK, OMV> combine_function = null;

		protected ICombineFunction<OMK, OMV> Combine_function
		{
			get
			{
				if (this.combine_function == null)
					this.combine_function = (ICombineFunction<OMK, OMV>) Services.getPort("combine_function");
				return this.combine_function;
			}
		}
		private IServerBase<S> feed_pairs = null;

		protected IServerBase<S> Feed_pairs
		{
			get
			{
				if (this.feed_pairs == null)
					this.feed_pairs = (IServerBase<S>) Services.getPort("feed_pairs");
				return this.feed_pairs;
			}
		}
	}
}