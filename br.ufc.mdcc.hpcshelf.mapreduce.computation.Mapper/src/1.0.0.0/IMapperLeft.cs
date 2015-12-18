using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.MapFunction;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.computation.Mapper
{
	public interface IMapperLeft<C, MF, IMK, IMV, OMK, OMV> : BaseIMapperLeft<C, MF, IMK, IMV, OMK, OMV>
		where C:IEnvironmentPortTypeMultiplePartner
		where MF:IMapFunction<IMK, IMV, OMK, OMV>
		where IMK:IData
		where IMV:IData
		where OMK:IData
		where OMV:IData
	{
	}
}