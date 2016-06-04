using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.TerminateFunction
{
	public interface ITerminateFunction<IMK, IMV, ORK, ORV> : BaseITerminateFunction<IMK, IMV, ORK, ORV>
		where IMK:IData
		where IMV:IData
		where ORK:IData
		where ORV:IData
	{	
		IPortTypeIterator Iterate_pairs { set; }
	}
}