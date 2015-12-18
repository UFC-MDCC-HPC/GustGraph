/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeSplitter;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter
{
	public interface BaseIWriteOutput<OUT, DWC> : ISynchronizerKind 
		where OUT:IData
		where DWC:IEnvironmentPortTypeSinglePartner
	{
		IChannel Split_channel {get;}
		ITaskPort<ITaskPorttypeSplitter> Task_port_write {get;}
		OUT Output {get;}
	}
}