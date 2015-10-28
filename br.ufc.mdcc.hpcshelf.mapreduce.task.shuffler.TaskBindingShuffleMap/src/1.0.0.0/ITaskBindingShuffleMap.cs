using br.ufc.pargo.hpe.kinds;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.TaskBindingShuffleMap
{
	public interface ITaskBindingShuffleMap : BaseITaskBindingShuffleMap
	{
	}
	public class ITaskBindingShuffleMapAction
	{
		public static object CHUNK_READY = new object();
	}
}