/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.DataSink
{
	public interface BaseIDataSink<OUT> : IComputationKind 
		where OUT:IData
	{
		OUT Data_type {get;}
	}
}