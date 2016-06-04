using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvance
{
	public interface ITaskPortTypeAdvance : BaseITaskPortTypeAdvance, ITaskPortType
	{
	}

	public class ITaskPortExampleAction 
	{
		public static object ACTION_0 = new object();
		public static object ACTION_1 = new object();
		public static object ACTION_2 = new object();
	}
}