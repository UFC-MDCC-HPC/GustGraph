using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;

namespace br.ufc.mdcc.hpcshelf.workflow.environment.SWLPortType
{
	public interface ISWLPortType : BaseISWLPortType, IEnvironmentPortTypeSinglePartner
	{
	   string Workflow { get; }
	}
}