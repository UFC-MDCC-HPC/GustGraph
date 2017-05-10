using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.task.ActionType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.ChunkReadyActionType
{
	public interface IChunkReady : BaseIChunkReady, IActionType
	{
	}
	
	public class CHUNK_READY
	{
		public const string name = "CHUNK_READY";
	}
}