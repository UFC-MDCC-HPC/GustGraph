/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.ReduceFunction
{
	public interface BaseIReduceFunction<OMK, OMV, ORK, ORV> : IComputationKind 
		where OMK:IData
		where OMV:IData
		where ORK:IData
		where ORV:IData
	{
		IKVPair<OMK, IIterator<OMV>> Input_values {get;}
		IKVPair<ORK, ORV> Output_value {get;}
	}
}