/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.hpcshelf.mapreduce.computation.Reducer;
using br.ufc.mdcc.hpcshelf.mapreduce.example.cw.Tallier;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Shuffler;
using mapreduce.System;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;

namespace mapreduce.impl.SystemImpl 
{
	public abstract class BaseIPeer_3Impl: br.ufc.pargo.hpe.kinds.Application, BaseIPeer_3
	{
		private IClientBase<IPortTypeIterator> intermediate_pairs_global_client = null;

		protected IClientBase<IPortTypeIterator> Intermediate_pairs_global_client
		{
			get
			{
				if (this.intermediate_pairs_global_client == null)
					this.intermediate_pairs_global_client = (IClientBase<IPortTypeIterator>) Services.getPort("intermediate_pairs_global");
				return this.intermediate_pairs_global_client;
			}
		}
		private IClientBase<IPortTypeIterator> output_pairs_client = null;

		protected IClientBase<IPortTypeIterator> Output_pairs_client
		{
			get
			{
				if (this.output_pairs_client == null)
					this.output_pairs_client = (IClientBase<IPortTypeIterator>) Services.getPort("output_pairs");
				return this.output_pairs_client;
			}
		}
		private ISplitterReduceCollector<IInteger, IString, IPartitionFunction<IInteger>> splitter = null;

		protected ISplitterReduceCollector<IInteger, IString, IPartitionFunction<IInteger>> Splitter
		{
			get
			{
				if (this.splitter == null)
					this.splitter = (ISplitterReduceCollector<IInteger, IString, IPartitionFunction<IInteger>>) Services.getPort("splitter");
				return this.splitter;
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
		private IReducer<ITallier, IString, IInteger, IString, IInteger> reducer = null;

		protected IReducer<ITallier, IString, IInteger, IString, IInteger> Reducer
		{
			get
			{
				if (this.reducer == null)
					this.reducer = (IReducer<ITallier, IString, IInteger, IString, IInteger>) Services.getPort("reducer");
				return this.reducer;
			}
		}
		private IServerBase<IPortTypeIterator> output_pairs_server = null;

		protected IServerBase<IPortTypeIterator> Output_pairs_server
		{
			get
			{
				if (this.output_pairs_server == null)
					this.output_pairs_server = (IServerBase<IPortTypeIterator>) Services.getPort("output_pairs");
				return this.output_pairs_server;
			}
		}
		private IServerBase<IPortTypeIterator> intermediate_pairs_global_server = null;

		protected IServerBase<IPortTypeIterator> Intermediate_pairs_global_server
		{
			get
			{
				if (this.intermediate_pairs_global_server == null)
					this.intermediate_pairs_global_server = (IServerBase<IPortTypeIterator>) Services.getPort("intermediate_pairs_global");
				return this.intermediate_pairs_global_server;
			}
		}
		private IShufflerReduceFeeder<IString, IInteger> shuffler = null;

		protected IShufflerReduceFeeder<IString, IInteger> Shuffler
		{
			get
			{
				if (this.shuffler == null)
					this.shuffler = (IShufflerReduceFeeder<IString, IInteger>) Services.getPort("shuffler");
				return this.shuffler;
			}
		}
	}
}