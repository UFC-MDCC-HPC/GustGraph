/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypePhases;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.CombineFunction;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsClient;
using br.ufc.mdcc.hpcshelf.mapreduce.task.combiner.TaskBindingCombine;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Combiner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.CombinerImpl 
{
	public abstract class BaseICombinerLeftImpl<C, CF, OMK, OMV>: Computation, BaseICombinerLeft<C, CF, OMK, OMV>
		where C:IEnvironmentPortTypeTakePairsClient
		where CF:ICombineFunction<OMK, OMV>
		where OMK:IData
		where OMV:IData
	{
		private ITaskPort<ITaskPorttypePhases> task_port_combine = null;

		protected ITaskPort<ITaskPorttypePhases> Task_port_combine
		{
			get
			{
				if (this.task_port_combine == null)
					this.task_port_combine = (ITaskPort<ITaskPorttypePhases>) Services.getPort("task_port_combine");
				return this.task_port_combine;
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
		private CF combine_function = default(CF);

		protected CF Combine_function
		{
			get
			{
				if (this.combine_function == null)
					this.combine_function = (CF) Services.getPort("combine_function");
				return this.combine_function;
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
	}
}