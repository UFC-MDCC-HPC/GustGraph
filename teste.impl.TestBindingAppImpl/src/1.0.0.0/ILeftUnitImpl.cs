using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using teste.TestBindingApp;
using System.Threading;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;

namespace teste.impl.TestBindingAppImpl
{
	public class ILeftUnitImpl : BaseILeftUnitImpl, ILeftUnit
	{
		public override void main()
		{
			Console.WriteLine (this.PeerRank + ": HELLO ! I AM LEFT !");

			//Thread.Sleep (10000);
			string s = this.PeerRank + " --- Hello from LEFT to RIGHT ";
			Console.WriteLine (this.PeerRank + "- BEGIN left sent " + s + " to <1," + this.PeerRank + ">");

/*			// SEND ARRAY
			this.Binding.Send<string> (new string[1]{s + " 0"}, new Tuple<int,int> (1, this.PeerRank), 0);
			this.Binding.Send<string> (new string[1]{s + " 1"}, new Tuple<int,int> (1, this.PeerRank), 1);

			// SEND SINGLETON
			this.Binding.Send<string> (s + " 2", new Tuple<int,int> (1, this.PeerRank), 2);
			this.Binding.Send<string> (s + " 3", new Tuple<int,int> (1, this.PeerRank), 3);
*/
			// SEND IMMEDIATE ARRAY
			Request r0 = this.Binding.ImmediateSend<string> (new string[1]{s + " 0 - immediate"}, new Tuple<int,int> (1, this.PeerRank), 44);
			Request r1 = this.Binding.ImmediateSend<string> (new string[1]{s + " 1 - immediate"}, new Tuple<int,int> (1, this.PeerRank), 55);

			// SEND IMMEDIATE SINGLETON
			Request r2 = this.Binding.ImmediateSend<string> (s + " 2 - immediate", new Tuple<int,int> (1, this.PeerRank), 66);
			Request r3 = this.Binding.ImmediateSend<string> (s + " 3 - immediate", new Tuple<int,int> (1, this.PeerRank), 77);

			CompletedStatus t0 = r0.Wait ();
			CompletedStatus t1 = r1.Wait ();
			CompletedStatus t2 = r2.Wait ();
			CompletedStatus t3 = r3.Wait ();

			Console.WriteLine (this.PeerRank + "- END   left sent " + s + " to <1,"
			                   + t0.Source + "/" + t0.Tag + "/" + t0.Cancelled + "/" + t0.Count() + "-" 
			                   + t1.Source + "/" + t1.Tag + "/" + t0.Cancelled + "/" + t0.Count() + "-" 
			                   + t2.Source + "/" + t2.Tag + "/" + t0.Cancelled + "/" + t0.Count() + "-" 
			                   + t3.Source + "/" + t3.Tag + "/" + t0.Cancelled + "/" + t0.Count() + ">");
		}
	}
}
