using br.ufc.pargo.hpe.kinds;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitterRead
{
	public interface ITaskBindingSplitterRead : BaseITaskBindingSplitterRead
	{
	}
	public class ITaskBindingSplitterReadAction
	{
		public static object PARTITION = new object();
		public static object READ_SOURCE = new object();
	}
}