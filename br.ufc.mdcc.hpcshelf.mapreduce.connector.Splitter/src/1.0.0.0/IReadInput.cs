using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.SplitFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter
{
	public interface IReadInput<SF, IMK, IMV, IN, BF, DSC> : BaseIReadInput<SF, IMK, IMV, IN, BF, DSC>
		where SF:ISplitFunction<IMK, IMV, IN>
		where IMK:IData
		where IMV:IData
		where IN:IData
		where BF:IPartitionFunction<IMK>
		where DSC:IEnvironmentPortTypeSinglePartner
	{
	}
}