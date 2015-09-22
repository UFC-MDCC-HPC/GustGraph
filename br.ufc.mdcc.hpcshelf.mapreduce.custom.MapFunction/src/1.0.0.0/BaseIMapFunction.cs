/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.MapFunction
{
	public interface BaseIMapFunction<IMK, IMV, OMK, OMV> : IComputationKind 
		where IMK:IData
		where IMV:IData
		where OMK:IData
		where OMV:IData
	{
		ISet<IKVPair<OMK, OMV>> Output_pairs {get;}
		IKVPair<IMK, IMV> Input_pair {get;}
	}
}