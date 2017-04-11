/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.ChunkReadyActionType;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvanceChunkReady;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.port.task.TaskPortTypeAdvanceChunkReadyImpl 
{
	public abstract class BaseITaskPortTypeAdvanceChunkReadyImpl: br.ufc.pargo.hpe.kinds.Environment, BaseITaskPortTypeAdvanceChunkReady
	{
		private IChunkReady chunk_ready = null;

		protected IChunkReady Chunk_ready
		{
			get
			{
				if (this.chunk_ready == null)
					this.chunk_ready = (IChunkReady) Services.getPort("chunk_ready");
				return this.chunk_ready;
			}
		}
	}
}