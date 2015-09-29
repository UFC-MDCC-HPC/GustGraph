using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.SplitFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.Base.EnvironmentPortTypeReadDataClient;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Splitter;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.SplitterImpl
{
	public class IReadInputImpl<SF, IMK, IMV, IN, BF, DSC> : BaseIReadInputImpl<SF, IMK, IMV, IN, BF, DSC>, IReadInput<SF, IMK, IMV, IN, BF, DSC>
where SF:ISplitFunction<IMK, IMV, IN>
where IMK:IData
where IMV:IData
where IN:IData
where BF:IPartitionFunction<IMK>
where DSC:IEnvironmentPortTypeReadDataClient
	{
		public override void main()
		{
		}
	}
}
