using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;
using System.ServiceModel;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.Base.EnvironmentPortTypeWriteDataClient
{
    [ServiceContract]
	public interface IEnvironmentPortTypeWriteDataClient : BaseIEnvironmentPortTypeWriteDataClient, IEnvironmentPortTypeSinglePartner
	{
		[OperationContract]
		void write_data_1(int arg1, int arg2, int arg3);
	}
}