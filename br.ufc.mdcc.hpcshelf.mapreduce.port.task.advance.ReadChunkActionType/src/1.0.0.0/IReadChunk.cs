using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.ActionType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.ReadChunkActionType
{
	public interface IReadChunk : BaseIReadChunk, IActionType
	{
	}
	
	public class READ_CHUNK
	{
		public const string name = "READ_CHUNK";
	}
}