/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.ReduceFunction
{
	public interface BaseIReduceFunction<ORV, ORK, OMV, OMK> : IComputationKind 
		where ORV:IData
		where ORK:IData
		where OMV:IData
		where OMK:IData
	{
		IKVPair<ISet<OMV>, OMK> Input {get;}
		IKVPair<ORV, ORK> Output {get;}
	}
}