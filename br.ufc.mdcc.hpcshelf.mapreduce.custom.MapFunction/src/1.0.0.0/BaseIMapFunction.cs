/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.MapFunction
{
	public interface BaseIMapFunction<IMV, IMK, OMV, OMK> : IComputationKind 
		where IMV:IData
		where IMK:IData
		where OMV:IData
		where OMK:IData
	{
		ISet<IKVPair<OMV, OMK>> Output_pairs {get;}
		IKVPair<IMV, IMK> Input_pair {get;}
	}
}