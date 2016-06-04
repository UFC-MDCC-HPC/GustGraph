/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.TerminateFunction
{
	public interface BaseITerminateFunction<IMK, IMV, ORK, ORV> : IComputationKind 
		where IMK:IData
		where IMV:IData
		where ORK:IData
		where ORV:IData
	{	
		IIterator<IKVPair<ORK,ORV>> Output_pairs {get;}
		IIterator<IKVPair<IMK,IMV>> Input_pairs {get;}
	}
}