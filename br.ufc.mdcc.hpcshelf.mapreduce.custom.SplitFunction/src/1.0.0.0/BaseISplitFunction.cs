/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.SplitFunction
{
	public interface BaseISplitFunction<IMV, IMK, IN> : IComputationKind 
		where IMV:IData
		where IMK:IData
		where IN:IData
	{
		IN Input_type {get;}
		ISet<IKVPair<IMV, IMK>> Output_type {get;}
	}
}