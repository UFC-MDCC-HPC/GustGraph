/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.DataSource
{
	public interface BaseIDataSource<IN, P> : IComputationKind 
		where IN:IData
		where P:IPlatform
	{
		IN Data_type {get;}
	}
}