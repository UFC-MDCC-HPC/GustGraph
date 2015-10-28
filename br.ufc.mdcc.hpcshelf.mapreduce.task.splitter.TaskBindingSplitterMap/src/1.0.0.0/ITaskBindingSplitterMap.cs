using br.ufc.pargo.hpe.kinds;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitterMap
{
	public interface ITaskBindingSplitterMap : BaseITaskBindingSplitterMap
	{
	}
	public class ITaskBindingSplitterMapAction
	{
		public static object CHUNK_READY = new object();
	}
}