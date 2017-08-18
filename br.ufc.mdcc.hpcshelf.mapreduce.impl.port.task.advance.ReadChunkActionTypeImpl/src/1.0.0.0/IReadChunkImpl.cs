using System;
using br.ufc.mdcc.hpc.storm.binding.task.ActionType;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.ReadChunkActionType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.port.task.advance.ReadChunkActionTypeImpl
{
    public class IReadChunkImpl : BaseIReadChunkImpl, IReadChunk
	{
		public override void on_initialize()
		{
			Console.WriteLine("ON INITIALIZE READ_CHUNK NAME");
			ActionTags.action_tags[READ_CHUNK.name] = 20;
		}
	}
}
