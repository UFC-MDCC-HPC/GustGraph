using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingMbyN;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.impl.EnvironmentBindingMbyNTakePairs
{
	public class IClientTakePairs : BaseIClientTakePairs, IClientMbyN<IEnvironmentPortTypeMultiplePartner>
	{
		public override void main()
		{
		}
		//public IEnvironmentPortTypeMultiplePartner Service{
		//	get{
		//		if (this.Service == null)
		//			this.Service = (IEnvironmentPortTypeMultiplePartner) Services.getPort("client_port_type");
		//		return this.Service;
		//	}
		//}
	}
}
