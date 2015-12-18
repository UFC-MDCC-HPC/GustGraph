using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.Base.EnvironmentPortTypeWriteDataClient;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.Base.EnvironmentPortTypeWriteDataServer;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.hpcshelf.mapreduce.datasource.DataSink;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.datasource.DataSinkImpl
{
	public class IDataSinkImpl<OUT, C, S, P> : BaseIDataSinkImpl<OUT, C, S, P>, IDataSink<OUT, C, S, P>
where OUT:IData
where C:IEnvironmentPortTypeWriteDataClient
where S:IEnvironmentPortTypeWriteDataServer
where P:IPlatform
	{
		public override void main()
		{
		}
	}
}
