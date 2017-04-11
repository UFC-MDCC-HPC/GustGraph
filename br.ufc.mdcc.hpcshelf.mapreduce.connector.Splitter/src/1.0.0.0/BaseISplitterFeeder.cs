/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvanceChunkReady;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvancePerform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter
{
	public interface BaseISplitterFeeder<IKey, IValue> : ISynchronizerKind 
		where IKey:IData
		where IValue:IData
	{
		ITaskPort<ITaskPortTypeAdvancePerform> Task_binding_split_perform {get;}
		ITaskPort<ITaskPortTypeAdvanceChunkReady> Task_binding_split_chunk_ready {get;}
		IServerBase<IPortTypeIterator> Feed_pairs { get; }
	}
}