/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.MapFunction
{
	public interface BaseIMapFunction : IComputationKind 
	{
	}
	
public interface BaseIMapFunction<IMK, IMV, OMK, OMV> : IComputationKind 
		where IMK:IData
		where IMV:IData
		where OMK:IData
		where OMV:IData
{
	IMK Input_key {get;}
	IMV Input_value {get;}
}

}