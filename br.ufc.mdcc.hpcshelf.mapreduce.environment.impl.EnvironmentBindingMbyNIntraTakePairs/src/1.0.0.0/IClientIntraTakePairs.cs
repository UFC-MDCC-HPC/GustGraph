using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingMbyNIntra;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsClient;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.impl.EnvironmentBindingMbyNIntraTakePairs
{
	public class IClientIntraTakePairs : BaseIClientIntraTakePairs<IEnvironmentPortTypeTakePairsClient>, IClientMbyNIntra<IEnvironmentPortTypeTakePairsClient>
	{
		public override void main()
		{
		}
		public IEnvironmentPortTypeTakePairsClient Service{ get { return null; }  }
	}
}
