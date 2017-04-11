/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvanceReadChunk;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvancePerform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter
{
	public interface BaseISplitterCollector<IKey,IValue,BF> : ISynchronizerKind 
		where IKey:IData
		where IValue:IData
		where BF:IPartitionFunction<IKey>
	{
		ITaskPort<ITaskPortTypeAdvanceReadChunk> Task_binding_split_read_chunk { get; }
		ITaskPort<ITaskPortTypeAdvancePerform> Task_binding_split_perform { get; }
		IClientBase<IPortTypeIterator> Collect_pairs { get; }
	}
}