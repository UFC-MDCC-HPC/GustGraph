// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.17020
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using br.ufc.mdcc.hpcshelf.platform.maintainer.SAFeHost;
using br.ufc.mdcc.hpcshelf.workflow.environment.SWLWorkflowBinding;
using mapreduce.gust.tc3.Workflow;

namespace mapreduce.gust.tc3.WorkflowImpl
{
    public class IWorkflowImpl<M> : br.ufc.pargo.hpe.kinds.Workflow, IWorkflow<M>
        where M : ISAFeHost
    {
        public override void main()
        {
            Console.WriteLine("WORKFLOW IMPL !!!");
            this.SWLOrchestration = SWLPort.Client.Workflow;
            base.main();
        }

        private ISWLWorkflowBinding swl_port = null;
        private ISWLWorkflowBinding SWLPort
        {
            get
            {
                return swl_port == null ? (ISWLWorkflowBinding)this.Services.getPort("swl_port") : swl_port;
            }
        }
    }
}
