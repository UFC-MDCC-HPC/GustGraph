/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Set;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.CombineFunction
{
	public interface BaseICombineFunction<OMK, OMV> : IComputationKind 
		where OMK:IData
		where OMV:IData
	{
		IKVPair<OMK, ISet<OMV>> Input_data {get;}
		IKVPair<OMK, OMV> Output_data {get;}
	}
}