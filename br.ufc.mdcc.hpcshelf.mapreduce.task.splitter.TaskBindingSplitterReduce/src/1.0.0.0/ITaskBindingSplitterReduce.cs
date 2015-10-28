using br.ufc.pargo.hpe.kinds;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitterReduce
{
	public interface ITaskBindingSplitterReduce : BaseITaskBindingSplitterReduce
	{
	}
	public class ITaskBindingSplitterReduceAction
	{
		public static object READ_CHUNK = new object();				
		public static object PARTITION = new object();
		public static object TERMINATE = new object();
	}
}