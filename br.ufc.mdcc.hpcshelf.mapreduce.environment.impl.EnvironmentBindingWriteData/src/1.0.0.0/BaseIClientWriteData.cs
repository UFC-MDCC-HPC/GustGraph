/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.Base.EnvironmentPortTypeWriteDataClient;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.impl.EnvironmentBindingWriteData 
{
	public abstract class BaseIClientWriteData<C>: Synchronizer, BaseIClientBase<C>
	   where C:IEnvironmentPortTypeWriteDataClient
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