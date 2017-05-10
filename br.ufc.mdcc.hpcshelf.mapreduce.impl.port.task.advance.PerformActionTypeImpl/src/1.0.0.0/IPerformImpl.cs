using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.PerformActionType;
using br.ufc.mdcc.hpc.storm.binding.task.ActionType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.port.task.advance.PerformActionTypeImpl
{
	public class IPerformImpl : BaseIPerformImpl, IPerform
	{
		public override void on_initialize ()
		{
			Console.WriteLine ("ON INITIALIZE PERFORM NAME");
			ActionTags.action_tags [PERFORM.name] = 22;
		}
	}
}
