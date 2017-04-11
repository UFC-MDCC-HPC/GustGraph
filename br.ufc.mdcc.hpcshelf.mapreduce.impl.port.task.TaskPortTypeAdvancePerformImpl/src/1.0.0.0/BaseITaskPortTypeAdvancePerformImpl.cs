/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.PerformActionType;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvancePerform;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.port.task.TaskPortTypeAdvancePerformImpl 
{
	public abstract class BaseITaskPortTypeAdvancePerformImpl: br.ufc.pargo.hpe.kinds.Environment, BaseITaskPortType
	{
		private IPerform perform = null;

		protected IPerform Perform
		{
			get
			{
				if (this.perform == null)
					this.perform = (IPerform) Services.getPort("perform");
				return this.perform;
			}
		}
	}
}