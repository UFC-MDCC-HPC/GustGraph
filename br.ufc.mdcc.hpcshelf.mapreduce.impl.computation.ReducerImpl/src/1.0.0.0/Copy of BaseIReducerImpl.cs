/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.ReduceFunction;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvance;
using br.ufc.mdcc.hpcshelf.mapreduce.computation.Reducer;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.computation.ReducerImpl 
{
	public abstract class BaseIReducerImpl<OMK, OMV, ORK, ORV, RF>: Computation, BaseIReducer<OMK, OMV, ORK, ORV, RF>
		where RF:IReduceFunction<OMK, OMV, ORK, ORV>
		where ORK:IData
		where ORV:IData
		where OMK:IData
		where OMV:IData
	{
		private IKVPair<ORK, ORV> output_reduce = null;

		protected IKVPair<ORK, ORV> Output_reduce
		{
			get
			{
				if (this.output_reduce == null)
					this.output_reduce = (IKVPair<ORK, ORV>) Services.getPort("output_reduce");
				return this.output_reduce;
			}
		}
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
		private RF reduce_function = default(RF);

		protected RF Reduce_function
		{
			get
			{
				if (this.reduce_function == null)
					this.reduce_function = (RF) Services.getPort("reduce_function");
				return this.reduce_function;
			}
		}
		private ITaskBindingAdvance task_reduce = null;

		protected ITaskBindingAdvance Task_reduce
		{
			get
			{
				if (this.task_reduce == null)
					this.task_reduce = (ITaskBindingAdvance) Services.getPort("task_reduce");
				return this.task_reduce;
			}
		}
		private IKVPair<OMK, IIterator<OMV>> input_reduce = null;

		protected IKVPair<OMK, IIterator<OMV>> Input_reduce
		{
			get
			{
				if (this.input_reduce == null)
					this.input_reduce = (IKVPair<OMK, IIterator<OMV>>) Services.getPort("input_reduce");
				return this.input_reduce;
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
		private ITaskPort<ITaskPortTypeAdvance> task_port_reduce = null;

		protected ITaskPort<ITaskPortTypeAdvance> Task_port_reduce
		{
			get
			{
				if (this.task_port_reduce == null)
					this.task_port_reduce = (ITaskPort<ITaskPortTypeAdvance>) Services.getPort("task_port_reduce");
				return this.task_port_reduce;
			}
		}

		private IIterator<IKVPair<ORK,ORV>> output = null;
		protected IIterator<IKVPair<ORK,ORV>> Output {
			get {
				if (this.output == null)
					this.output = (IIterator<IKVPair<ORK,ORV>>)Services.getPort("output");
				return this.output;
			}
		}

	}
}