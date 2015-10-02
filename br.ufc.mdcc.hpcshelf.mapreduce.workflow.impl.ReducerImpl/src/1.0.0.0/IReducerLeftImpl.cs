using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsClient;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.ReduceFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Reducer;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.ReducerImpl
{
	public class IReducerLeftImpl<C, RF, OMK, OMV, ORK, ORV> : BaseIReducerLeftImpl<C, RF, OMK, OMV, ORK, ORV>, IReducerLeft<C, RF, OMK, OMV, ORK, ORV>
where C:IEnvironmentPortTypeTakePairsClient
where RF:IReduceFunction<OMK, OMV, ORK, ORV>
where OMK:IData
where OMV:IData
where ORK:IData
where ORV:IData
	{
		public override void main()
		{
		}
	}
}
