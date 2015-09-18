/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.DataSource
{
	public interface BaseIDataSource<IN> : IComputationKind 
		where IN:IData
	{
		IN Data_type {get;}
	}
}