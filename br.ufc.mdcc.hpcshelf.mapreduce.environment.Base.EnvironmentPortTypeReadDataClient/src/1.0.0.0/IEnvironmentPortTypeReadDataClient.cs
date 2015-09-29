using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;
using System.ServiceModel;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.Base.EnvironmentPortTypeReadDataClient
{
    [ServiceContract]
	public interface IEnvironmentPortTypeReadDataClient : BaseIEnvironmentPortTypeReadDataClient, IEnvironmentPortTypeSinglePartner
	{
		[OperationContract]
		void read_data_1(int arg1, int arg2, int arg3);
	}
}