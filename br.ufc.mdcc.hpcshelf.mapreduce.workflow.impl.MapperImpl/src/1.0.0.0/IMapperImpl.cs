using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.MapFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsClient;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsServer;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Mapper;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.MapperImpl
{
	public class IMapperImpl<M, IMK, IMV, OMK, OMV, C, S, P> : BaseIMapperImpl<M, IMK, IMV, OMK, OMV, C, S, P>, IMapper<M, IMK, IMV, OMK, OMV, C, S, P>
where M:IMapFunction<IMK, IMV, OMK, OMV>
where IMK:IData
where IMV:IData
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
