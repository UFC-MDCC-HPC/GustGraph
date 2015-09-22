using br.ufc.pargo.hpe.kinds;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitter
{
	public interface ITaskBindingSplitter : BaseITaskBindingSplitter
	{
	}
	public class ITaskBindingSplitterAction
	{
		public static object READ_SOURCE = new object();
		public static object READ_CHUNK_J = new object();
		public static object PARTITION = new object();
				
		public static object CHUNK_READY_I = new object();
		public static object WRITE_SINK = new object();
		public static object TERMINATE = new object();
	}
}