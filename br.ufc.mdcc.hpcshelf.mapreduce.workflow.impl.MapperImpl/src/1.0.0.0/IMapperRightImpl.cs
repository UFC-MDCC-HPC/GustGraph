using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsServer;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Mapper;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.MapperImpl
{
	public class IMapperRightImpl<S> : BaseIMapperRightImpl<S>, IMapperRight<S>
where S:IEnvironmentPortTypeTakePairsServer
	{
		public override void main()
		{
		}
	}
}
