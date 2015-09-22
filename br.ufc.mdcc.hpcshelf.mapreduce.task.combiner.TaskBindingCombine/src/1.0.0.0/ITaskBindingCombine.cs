using br.ufc.pargo.hpe.kinds;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.combiner.TaskBindingCombine
{
	public interface ITaskBindingCombine : BaseITaskBindingCombine
	{
	}
	public class ITaskBindingCombineAction
	{
		public static object READ_CHUNK = new object();
		public static object PARTITION = new object();
		public static object CHUNK_READY = new object();
	}
}