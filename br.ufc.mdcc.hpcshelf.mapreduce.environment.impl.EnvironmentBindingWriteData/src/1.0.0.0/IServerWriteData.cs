using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.Base.EnvironmentPortTypeWriteDataServer;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.impl.EnvironmentBindingWriteData
{
	public class IServerWriteData : BaseIServerWriteData<IEnvironmentPortTypeWriteDataServer>, IServerBase<IEnvironmentPortTypeWriteDataServer>
	{
		public override void main()
		{
		}
		public IEnvironmentPortTypeWriteDataServer Service{ set {  }  }
	}
}
