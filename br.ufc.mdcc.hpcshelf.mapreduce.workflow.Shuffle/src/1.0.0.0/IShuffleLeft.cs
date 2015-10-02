using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Shuffle
{
	public interface IShuffleLeft<C, PF, OMK> : BaseIShuffleLeft<C, PF, OMK>
		where C:IEnvironmentPortTypeMultiplePartner
		where PF:IPartitionFunction<OMK>
		where OMK:IData
	{
	}
}