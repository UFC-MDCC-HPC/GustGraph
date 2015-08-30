using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using teste.Binding;
using MPI;

namespace teste.impl.BindingImpl 
{ 
	public class IPeerRightImpl : BaseIPeerRightImpl, IPeerRight
	{
		#region IPeerRight implementation
		public void doSomething (int v)
		{
			int r = this.RootCommunicator.Allreduce (v, sum);	
			Console.WriteLine ("RIGHT CALCULATED " + r);
		}
		#endregion

		private int sum(int a, int b) { return a + b; }
	}
}
