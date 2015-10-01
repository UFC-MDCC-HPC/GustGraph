using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsServer;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Combiner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.CombinerImpl
{
	public class ICombinerRightImpl<S> : BaseICombinerRightImpl<S>, ICombinerRight<S>
where S:IEnvironmentPortTypeTakePairsServer
	{
		public override void main()
		{
		}
	}
}
