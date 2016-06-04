/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Shuffler;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.hpcshelf.mapreduce.computation.Mapper;
using br.ufc.mdcc.hpcshelf.mapreduce.example.cw.WordCounter;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingData;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
using br.ufc.mdcc.common.Integer;
using mapreduce.System;

namespace mapreduce.impl.SystemImpl 
{
	public abstract class BaseIPeer_2Impl: br.ufc.pargo.hpe.kinds.Application, BaseIPeer_2
	{
		private IClientBase<IPortTypeIterator> input_pairs_client = null;

		protected IClientBase<IPortTypeIterator> Input_pairs_client
		{
			get
			{
				if (this.input_pairs_client == null)
					this.input_pairs_client = (IClientBase<IPortTypeIterator>) Services.getPort("input_pairs");
				return this.input_pairs_client;
			}
		}
		private IClientBase<IPortTypeIterator> intermediate_pairs_local_client = null;

		protected IClientBase<IPortTypeIterator> Intermediate_pairs_local_client
		{
			get
			{
				if (this.intermediate_pairs_local_client == null)
					this.intermediate_pairs_local_client = (IClientBase<IPortTypeIterator>) Services.getPort("intermediate_pairs_local");
				return this.intermediate_pairs_local_client;
			}
		}
		private IShufflerMapCollector<IPartitionFunction<IString>, IString> shuffler = null;

		protected IShufflerMapCollector<IPartitionFunction<IString>, IString> Shuffler
		{
			get
			{
				if (this.shuffler == null)
					this.shuffler = (IShufflerMapCollector<IPartitionFunction<IString>, IString>) Services.getPort("shuffler");
				return this.shuffler;
			}
		}
		private ITaskBindingAdvance task_map = null;

		protected ITaskBindingAdvance Task_map
		{
			get
			{
				if (this.task_map == null)
					this.task_map = (ITaskBindingAdvance) Services.getPort("task_map");
				return this.task_map;
			}
		}
		private ITaskBindingAdvance task_binding_split = null;

		protected ITaskBindingAdvance Task_binding_split
		{
			get
			{
				if (this.task_binding_split == null)
					this.task_binding_split = (ITaskBindingAdvance) Services.getPort("task_binding_split");
				return this.task_binding_split;
			}
		}
		private ITaskBindingAdvance task_binding_shuffle = null;

		protected ITaskBindingAdvance Task_binding_shuffle
		{
			get
			{
				if (this.task_binding_shuffle == null)
					this.task_binding_shuffle = (ITaskBindingAdvance) Services.getPort("task_binding_shuffle");
				return this.task_binding_shuffle;
			}
		}
		private IMapper<IWordCounter, IInteger, IString, IString,IInteger> mapper = null;

		protected IMapper<IWordCounter, IInteger, IString, IString,IInteger> Mapper
		{
			get
			{
				if (this.mapper == null)
					this.mapper = (IMapper<IWordCounter, IInteger, IString, IString,IInteger>) Services.getPort("mapper");
				return this.mapper;
			}
		}
		private IServerBase<IPortTypeIterator> intermediate_pairs_local_server = null;

		protected IServerBase<IPortTypeIterator> Intermediate_pairs_local_server
		{
			get
			{
				if (this.intermediate_pairs_local_server == null)
					this.intermediate_pairs_local_server = (IServerBase<IPortTypeIterator>) Services.getPort("intermediate_pairs_local");
				return this.intermediate_pairs_local_server;
			}
		}
		private IServerBase<IPortTypeIterator> input_pairs_server = null;

		protected IServerBase<IPortTypeIterator> Input_pairs_server
		{
			get
			{
				if (this.input_pairs_server == null)
					this.input_pairs_server = (IServerBase<IPortTypeIterator>) Services.getPort("input_pairs");
				return this.input_pairs_server;
			}
		}
		private ITaskBindingData task_binding_data = null;

		protected ITaskBindingData Task_binding_data
		{
			get
			{
				if (this.task_binding_data == null)
					this.task_binding_data = (ITaskBindingData) Services.getPort("task_binding_data");
				return this.task_binding_data;
			}
		}
		private ISplitterMapFeeder<IInteger, IString> splitter = null;

		protected ISplitterMapFeeder<IInteger, IString> Splitter
		{
			get
			{
				if (this.splitter == null)
					this.splitter = (ISplitterMapFeeder<IInteger, IString>) Services.getPort("splitter");
				return this.splitter;
			}
		}
	}
}