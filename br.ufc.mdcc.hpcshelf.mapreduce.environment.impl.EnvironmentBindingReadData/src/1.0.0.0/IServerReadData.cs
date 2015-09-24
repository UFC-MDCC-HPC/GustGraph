using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.impl.EnvironmentBindingReadData
{
	public class IServerReadData : BaseIServerReadData, IServerBase<IEnvironmentPortTypeSinglePartner>
	{
		public override void main()
		{
		}
		public IEnvironmentPortTypeSinglePartner Service{ set {  }  }
	}
}
