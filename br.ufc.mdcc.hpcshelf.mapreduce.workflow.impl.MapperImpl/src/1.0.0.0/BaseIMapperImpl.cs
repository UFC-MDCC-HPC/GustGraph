/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypePhases;
using br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitter;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsClient;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsServer;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeSplitter;
using br.ufc.mdcc.hpcshelf.mapreduce.task.mapper.TaskBindingMap;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.MapFunction;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Mapper;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.MapperImpl 
{
	public abstract class BaseIMapperImpl<M, IMK, IMV, OMK, OMV, C, S, P>: Computation, BaseIMapper<M, IMK, IMV, OMK, OMV, C, S, P>
		where M:IMapFunction<IMK, IMV, OMK, OMV>
		where IMK:IData
		where IMV:IData
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
		private ITaskPort<ITaskPorttypePhases> task_port_mapper = null;

		public ITaskPort<ITaskPorttypePhases> Task_port_mapper
		{
			get
			{
				if (this.task_port_mapper == null)
					this.task_port_mapper = (ITaskPort<ITaskPorttypePhases>) Services.getPort("task_port_mapper");
				return this.task_port_mapper;
			}
		}
		private ITaskBindingSplitter task_spliter = null;

		protected ITaskBindingSplitter Task_spliter
		{
			get
			{
				if (this.task_spliter == null)
					this.task_spliter = (ITaskBindingSplitter) Services.getPort("task_spliter");
				return this.task_spliter;
			}
		}
		private ISet<IKVPair<OMK, OMV>> output_pairs = null;

		public ISet<IKVPair<OMK, OMV>> Output_pairs
		{
			get
			{
				if (this.output_pairs == null)
					this.output_pairs = (ISet<IKVPair<OMK, OMV>>) Services.getPort("output_pairs");
				return this.output_pairs;
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
		private IKVPair<IMK, IMV> input_pair = null;

		public IKVPair<IMK, IMV> Input_pair
		{
			get
			{
				if (this.input_pair == null)
					this.input_pair = (IKVPair<IMK, IMV>) Services.getPort("input_pair");
				return this.input_pair;
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
		private ITaskPort<ITaskPorttypeSplitter> task_port_splitter = null;

		public ITaskPort<ITaskPorttypeSplitter> Task_port_splitter
		{
			get
			{
				if (this.task_port_splitter == null)
					this.task_port_splitter = (ITaskPort<ITaskPorttypeSplitter>) Services.getPort("task_port_splitter");
				return this.task_port_splitter;
			}
		}
		private ITaskBindingMap task_mapper = null;

		protected ITaskBindingMap Task_mapper
		{
			get
			{
				if (this.task_mapper == null)
					this.task_mapper = (ITaskBindingMap) Services.getPort("task_mapper");
				return this.task_mapper;
			}
		}
		private M map_function = default(M);

		protected M Map_function
		{
			get
			{
				if (this.map_function == null)
					this.map_function = (M) Services.getPort("map_function");
				return this.map_function;
			}
		}
	}
}