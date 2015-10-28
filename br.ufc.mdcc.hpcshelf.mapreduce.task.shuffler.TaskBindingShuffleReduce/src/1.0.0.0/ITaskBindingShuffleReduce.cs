using br.ufc.pargo.hpe.kinds;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.TaskBindingShuffleReduce
{
	public interface ITaskBindingShuffleReduce : BaseITaskBindingShuffleReduce
	{
	}
	public class ITaskBindingShuffleReduceAction
	{
		public static object READ_CHUNK = new object();
		public static object PROCESS = new object();
	}
}