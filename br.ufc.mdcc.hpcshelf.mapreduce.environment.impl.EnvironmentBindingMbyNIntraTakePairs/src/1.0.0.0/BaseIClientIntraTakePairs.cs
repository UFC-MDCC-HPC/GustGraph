/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortType;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingMbyNIntra;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsClient;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.impl.EnvironmentBindingMbyNIntraTakePairs 
{
	public abstract class BaseIClientIntraTakePairs<C>: Synchronizer, BaseIClientMbyNIntra<C>
	where C:IEnvironmentPortTypeTakePairsClient
	{
		private C client_port_type = default(C);

		protected C Client_port_type
		{
			get
			{
				if (this.client_port_type == null)
					this.client_port_type = (C) Services.getPort("client_port_type");
				return this.client_port_type;
			}
		}
	}
}