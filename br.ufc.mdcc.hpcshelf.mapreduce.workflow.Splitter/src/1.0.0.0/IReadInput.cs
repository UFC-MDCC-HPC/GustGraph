using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.SplitFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Splitter
{
	public interface IReadInput<SF, IMK, IMV, IN, BF> : BaseIReadInput<SF, IMK, IMV, IN, BF>
		where SF:ISplitFunction<IMK, IMV, IN>
		where IMK:IData
		where IMV:IData
		where IN:IData
		where BF:IPartitionFunction<IMK>
	{
	}
}