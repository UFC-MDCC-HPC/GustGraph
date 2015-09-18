using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.SplitFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Splitter
{
	public interface IReadInput<SF, IMV, IMK, IN, BF> : BaseIReadInput<SF, IMV, IMK, IN, BF>
		where SF:ISplitFunction<IMV, IMK, IN>
		where IMV:IData
		where IMK:IData
		where IN:IData
		where BF:IPartitionFunction<IMK>
	{
	}
}