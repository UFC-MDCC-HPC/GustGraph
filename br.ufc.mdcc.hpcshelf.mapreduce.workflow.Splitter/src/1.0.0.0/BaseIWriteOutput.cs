/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Splitter
{
	public interface BaseIWriteOutput<OUT> : ISynchronizerKind 
		where OUT:IData
	{
		IChannel Split_channel {get;}
		OUT Output {get;}
	}
}