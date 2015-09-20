using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Shuffle
{
	public interface IReduceFeeder<PF, OMK> : BaseIReduceFeeder<PF, OMK>
		where PF:IPartitionFunction<OMK>
		where OMK:IData
	{
	}
}
