using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsClient;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Shuffle;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.ShuffleImpl
{
	public class IShuffleLeftImpl<C, PF, OMK> : BaseIShuffleLeftImpl<C, PF, OMK>, IShuffleLeft<C, PF, OMK>
where C:IEnvironmentPortTypeTakePairsClient
where PF:IPartitionFunction<OMK>
where OMK:IData
	{
		public override void main()
		{
		}
	}
}
