/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortType;
using br.ufc.mdcc.hpcshelf.gust.binding.environment.EnvironmentBindingReadDataGraph;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBaseDirect;
using br.ufc.mdcc.hpcshelf.gust.port.environment.PortTypeDataSourceGraphInterface;

namespace br.ufc.mdcc.hpcshelf.gust.binding.impl.environment.EnvironmentBindingReadDataGraphImpl
{
	public abstract class BaseIReadDataGraphImpl<S>: Synchronizer, BaseIReadDataGraph<S>
		//where C:IPortTypeIterator
		where S:IPortTypeDataSourceGraphInterface
	{
		private IPortTypeIterator client_port_type = null;
		protected IPortTypeIterator Client_port_type
		{
			get
			{
				if (this.client_port_type == null)
					this.client_port_type = (IPortTypeIterator) Services.getPort("client_port_type");
				return this.client_port_type;
			}
		}

		private S server_port_type = default(S);
		protected S Server_port_type
		{
			get
			{
				if (this.server_port_type == null)
					this.server_port_type = (S) Services.getPort("server_port_type");
				return this.server_port_type;
			}
		}
	}
}