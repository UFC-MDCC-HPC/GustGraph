/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.DataSink
{
	public interface BaseIDataSink<OUT, C, S, P> : IComputationKind 
		where OUT:IData
		where C:IEnvironmentPortTypeSinglePartner
		where S:IEnvironmentPortTypeSinglePartner
		where P:IPlatform
	{
		OUT Data_type {get;}
	}
}