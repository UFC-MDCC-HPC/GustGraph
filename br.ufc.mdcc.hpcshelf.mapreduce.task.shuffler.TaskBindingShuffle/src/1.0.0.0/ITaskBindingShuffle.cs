using br.ufc.pargo.hpe.kinds;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.TaskBindingShuffle
{
	public interface ITaskBindingShuffle : BaseITaskBindingShuffle
	{
	}
	public class ITaskBindingShuffleAction
	{
		public static object READ_CHUNK_I = new object();
		public static object PARTITION = new object();
		public static object CHUNK_READY_J = new object();
	}
}