using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter
{
	public interface IWriteOutput<OUT, DWC> : BaseIWriteOutput<OUT, DWC>
		where OUT:IData
		where DWC:IEnvironmentPortTypeSinglePartner
	{
	}
}