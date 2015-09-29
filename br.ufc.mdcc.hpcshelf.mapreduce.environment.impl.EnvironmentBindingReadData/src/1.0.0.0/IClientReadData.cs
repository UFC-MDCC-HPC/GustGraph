using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.Base.EnvironmentPortTypeReadDataClient;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.impl.EnvironmentBindingReadData
{
	public class IClientReadData : BaseIClientReadData<IEnvironmentPortTypeReadDataClient>, IClientBase<IEnvironmentPortTypeReadDataClient>
	{
		public override void main()
		{
		}
		public IEnvironmentPortTypeReadDataClient Service{ get { return null; }  }
	}
}
