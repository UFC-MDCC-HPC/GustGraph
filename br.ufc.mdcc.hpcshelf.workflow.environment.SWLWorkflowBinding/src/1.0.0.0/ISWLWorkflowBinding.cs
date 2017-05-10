using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBaseDirect;
using br.ufc.mdcc.hpcshelf.workflow.environment.SWLPortType;

namespace br.ufc.mdcc.hpcshelf.workflow.environment.SWLWorkflowBinding
{
	public interface ISWLWorkflowBinding : BaseISWLWorkflowBinding, IBindingDirect<ISWLPortType,ISWLPortType>
	{
	}
}