using br.ufc.pargo.hpe.kinds;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitterWrite
{
	public interface ITaskBindingSplitterWrite : BaseITaskBindingSplitterWrite
	{
	}
	public class ITaskBindingSplitterWriteAction
	{
		public static object WRITE_SINK = new object();
	}
}