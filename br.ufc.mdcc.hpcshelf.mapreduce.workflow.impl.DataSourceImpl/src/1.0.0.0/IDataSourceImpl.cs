using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.Base.EnvironmentPortTypeReadDataClient;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.Base.EnvironmentPortTypeReadDataServer;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.DataSource;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.DataSourceImpl
{
	public class IDataSourceImpl<IN, C, S, P> : BaseIDataSourceImpl<IN, C, S, P> , IDataSource<IN, C, S, P>
where IN:IData
where C:IEnvironmentPortTypeReadDataClient
where S:IEnvironmentPortTypeReadDataServer
where P:IPlatform
	{
		public override void main()
		{
		}
	}
}
