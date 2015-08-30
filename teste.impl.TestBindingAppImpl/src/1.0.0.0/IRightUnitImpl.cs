using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using teste.TestBindingApp;
//using MPI;
using System.Threading;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;

namespace teste.impl.TestBindingAppImpl
{
	public class IRightUnitImpl : BaseIRightUnitImpl, IRightUnit
	{
		public override void main()
		{
			Console.WriteLine(this.PeerRank + ": HELLO ! I AM RIGHT !!!");

/*			// RECEIVE ARRAY
			Tuple<int,int> source0 = new Tuple<int,int> (0, this.PeerRank);
			string[] s0 = new string[1]; this.Binding.Receive<string> (source0, 0, ref s0);
			Console.WriteLine (this.PeerRank + "- RECEIVED right "  + s0 + " from " + source0);

			Tuple<int,int> source1 = new Tuple<int,int> (0, this.PeerRank);
			string[] s1 = new string[1]; this.Binding.Receive<string> (source1, 1, ref s1);
			Console.WriteLine (this.PeerRank + "- RECEIVED right "  + s1 + " from " + source1);

			// RECEIVE SINGLETON
			Tuple<int,int> source2 = new Tuple<int,int> (0, this.PeerRank);
			string s2 = this.Binding.Receive<string> (source2, 2);
			Console.WriteLine (this.PeerRank + "- RECEIVED right "  + s2 + " from " + source2);

			Tuple<int,int> source3 = new Tuple<int,int> (0, this.PeerRank);
			string s3 = this.Binding.Receive<string> (source3, 3);
			Console.WriteLine (this.PeerRank + "- RECEIVED right "  + s3 + " from " + source3);
*/
			// -------------------------------

			// RECEIVE IMMEDIATE ARRAY
			string[] b0 = new string[1];
			Tuple<int,int> source4 = new Tuple<int,int> (0, this.PeerRank);
			ReceiveRequest r0 = this.Binding.ImmediateReceive<string> (source4, 44, b0);

			string[] b1 = new string[1];
			Tuple<int,int> source5 = new Tuple<int,int> (0, this.PeerRank);
			ReceiveRequest r1 = this.Binding.ImmediateReceive<string> (source5, 55, b1);
		
			// RECEIVE IMMEDIATE SINGLETON
			Tuple<int,int> source6 = new Tuple<int,int> (0, this.PeerRank);
			ReceiveRequest r2 = this.Binding.ImmediateReceive<string> (source6, 66);

			Tuple<int,int> source7 = new Tuple<int,int> (0, this.PeerRank);
			ReceiveRequest r3 = this.Binding.ImmediateReceive<string> (source7, 77);


			CompletedStatus t0 = r0.Wait ();
			string[] s4 = r0.GetValue () as string[];
			Console.WriteLine (this.PeerRank + "- RECEIVED right "  + b0[0] + " from " + t0.Source + " tag=" + t0.Tag + " cancelled=" + t0.Cancelled + " count=" + t0.Count());

			CompletedStatus t1 = r1.Wait ();
			string[] s5 = r1.GetValue () as string[];
			Console.WriteLine (this.PeerRank + "- RECEIVED right "  + b1[0] + " from " + t1.Source + " tag=" + t1.Tag + " cancelled=" + t1.Cancelled + " count=" + t1.Count());

			CompletedStatus t2 = r2.Wait ();
			string s6 = r2.GetValue () as string;
			Console.WriteLine (this.PeerRank + "- RECEIVED right "  + s6 + " from " + t2.Source + " tag=" + t2.Tag + " cancelled=" + t2.Cancelled + " count=" + t2.Count());

			CompletedStatus t3 = r3.Wait ();
			string s7 = r3.GetValue () as string;
			Console.WriteLine (this.PeerRank + "- RECEIVED right "  + s7 + " from " + t3.Source + " tag=" + t3.Tag + " cancelled=" + t3.Cancelled + " count=" + t3.Count());
		}
	}
}
