/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.Base.EnvironmentPortTypeWriteDataServer;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.Base.EnvironmentPortTypeWriteDataClient;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.DataSink;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.DataSinkImpl 
{
	public abstract class BaseIDataSinkImpl<OUT, C, S, P>: Computation, BaseIDataSink<OUT, C, S, P>
		where OUT:IData
		where C:IEnvironmentPortTypeWriteDataClient
		where S:IEnvironmentPortTypeWriteDataServer
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
		private IServerBase<S> writer = null;

		protected IServerBase<S> Writer
		{
			get
			{
				if (this.writer == null)
					this.writer = (IServerBase<S>) Services.getPort("writer");
				return this.writer;
			}
		}
		private OUT data_type = default(OUT);

		public OUT Data_type
		{
			get
			{
				if (this.data_type == null)
					this.data_type = (OUT) Services.getPort("data_type");
				return this.data_type;
			}
		}
	}
}