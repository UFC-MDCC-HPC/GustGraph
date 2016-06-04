/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.CombineFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvance;
using br.ufc.mdcc.hpcshelf.mapreduce.computation.Combiner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.computation.CombinerImpl 
{
	public abstract class BaseICombinerImpl<CF, OMK, OMV>: Computation, BaseICombiner<CF, OMK, OMV>
		where CF:ICombineFunction<OMK, OMV>
		where OMK:IData
		where OMV:IData
	{
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
		private ITaskBindingAdvance task_combine = null;

		protected ITaskBindingAdvance Task_combine
		{
			get
			{
				if (this.task_combine == null)
					this.task_combine = (ITaskBindingAdvance) Services.getPort("task_combine");
				return this.task_combine;
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
		private IServerBase<IPortTypeIterator> feed_pairs = null;

		protected IServerBase<IPortTypeIterator> Feed_pairs
		{
			get
			{
				if (this.feed_pairs == null)
					this.feed_pairs = (IServerBase<IPortTypeIterator>) Services.getPort("feed_pairs");
				return this.feed_pairs;
			}
		}
		private ITaskPort<ITaskPortTypeAdvance> task_port_combine = null;

		protected ITaskPort<ITaskPortTypeAdvance> Task_port_combine
		{
			get
			{
				if (this.task_port_combine == null)
					this.task_port_combine = (ITaskPort<ITaskPortTypeAdvance>) Services.getPort("task_port_combine");
				return this.task_port_combine;
			}
		}
	}
}