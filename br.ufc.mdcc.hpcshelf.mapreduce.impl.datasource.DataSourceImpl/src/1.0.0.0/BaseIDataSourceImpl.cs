/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.Base.EnvironmentPortTypeReadDataServer;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.Base.EnvironmentPortTypeReadDataClient;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.DataSource;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.DataSourceImpl 
{
	public abstract class BaseIDataSourceImpl<IN, C, S, P>: Computation, BaseIDataSource<IN, C, S, P>
		where IN:IData
		where C:IEnvironmentPortTypeReadDataClient
		where S:IEnvironmentPortTypeReadDataServer
		where P:IPlatform
	{
		private P platform = default(P);

		protected P Platform
		{
			get
			{
				if (this.platform == null)
					this.platform = (P) Services.getPort("platform");
				return this.platform;
			}
		}
		private C client_type = default(C);

		protected C Client_type
		{
			get
			{
				if (this.client_type == null)
					this.client_type = (C) Services.getPort("client_type");
				return this.client_type;
			}
		}
		private IN data_type = default(IN);

		public IN Data_type
		{
			get
			{
				if (this.data_type == null)
					this.data_type = (IN) Services.getPort("data_type");
				return this.data_type;
			}
		}
		private IServerBase<S> reader = null;

		protected IServerBase<S> Reader
		{
			get
			{
				if (this.reader == null)
					this.reader = (IServerBase<S>) Services.getPort("reader");
				return this.reader;
			}
		}
	}
}