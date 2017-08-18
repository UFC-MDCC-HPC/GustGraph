using System;
using br.ufc.mdcc.hpc.storm.binding.task.ActionType;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.PerformActionType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.port.task.advance.PerformActionTypeImpl
{
    public class IPerformImpl : BaseIPerformImpl, IPerform
	{
		public override void on_initialize()
		{
			Console.WriteLine("ON INITIALIZE PERFORM NAME");
			ActionTags.action_tags[PERFORM.name] = 22;
		}
	}
}
