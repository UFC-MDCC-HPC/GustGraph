/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeDataSinkInterface;
using br.ufc.mdcc.hpcshelf.mapreduce.datasource.DataSink;
using br.ufc.mdcc.hpcshelf.platform.Maintainer;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.datasource.DataSinkImpl 
{
	public abstract class BaseIDataSinkImpl<P>: Computation, BaseIDataSink<P>
		where P:IMaintainer
	{
		private P platform_sink = default(P);

		protected P Platform_sink
		{
			get
			{
				if (this.platform_sink == null)
					this.platform_sink = (P) Services.getPort("platform_sink");
				return this.platform_sink;
			}
		}

		private IClientBase<IPortTypeDataSinkInterface> output_data = null;

		protected IClientBase<IPortTypeDataSinkInterface> Output_data
		{
			get
			{
				if (this.output_data == null)
					this.output_data = (IClientBase<IPortTypeDataSinkInterface>) Services.getPort("output_data");
				return this.output_data;
			}
		}
	}
}