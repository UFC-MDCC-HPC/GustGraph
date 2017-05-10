using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.ActionType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.PerformActionType
{
	public interface IPerform : BaseIPerform, IActionType
	{
	}
	public class PERFORM
	{
		public const string name = "PERFORM";
	}
}