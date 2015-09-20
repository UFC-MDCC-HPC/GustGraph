/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.ReduceFunction;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Reducer
{
	public interface BaseIReducer<RF, ORV, ORK, OMV, OMK, P> : IComputationKind 
		where RF:IReduceFunction<ORV, ORK, OMV, OMK>
		where ORV:IData
		where ORK:IData
		where OMV:IData
		where OMK:IData
		where P:IPlatform
	{
		IKVPair<ISet<OMV>, OMK> Input_item {get;}
		IKVPair<ORV, ORK> Output_item {get;}
	}
}