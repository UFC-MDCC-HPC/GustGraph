using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.datasource.DataSink
{
	public interface IDataSink<OUT, C, S, P> : BaseIDataSink<OUT, C, S, P>
		where OUT:IData
		where C:IEnvironmentPortTypeSinglePartner
		where S:IEnvironmentPortTypeSinglePartner
		where P:IPlatform
	{
	}
}