using br.ufc.pargo.hpe.kinds;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.reducer.TaskBindingReduce
{
	public interface ITaskBindingReduce : BaseITaskBindingReduce
	{
	}
	public class ITaskBindingReduceAction
	{
		public static object READ_CHUNK = new object();
		public static object PARTITION = new object();
		public static object CHUNK_READY = new object();
	}
}