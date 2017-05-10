using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;
using System.Threading;
using System;

namespace br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase
{
	public interface ITaskPort<T> : BaseITaskPort<T>
		where T:ITaskPortType
	{
	}
	
}