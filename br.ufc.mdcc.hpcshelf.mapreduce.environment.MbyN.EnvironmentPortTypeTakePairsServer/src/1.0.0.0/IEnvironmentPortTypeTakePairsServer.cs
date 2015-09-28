using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsServer
{
	public interface IEnvironmentPortTypeTakePairsServer : BaseIEnvironmentPortTypeTakePairsServer, IEnvironmentPortTypeMultiplePartner
	{
		void take_pairs_1(IGather<int> arg1,  // ALL GATHER
			IReduce<int> arg2,   // ALL REDUCE
			IScan<int> arg3,     // ALL SCAN 
			IGather<int> arg4,   // ALL TO ALL
			IReduce<int> arg5,   // REDUCE_SCATTER
			IScan<int> arg6);    // SCAN_SCATTER

		int take_pairs_2(IGather<int> arg1,   // ALL GATHER
			IReduce<int> arg2,   // ALL REDUCE
			IScan<int> arg3,     // ALL SCAN 
			IGather<int> arg4,   // ALL TO ALL
			IReduce<int> arg5,   // REDUCE_SCATTER
			IScan<int> arg6);    // SCAN_SCATTER

		int take_pairs_3(IGather<int> arg1,   // ALL GATHER
			IReduce<int> arg2,   // ALL REDUCE
			IScan<int> arg3,     // ALL SCAN 
			IGather<int> arg4,   // ALL TO ALL
			IReduce<int> arg5,   // REDUCE_SCATTER
			IScan<int> arg6);    // SCAN_SCATTER

		int take_pairs_4(IGather<int> arg1,   // ALL GATHER
			IReduce<int> arg2,   // ALL REDUCE
			IScan<int> arg3,     // ALL SCAN 
			IGather<int> arg4,   // ALL TO ALL
			IReduce<int> arg5,   // REDUCE_SCATTER
			IScan<int> arg6);    // SCAN_SCATTER

		IScatter<int> take_pairs_5(IGather<int> arg1,   // ALL GATHER
			IReduce<int> arg2,   // ALL REDUCE
			IScan<int> arg3,     // ALL SCAN 
			IGather<int> arg4,   // ALL TO ALL
			IReduce<int> arg5,   // REDUCE_SCATTER
			IScan<int> arg6);    // SCAN_SCATTER

		IScatter<int> take_pairs_6(IGather<int> arg1,   // ALL GATHER
			IReduce<int> arg2,   // ALL REDUCE
			IScan<int> arg3,     // ALL SCAN 
			IGather<int> arg4,   // ALL TO ALL
			IReduce<int> arg5,   // REDUCE_SCATTER
			IScan<int> arg6);    // SCAN_SCATTER

		IScatter<int> take_pairs_7(IGather<int> arg1,   // ALL GATHER
			IReduce<int> arg2,   // ALL REDUCE
			IScan<int> arg3,     // ALL SCAN 
			IGather<int> arg4,   // ALL TO ALL
			IReduce<int> arg5,   // REDUCE_SCATTER
			IScan<int> arg6);    // SCAN_SCATTER

	}
}