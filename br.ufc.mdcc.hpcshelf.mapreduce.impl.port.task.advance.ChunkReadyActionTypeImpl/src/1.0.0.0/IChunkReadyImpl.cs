using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.ChunkReadyActionType;
using br.ufc.mdcc.hpc.storm.binding.task.ActionType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.port.task.advance.ChunkReadyActionTypeImpl
{
	public class IChunkReadyImpl : BaseIChunkReadyImpl, IChunkReady
	{
		public override void on_initialize ()
		{
			Console.WriteLine ("ON INITIALIZE CHUNK_READY NAME");
			ActionTags.action_tags [CHUNK_READY.name] = 21;
		}
	}
}
