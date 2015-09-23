using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Splitter
{
	public interface IWriteOutput<OUT, DSC> : BaseIWriteOutput<OUT, DSC>
		where OUT:IData
		where DSC:IEnvironmentPortTypeSinglePartner
	{
	}
}