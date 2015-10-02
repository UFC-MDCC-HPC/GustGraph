using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsServer;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Reducer;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.ReducerImpl
{
	public class IReducerRightImpl<S> : BaseIReducerRightImpl<S>, IReducerRight<S>
where S:IEnvironmentPortTypeTakePairsServer
	{
		public override void main()
		{
		}
	}
}
