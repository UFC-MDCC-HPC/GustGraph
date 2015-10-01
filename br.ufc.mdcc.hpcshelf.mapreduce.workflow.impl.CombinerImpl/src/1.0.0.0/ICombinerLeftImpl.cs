using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsClient;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.CombineFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Combiner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.CombinerImpl
{
	public class ICombinerLeftImpl<C, CF, OMK, OMV> : BaseICombinerLeftImpl<C, CF, OMK, OMV>, ICombinerLeft<C, CF, OMK, OMV>
where C:IEnvironmentPortTypeTakePairsClient
where CF:ICombineFunction<OMK, OMV>
where OMK:IData
where OMV:IData
	{
		public override void main()
		{
		}
	}
}
