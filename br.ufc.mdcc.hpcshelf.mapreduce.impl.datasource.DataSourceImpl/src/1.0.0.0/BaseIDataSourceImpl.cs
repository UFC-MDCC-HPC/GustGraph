/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeDataSourceInterface;
using br.ufc.mdcc.hpcshelf.mapreduce.datasource.DataSource;
using br.ufc.mdcc.hpcshelf.platform.Maintainer;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.datasource.DataSourceImpl 
{
	public abstract class BaseIDataSourceImpl<P>: Computation, BaseIDataSource<P>
		where P:IMaintainer
	{
		private IServerBase<IPortTypeDataSourceInterface> input_data = null;

		protected IServerBase<IPortTypeDataSourceInterface> Input_data
		{
			get
			{
				if (this.input_data == null)
					this.input_data = (IServerBase<IPortTypeDataSourceInterface>) Services.getPort("input_data");
				return this.input_data;
			}
		}
		private P platform_source = default(P);

		protected P Platform_source
		{
			get
			{
				if (this.platform_source == null)
					this.platform_source = (P) Services.getPort("platform_source");
				return this.platform_source;
			}
		}
	}
}