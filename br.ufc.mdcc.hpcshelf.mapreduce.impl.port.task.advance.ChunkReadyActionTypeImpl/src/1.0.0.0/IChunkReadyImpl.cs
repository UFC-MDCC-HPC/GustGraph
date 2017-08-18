using System;
using br.ufc.mdcc.hpc.storm.binding.task.ActionType;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.ChunkReadyActionType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.port.task.advance.ChunkReadyActionTypeImpl
{
    public class IChunkReadyImpl : BaseIChunkReadyImpl, IChunkReady
	{
		public override void on_initialize()
		{
			Console.WriteLine("ON INITIALIZE CHUNK_READY NAME");
			ActionTags.action_tags[CHUNK_READY.name] = 21;
		}
	}
}
