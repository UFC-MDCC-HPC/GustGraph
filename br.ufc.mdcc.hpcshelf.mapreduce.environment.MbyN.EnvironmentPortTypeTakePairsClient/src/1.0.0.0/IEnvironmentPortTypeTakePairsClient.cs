using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;
using System.ServiceModel;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsClient
{
	[ServiceContract]
	public interface IEnvironmentPortTypeTakePairsClient : BaseIEnvironmentPortTypeTakePairsClient, IEnvironmentPortTypeMultiplePartner
	{
		[OperationContract]
		void take_pairs_1(int arg1,               // ALL GATHER
			int arg2,                		  // ALL REDUCE
			int arg3,                		  // ALL SCAN
			IScatter<int> arg4,      		  // ALL TO ALL
			IScatter<int> arg5,      		  // REDUCE_SCATTER
			IScatter<int> arg6);    		  // SCAN_SCATTER

		[OperationContract]
		IGather<int> take_pairs_2(int arg1,       // ALL GATHER
			int arg2,                		  // ALL REDUCE
			int arg3,                		  // ALL SCAN
			IScatter<int> arg4,               // ALL TO ALL
			IScatter<int> arg5,               // REDUCE_SCATTER
			IScatter<int> arg6);              // SCAN_SCATTER

		[OperationContract]
		IReduce<int> take_pairs_3(int arg1,       // ALL GATHER
			int arg2,                		  // ALL REDUCE
			int arg3,                		  // ALL SCAN
			IScatter<int> arg4,               // ALL TO ALL
			IScatter<int> arg5,               // REDUCE_SCATTER
			IScatter<int> arg6);              // SCAN_SCATTER

		[OperationContract]
		IScan<int> take_pairs_4(int arg1,        // ALL GATHER
			int arg2,                		 // ALL REDUCE
			int arg3,                        // ALL SCAN
			IScatter<int> arg4,              // ALL TO ALL
			IScatter<int> arg5,              // REDUCE_SCATTER
			IScatter<int> arg6);             // SCAN_SCATTER

		[OperationContract]
		IGather<int> take_pairs_5(int arg1,      // ALL GATHER
			int arg2,                        // ALL REDUCE
			int arg3,                        // ALL SCAN
			IScatter<int> arg4,              // ALL TO ALL
			IScatter<int> arg5,              // REDUCE_SCATTER
			IScatter<int> arg6);             // SCAN_SCATTER

		[OperationContract]
		IReduce<int> take_pairs_6(int arg1,      // ALL GATHER
			int arg2,                        // ALL REDUCE
			int arg3,                        // ALL SCAN
			IScatter<int> arg4,    			 // ALL TO ALL
			IScatter<int> arg5,    			 // REDUCE_SCATTER
			IScatter<int> arg6);   			 // SCAN_SCATTER

		[OperationContract]
		IScan<int> take_pairs_7(int arg1,        // ALL GATHER
			int arg2,                        // ALL REDUCE
			int arg3,                        // ALL SCAN
			IScatter<int> arg4,      		 // ALL TO ALL
			IScatter<int> arg5,      		 // REDUCE_SCATTER
			IScatter<int> arg6);     		 // SCAN_SCATTER
	}
}