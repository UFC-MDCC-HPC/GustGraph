using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.workflow.environment.SWLWorkflowBinding;
using br.ufc.mdcc.hpcshelf.workflow.environment.SWLPortType;
using System.Threading;

namespace br.ufc.mdcc.hpcshelf.workflow.impl.environment.SWLWorkflowBindingImpl
{
	public class ISWLWorkflowBindingImpl : BaseISWLWorkflowBindingImpl, ISWLWorkflowBinding
	{
		public override void main()
		{
		}

        private ManualResetEvent e = new ManualResetEvent(false);

		public ISWLPortType Client { get {	e.WaitOne (); return server; } }

		private ISWLPortType server = null;
		public ISWLPortType Server { set { e.Set ();	server = value; } }

	}
}
