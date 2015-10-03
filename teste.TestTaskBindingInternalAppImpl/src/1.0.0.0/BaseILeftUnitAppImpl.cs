/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using teste.TestTaskBindingInternal4;
using teste.TestTaskBindingInternal3;
using teste.TestTaskBindingInternalApp;

namespace teste.TestTaskBindingInternalAppImpl 
{
	public abstract class BaseILeftUnitAppImpl: Application, BaseILeftUnitApp
	{
		private ILeftUnitD internal4 = null;

		protected ILeftUnitD Internal4
		{
			get
			{
				if (this.internal4 == null)
					this.internal4 = (ILeftUnitD) Services.getPort("internal4");
				return this.internal4;
			}
		}
		private ILeftUnit internal3 = null;

		protected ILeftUnit Internal3
		{
			get
			{
				if (this.internal3 == null)
					this.internal3 = (ILeftUnit) Services.getPort("internal3");
				return this.internal3;
			}
		}
	}
}