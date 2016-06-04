/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.SplitFunction
{
	public interface BaseISplitFunction<IMK, IMV, IN> : IComputationKind 
		where IMK:IData
		where IMV:IData
		where IN:IData
	{
		IN Input_type {get;}
		ISet<IKVPair<IMK, IMV>> Output_type {get;}
	}
}