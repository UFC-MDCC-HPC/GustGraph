/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.ReadChunkActionType;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvanceReadChunk;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.ReadChunkActionType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.port.task.TaskPortTypeAdvanceReadChunkImpl 
{
	public abstract class BaseITaskPortTypeAdvanceReadChunkImpl: br.ufc.pargo.hpe.kinds.Environment, BaseITaskPortType
	{
		private IReadChunk read_chunk = null;

		protected IReadChunk Read_chunk
		{
			get
			{
				if (this.read_chunk == null)
					this.read_chunk = (IReadChunk) Services.getPort("read_chunk");
				return this.read_chunk;
			}
		}
	}
}