using System;
using mapreduce.countwords.System;
using mapreduce.countwords.Workflow;
using System.Threading;
using mapreduce.countwords.Application;
using br.ufc.mdcc.hpcshelf.platform.maintainer.SAFeHost;
using br.ufc.pargo.hpe.kinds;

namespace mapreduce.countwords.SystemImpl
{
	public class IRootImpl : br.ufc.pargo.hpe.kinds.Application, IRoot
	{
		private void Go(Object o) {
			((Activate)(o)).go();
		}

		public override void main()
		{
			//IWorkflow<ISAFeHost> workflow = ((IWorkflow<ISAFeHost>)(this.Services.getPort("workflow")));
			//Thread go_workflow = new Thread(new ParameterizedThreadStart(this.Go));
			//go_workflow.Start(workflow);
			//IApplication<ISAFeHost> application = ((IApplication<ISAFeHost>)(this.Services.getPort("application")));
			//Thread go_application = new Thread(new ParameterizedThreadStart(this.Go));
			//go_application.Start(application);
			//go_workflow.Join();
			//go_application.Join();

			//Console.WriteLine ("FINISH ROOT");
			//AutoResetEvent e = new AutoResetEvent (false);
			//e.WaitOne ();
		}
	}
}
