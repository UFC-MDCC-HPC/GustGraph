/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvancePerform;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvanceReadChunk;

namespace br.ufc.mdcc.hpcshelf.mapreduce.connector.Shuffler
{
	public interface BaseIShufflerCollector<TKey,TValue,PF> : ISynchronizerKind 
		where PF:IPartitionFunction<TKey>
		where TKey:IData
		where TValue:IData
	{
		ITaskPort<ITaskPortTypeAdvanceReadChunk> Task_binding_shuffle_read_chunk {get;}
		ITaskPort<ITaskPortTypeAdvancePerform> Task_binding_shuffle_perform {get;}
		IClientBase<IPortTypeIterator> Collect_pairs { get; }
	}
}