using br.ufc.pargo.hpe.kinds;
using System.Collections.Generic;

namespace br.ufc.mdcc.hpc.storm.binding.task.ActionType
{
	public interface IActionType : BaseIActionType
	{
	}

	public class ActionTags
	{
		public static IDictionary<string, int> action_tags = new Dictionary<string, int>();
	}


}