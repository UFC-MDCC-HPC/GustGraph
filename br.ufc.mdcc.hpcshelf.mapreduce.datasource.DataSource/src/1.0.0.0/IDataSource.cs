using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.datasource.DataSource
{
	public interface IDataSource<IN, C, S, P> : BaseIDataSource<IN, C, S, P>
		where IN:IData
		where C:IEnvironmentPortTypeSinglePartner
		where S:IEnvironmentPortTypeSinglePartner
		where P:IPlatform
	{
	}
}