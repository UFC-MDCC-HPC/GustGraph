/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Set;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Combiner
{
	public interface BaseICombiner<OMV, OMK> : IComputationKind 
		where OMV:IData
		where OMK:IData
	{
		IKVPair<OMV, OMK> Output_data {get;}
		IKVPair<ISet<OMV>, OMK> Input_data {get;}
	}
}