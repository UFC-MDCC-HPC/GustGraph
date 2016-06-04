using br.ufc.pargo.hpe.kinds;

namespace br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingData
{
	public interface ITaskBindingData : BaseITaskBindingData
	{
	}

	public class ITaskPortData 
	{
		public static object READ_SOURCE = new object();
		public static object TERMINATE = new object();
		public static object WRITE_SINK = new object();
	}
}