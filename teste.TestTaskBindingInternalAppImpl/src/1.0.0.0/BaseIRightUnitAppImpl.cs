/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using teste.TestTaskBindingInternal3;
using teste.TestTaskBindingInternal4;
using teste.TestTaskBindingInternalApp;

namespace teste.TestTaskBindingInternalAppImpl 
{
	public abstract class BaseIRightUnitAppImpl: Application, BaseIRightUnitApp
	{
		private IRightUnit internal3 = null;

		protected IRightUnit Internal3
		{
			get
			{
				if (this.internal3 == null)
					this.internal3 = (IRightUnit) Services.getPort("internal3");
				return this.internal3;
			}
		}
		private IRightUnitD internal4 = null;

		protected IRightUnitD Internal4
		{
			get
			{
				if (this.internal4 == null)
					this.internal4 = (IRightUnitD) Services.getPort("internal4");
				return this.internal4;
			}
		}
	}
}