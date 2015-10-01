/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypePhases;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsClient;
using br.ufc.mdcc.hpcshelf.mapreduce.task.mapper.TaskBindingMap;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.MapFunction;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Mapper;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.MapperImpl 
{
	public abstract class BaseIMapperLeftImpl<C, MF, IMK, IMV, OMK, OMV>: Computation, BaseIMapperLeft<C, MF, IMK, IMV, OMK, OMV>
		where C:IEnvironmentPortTypeTakePairsClient
		where MF:IMapFunction<IMK, IMV, OMK, OMV>
		where IMK:IData
		where IMV:IData
		where OMK:IData
		where OMV:IData
	{
		private ITaskPort<ITaskPorttypePhases> task_port_mapper = null;

		protected ITaskPort<ITaskPorttypePhases> Task_port_mapper
		{
			get
			{
				if (this.task_port_mapper == null)
					this.task_port_mapper = (ITaskPort<ITaskPorttypePhases>) Services.getPort("task_port_mapper");
				return this.task_port_mapper;
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
	}
}