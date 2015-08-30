/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using teste.TestBindingApp;

namespace teste.impl.TestBindingAppImpl 
{
	public abstract class BaseIRightUnitImpl: Application, BaseIRightUnit
	{
		private IChannel binding = null;

		protected IChannel Binding
		{
			get
			{
				if (this.binding == null)
					this.binding = (IChannel) Services.getPort("binding");
				return this.binding;
			}
		}
	}
}