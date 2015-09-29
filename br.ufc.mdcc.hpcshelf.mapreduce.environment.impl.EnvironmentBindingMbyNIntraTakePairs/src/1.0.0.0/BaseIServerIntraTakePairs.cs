/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortType;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingMbyNIntra;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsServer;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.impl.EnvironmentBindingMbyNIntraTakePairs 
{
	public abstract class BaseIServerIntraTakePairs<S>: Synchronizer, BaseIServerMbyNIntra<S>
	where S:IEnvironmentPortTypeTakePairsServer
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