using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeDataSinkInterface;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.binding.environment.EnvironmentBindingWriteData
{
	public class IServerWriteData : BaseIServerWriteData, IServerBase<IPortTypeDataSinkInterface>
	{
		public override void main()
		{
		}

		private IPortTypeDataSinkInterface service = null;
		public IPortTypeDataSinkInterface Service { set { service = value; } }
	}
}
