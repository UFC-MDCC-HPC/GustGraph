using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeDataSourceInterface;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.binding.environment.EnvironmentBindingReadData
{
	public class IServerReadData : BaseIServerReadData, IServerBase<IPortTypeDataSourceInterface>
	{
		public override void main()
		{
		}

		private IPortTypeDataSourceInterface service=null;
		public IPortTypeDataSourceInterface Service { set { service = value; } }
	}
}
