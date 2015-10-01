using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.ReduceFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsClient;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsServer;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Reducer;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.ReducerImpl
{
	public class IReducerImpl<RF, OMK, OMV, ORK, ORV, C, S, P> : BaseIReducerImpl<RF, OMK, OMV, ORK, ORV, C, S, P>, IReducer<RF, OMK, OMV, ORK, ORV, C, S, P>
where RF:IReduceFunction<OMK, OMV, ORK, ORV>
where OMK:IData
where OMV:IData
where ORK:IData
where ORV:IData
where C:IEnvironmentPortTypeTakePairsClient
where S:IEnvironmentPortTypeTakePairsServer
where P:IPlatform
	{
		public override void main()
		{
		}
	}
}
