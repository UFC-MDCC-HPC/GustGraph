using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsServer;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Shuffle;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.ShuffleImpl
{
	public class IShuffleRightImpl<S> : BaseIShuffleRightImpl<S>, IShuffleRight<S>
where S:IEnvironmentPortTypeTakePairsServer
	{
		public override void main()
		{
		}
	}
}
