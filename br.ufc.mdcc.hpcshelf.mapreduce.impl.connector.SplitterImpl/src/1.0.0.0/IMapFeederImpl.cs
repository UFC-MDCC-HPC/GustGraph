using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsServer;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.SplitterImpl
{
	public class IMapFeederImpl<S> : BaseIMapFeederImpl<S>, IMapFeeder<S>
where S:IEnvironmentPortTypeTakePairsServer
	{
		public override void main()
		{
		}
	}
}
