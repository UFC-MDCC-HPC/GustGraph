using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using teste.Binding;
using MPI;

namespace teste.impl.BindingImpl 
{
	public class IPeerLeftImpl : BaseIPeerLeftImpl, IPeerLeft
	{
		#region IPeerLeft implementation
		public void doSomething (int v)
		{
			int r = this.RootCommunicator.Allreduce (v, times);
			Console.WriteLine ("LEFT CALCULATED " + r);
		}

		private int times(int a, int b) { return a + b; }

		#endregion
	}
}
