using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using teste.TestTaskBindingInternal4;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortTypeExample;
using System.Threading;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingExample;

namespace teste.TestTaskBindingInternal4Impl
{
	public class ILeftUnitDImpl : BaseILeftUnitDImpl, ILeftUnitD{
		public override void main()	{
			writeFile ("./LOG-ILeftUnitDImpl.TXT",this.PeerRank+": INICIO ILeftUnitDImpl", false);
			ITaskPort<ITaskPortTypeExample> task_port = Task_port;

			Console.WriteLine (this.PeerRank + ": BEFORE LEFT INVOKE");

			IActionFuture action_future_0;
			Thread t0 = task_port.invoke (ITaskPortExampleAction.ACTION_0, reaction0, out action_future_0);

			IActionFuture action_future_1;
			Thread t1 = task_port.invoke (ITaskPortExampleAction.ACTION_1, reaction1, out action_future_1);

			IActionFuture action_future_2;
			Thread t2 = task_port.invoke (ITaskPortExampleAction.ACTION_2, reaction2, out action_future_2);

			IActionFutureSet action_future_set = action_future_0.createSet ();
			action_future_set.addAction (action_future_1);
			action_future_set.addAction (action_future_2);

			//	action_future_set.waitAll ();
			while (action_future_set.Pending.Length > 0) {
				IActionFuture action_future = action_future_set.waitAny ();
				Console.WriteLine (this.PeerRank + ": LEFT WAIT ANY");
			}

			Console.WriteLine (this.PeerRank + ": AFTER LEFT WAIT");

			t0.Join ();
			t1.Join ();
			t2.Join ();

			Console.WriteLine (this.PeerRank + ": AFTER LEFT INVOKE");
			writeFile ("./LOG-ILeftUnitDImpl.TXT","FIM ILeftUnitDImpl", true);
		}
		void reaction0(){
			Thread.Sleep(6000);
			Console.WriteLine(this.PeerRank + ": LEFT REACTION 0");
		}
		void reaction1(){
			Thread.Sleep(5000);
			Console.WriteLine(this.PeerRank + ": LEFT REACTION 1");
		}
		void reaction2(){
			Thread.Sleep(7000);
			Console.WriteLine(this.PeerRank + ": LEFT REACTION 2");
		}
		public static void writeFile(string PATH, string saida, bool manter){ 
			using (System.IO.StreamWriter file = new System.IO.StreamWriter (@PATH, manter)) {
				file.WriteLine (saida);
			}
		}
	}
}