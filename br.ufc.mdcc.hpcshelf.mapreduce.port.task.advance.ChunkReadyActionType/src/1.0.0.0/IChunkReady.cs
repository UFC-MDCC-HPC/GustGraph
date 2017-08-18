using br.ufc.pargo.hpe.kinds;

namespace br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.ChunkReadyActionType
{
    public interface IChunkReady : BaseIChunkReady
    {
    }

    public class CHUNK_READY
    {
        public const string name = "CHUNK_READY";
    }
}