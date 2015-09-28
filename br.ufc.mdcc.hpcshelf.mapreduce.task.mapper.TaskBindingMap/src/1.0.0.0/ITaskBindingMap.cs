using br.ufc.pargo.hpe.kinds;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.mapper.TaskBindingMap
{
	public interface ITaskBindingMap : BaseITaskBindingMap
	{
	}
	public class ITaskBindingMapAction
	{
		public static object READ_CHUNK = new object();
		public static object PERFORM = new object();
		public static object CHUNK_READY = new object();
	}
}