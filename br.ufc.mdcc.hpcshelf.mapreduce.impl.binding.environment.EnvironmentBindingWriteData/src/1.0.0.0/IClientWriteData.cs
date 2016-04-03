using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.binding.environment.EnvironmentBindingWriteData
{
	public class IClientWriteData : BaseIClientWriteData, IClientBase<IPortTypeIterator>
	{
		public override void main()
		{
		}

		private IPortTypeIterator service = null;
		public IPortTypeIterator Service { get { return service; } }
	}
}
