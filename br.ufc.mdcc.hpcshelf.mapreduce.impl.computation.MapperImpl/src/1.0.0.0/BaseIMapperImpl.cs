/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.MapFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvance;
using br.ufc.mdcc.hpcshelf.mapreduce.computation.Mapper;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.computation.MapperImpl 
{
	public abstract class BaseIMapperImpl<IKey, IValue, TKey, TValue, MF>: Computation, BaseIMapper<IKey, IValue, TKey, TValue, MF>
		where MF:IMapFunction<IKey, IValue, TKey, TValue>
		where IKey:IData
		where IValue:IData
		where TKey:IData
		where TValue:IData
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
		private MF map_function = default(MF);

		protected MF Map_function
		{
			get
			{
				if (this.map_function == null)
					this.map_function = (MF) Services.getPort("map_function");
				return this.map_function;
			}
		}
		private ITaskBindingAdvance task_mapper = null;

		protected ITaskBindingAdvance Task_mapper
		{
			get
			{
				if (this.task_mapper == null)
					this.task_mapper = (ITaskBindingAdvance) Services.getPort("task_mapper");
				return this.task_mapper;
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
		private ITaskPort<ITaskPortTypeAdvance> task_port_mapper = null;

		protected ITaskPort<ITaskPortTypeAdvance> Task_port_mapper
		{
			get
			{
				if (this.task_port_mapper == null)
					this.task_port_mapper = (ITaskPort<ITaskPortTypeAdvance>) Services.getPort("task_port_mapper");
				return this.task_port_mapper;
			}
		}

		private IKey map_key = default(IKey);

		protected IKey Map_key {
			get {
				if (this.map_key == null)
					this.map_key = (IKey) Services.getPort("map_key");
				return this.map_key;
			}
		}

		private IIterator<IKVPair<TKey, TValue>> output = null;

		public IIterator<IKVPair<TKey, TValue>> Output {
			get {
				if (this.output == null)
					this.output = (IIterator<IKVPair<TKey, TValue>>) Services.getPort("output");
				return this.output;
			}
		}

		private IValue map_value = default(IValue);

		protected IValue Map_value {
			get {
				if (this.map_value == null)
					this.map_value = (IValue) Services.getPort("map_value");
				return this.map_value;
			}
		}

	}
}