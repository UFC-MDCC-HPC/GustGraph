using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.TaskBindingShuffleMap;
using br.ufc.mdcc.hpc.storm.binding.task.TaskPortType;

namespace br.ufc.mdcc.hpcshelf.mapreduce.task.shuffler.impl.TaskBindingShuffleMapImpl
{
	public class ITaskBindingShuffleMapImpl : BaseITaskBindingShuffleMapImpl, ITaskBindingShuffleMap
	{
		public override void main()
		{
		}
		public override void on_initialize ()
		{
			ActionDef.action_ids[ITaskBindingShuffleMapAction.CHUNK_READY] = 2;
		}
	}
}
