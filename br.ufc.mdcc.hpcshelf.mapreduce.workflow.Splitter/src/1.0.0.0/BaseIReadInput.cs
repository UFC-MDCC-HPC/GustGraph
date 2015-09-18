/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.SplitFunction;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Splitter
{
	public interface BaseIReadInput<SF, IMV, IMK, IN, BF> : ISynchronizerKind 
		where SF:ISplitFunction<IMV, IMK, IN>
		where IMV:IData
		where IMK:IData
		where IN:IData
		where BF:IPartitionFunction<IMK>
	{
		IChannel Split_channel {get;}
		IN Input {get;}
	}
}