/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.workflow.environment.SWLWorkflowBinding;
using br.ufc.mdcc.hpcshelf.workflow.environment.SWLPortType;

namespace br.ufc.mdcc.hpcshelf.workflow.impl.environment.SWLWorkflowBindingImpl 
{
	public abstract class BaseISWLWorkflowBindingImpl: Synchronizer, BaseISWLWorkflowBinding
	{
		private ISWLPortType client_port_type = null;

		protected ISWLPortType Client_port_type
		{
			get
			{
				if (this.client_port_type == null)
					this.client_port_type = (ISWLPortType) Services.getPort("client_port_type");
				return this.client_port_type;
			}
		}
		private ISWLPortType server_port_type = null;

		protected ISWLPortType Server_port_type
		{
			get
			{
				if (this.server_port_type == null)
					this.server_port_type = (ISWLPortType) Services.getPort("server_port_type");
				return this.server_port_type;
			}
		}
	}
}