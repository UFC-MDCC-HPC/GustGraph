using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.ReadChunkActionType;
using br.ufc.mdcc.hpc.storm.binding.task.ActionType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.port.task.advance.ReadChunkActionTypeImpl
{
	public class IReadChunkImpl : BaseIReadChunkImpl, IReadChunk
	{
		public override void on_initialize ()
		{
			Console.WriteLine ("ON INITIALIZE READ_CHUNK NAME");
			ActionTags.action_tags [READ_CHUNK.name] = 20;
		}
	}
}
