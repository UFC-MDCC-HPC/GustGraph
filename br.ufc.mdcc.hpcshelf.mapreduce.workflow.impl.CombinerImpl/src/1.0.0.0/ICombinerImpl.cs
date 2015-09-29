using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsClient;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsServer;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Combiner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.CombinerImpl
{
	public class ICombinerImpl<OMK, OMV, C, S, P> : BaseICombinerImpl<OMK, OMV, C, S, P>, ICombiner<OMK, OMV, C, S, P>
where OMK:IData
where OMV:IData
where C:IEnvironmentPortTypeTakePairsClient
where S:IEnvironmentPortTypeTakePairsServer
where P:IPlatform
	{
		public override void main()
		{
		}
	}
}
