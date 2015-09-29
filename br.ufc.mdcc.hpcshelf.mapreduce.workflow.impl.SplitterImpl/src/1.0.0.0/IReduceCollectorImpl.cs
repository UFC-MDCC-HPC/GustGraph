using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsClient;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Splitter;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.SplitterImpl
{
	public class IReduceCollectorImpl<C> : BaseIReduceCollectorImpl<C>, IReduceCollector<C>
where C:IEnvironmentPortTypeTakePairsClient
	{
		public override void main()
		{
		}
	}
}
