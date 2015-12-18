/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortType;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingMbyNIntra;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.binding.environment.BindingDirectMxNIterator 
{
	public abstract class BaseIBindingDirectMxNIteratorClient: Synchronizer, BaseIClientMbyNIntra<IPortTypeIterator>
	{
		private IEnvironmentPortType client_port_type = null;

		protected IEnvironmentPortType Client_port_type
		{
			get
			{
				if (this.client_port_type == null)
					this.client_port_type = (IEnvironmentPortType) Services.getPort("client_port_type");
				return this.client_port_type;
			}
		}
	}
}