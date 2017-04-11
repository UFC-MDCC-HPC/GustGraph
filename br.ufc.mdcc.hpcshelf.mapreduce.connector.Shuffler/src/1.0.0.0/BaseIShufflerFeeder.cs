/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvancePerform;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvanceChunkReady;

namespace br.ufc.mdcc.hpcshelf.mapreduce.connector.Shuffler
{
	public interface BaseIShufflerFeeder<TKey, TValue> : ISynchronizerKind 
		where TKey:IData
		where TValue:IData
	{
		ITaskPort<ITaskPortTypeAdvancePerform> Task_binding_shuffle_perform{get;}
		ITaskPort<ITaskPortTypeAdvanceChunkReady> Task_binding_shuffle_chunk_ready{get;}
		IServerBase<IPortTypeIterator> Feed_pairs { get; }
	}
}