using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeMultiplePartner;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.CombineFunction;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.computation.Combiner
{
	public interface ICombinerLeft<C, CF, OMK, OMV> : BaseICombinerLeft<C, CF, OMK, OMV>
		where C:IEnvironmentPortTypeMultiplePartner
		where CF:ICombineFunction<OMK, OMV>
		where OMK:IData
		where OMV:IData
	{
	}
}