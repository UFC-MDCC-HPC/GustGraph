using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingMbyNIntra;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsServer;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.impl.EnvironmentBindingMbyNIntraTakePairs
{
	public class IServerIntraTakePairs : BaseIServerIntraTakePairs<IEnvironmentPortTypeTakePairsServer>, IServerMbyNIntra<IEnvironmentPortTypeTakePairsServer>
	{
		public override void main()
		{
		}
		public IEnvironmentPortTypeTakePairsServer Service{ set {  }  }
	}
}
