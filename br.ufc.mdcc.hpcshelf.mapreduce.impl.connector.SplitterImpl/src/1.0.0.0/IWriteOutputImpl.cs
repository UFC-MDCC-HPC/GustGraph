using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.Base.EnvironmentPortTypeWriteDataClient;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.SplitterImpl
{
	public class IWriteOutputImpl<OUT, DWC> : BaseIWriteOutputImpl<OUT, DWC>, IWriteOutput<OUT, DWC>
where OUT:IData
where DWC:IEnvironmentPortTypeWriteDataClient
	{
		public override void main()
		{
		}
	}
}
