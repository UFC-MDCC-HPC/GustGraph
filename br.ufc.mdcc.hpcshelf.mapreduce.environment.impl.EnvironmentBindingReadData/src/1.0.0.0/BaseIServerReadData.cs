/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.Base.EnvironmentPortTypeReadDataServer;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.impl.EnvironmentBindingReadData 
{
	public abstract class BaseIServerReadData<S>: Synchronizer, BaseIServerBase<S>
		where S:IEnvironmentPortTypeReadDataServer
	{
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