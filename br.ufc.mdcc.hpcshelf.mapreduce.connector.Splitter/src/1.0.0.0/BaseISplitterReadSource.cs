/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingData;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.environment.EnvironmentBindingReadData;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeDataSourceInterface;
using br.ufc.mdcc.hpcshelf.platform.Maintainer;

namespace br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter
{
	public interface BaseISplitterReadSource<M2,IKey, IValue, BF> : ISynchronizerKind 
		where M2:IMaintainer
		where IKey:IData
		where IValue:IData
		where BF:IPartitionFunction<IKey>
	{
		ITaskBindingAdvance Task_binding_split_first {get;}
		ITaskBindingData Task_binding_data	{ get; } 
		IReadData<IPortTypeDataSourceInterface> Source { get; }
	}
}