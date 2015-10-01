using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsClient;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.MapFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Mapper;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.MapperImpl
{
	public class IMapperLeftImpl<C, MF, IMK, IMV, OMK, OMV> : BaseIMapperLeftImpl<C, MF, IMK, IMV, OMK, OMV>, IMapperLeft<C, MF, IMK, IMV, OMK, OMV>
where C:IEnvironmentPortTypeTakePairsClient
where MF:IMapFunction<IMK, IMV, OMK, OMV>
where IMK:IData
where IMV:IData
where OMK:IData
where OMV:IData
	{
		public override void main()
		{
		}
	}
}
