using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.ReadChunkActionType;
using br.ufc.mdcc.hpc.storm.binding.task.ActionType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.port.task.advance.ReadChunkActionTypeImpl
{
	public class IReadChunkImpl : BaseIReadChunkImpl, IActionType
	{
		public override void on_initialize ()
		{
		}
	}
}
