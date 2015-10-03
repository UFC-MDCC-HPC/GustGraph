using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using teste.TestTaskBindingInternalApp;

namespace teste.TestTaskBindingInternalAppImpl
{
	public class ILeftUnitAppImpl : BaseILeftUnitAppImpl, ILeftUnitApp
	{
		public override void main()
		{
			Internal3.go ();
			Internal4.go ();
		}
	}
}
