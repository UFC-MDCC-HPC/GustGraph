/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.DataSink
{
	public interface BaseIDataSink<OUT, P> : IComputationKind 
		where OUT:IData
		where P:IPlatform
	{
		OUT Data_type {get;}
	}
}