/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.DataSource
{
	public interface BaseIDataSource<IN, C, S, P> : IComputationKind 
		where IN:IData
		where C:IEnvironmentPortTypeSinglePartner
		where S:IEnvironmentPortTypeSinglePartner
		where P:IPlatform
	{
		IN Data_type {get;}
	}
}