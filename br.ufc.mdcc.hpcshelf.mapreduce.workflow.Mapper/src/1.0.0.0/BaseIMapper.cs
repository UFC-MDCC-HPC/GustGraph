/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.MapFunction;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Mapper
{
	public interface BaseIMapper<M, IMV, IMK, OMV, OMK, P> : IComputationKind 
		where M:IMapFunction<IMV, IMK, OMV, OMK>
		where IMV:IData
		where IMK:IData
		where OMV:IData
		where OMK:IData
		where P:IPlatform
	{
		ISet<IKVPair<OMV, OMK>> Output_pairs {get;}
		IKVPair<IMV, IMK> Input_pair {get;}
	}
}