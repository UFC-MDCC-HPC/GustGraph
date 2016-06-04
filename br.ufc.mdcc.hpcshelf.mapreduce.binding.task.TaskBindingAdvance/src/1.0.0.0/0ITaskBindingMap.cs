using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.mapper.TaskBindingMap
{
	public interface ITaskBindingMap<T> : BaseITaskBindingMap<T>
		where T:ITaskPortType
	{
	}
	public class ITaskBindingMapAction
	{
		public static object READ_CHUNK = new object();
		public static object PERFORM = new object();
		public static object CHUNK_READY = new object();
	}
}