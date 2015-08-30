using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using teste.TestTaskBindingInternal;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBinding;
using System.Threading;

namespace teste.impl.TestTaskBindingInternalImpl
{
	public class ILeftUnitImpl : BaseILeftUnitImpl, ILeftUnit
	{
		public override void main()
		{
			ITaskPort<TestTaskPortType> task_port = Task_binding.TaskPort;

			Console.WriteLine (this.PeerRank + ": BEFORE LEFT INVOKE");

			IActionFuture action_future_0;
			Thread t0 = task_port.invoke (TestTaskPortType.ACTION_0, reaction0, out action_future_0);

			IActionFuture action_future_1;
			Thread t1 = task_port.invoke (TestTaskPortType.ACTION_1, reaction1, out action_future_1);

			IActionFuture action_future_2;
			Thread t2 = task_port.invoke (TestTaskPortType.ACTION_2, reaction2, out action_future_2);

			IActionFutureSet action_future_set = action_future_0.createSet ();
			action_future_set.addAction (action_future_1);
			action_future_set.addAction (action_future_2);

		//	action_future_set.waitAll ();
			while (action_future_set.Pending.Length > 0) 
			{
				IActionFuture action_future = action_future_set.waitAny ();
				Console.WriteLine (this.PeerRank + ": LEFT WAIT ANY");
			}

			Console.WriteLine (this.PeerRank + ": AFTER LEFT WAIT");

			t0.Join ();
			t1.Join ();
			t2.Join ();

			Console.WriteLine (this.PeerRank + ": AFTER LEFT INVOKE");
		}
		void reaction0()
		{
			Thread.Sleep(6000);
			Console.WriteLine(this.PeerRank + ": LEFT REACTION 0");
		}
		void reaction1()
		{
			Thread.Sleep(5000);
			Console.WriteLine(this.PeerRank + ": LEFT REACTION 1");
		}
		void reaction2()
		{
			Thread.Sleep(7000);
			Console.WriteLine(this.PeerRank + ": LEFT REACTION 2");
		}
	}
}
