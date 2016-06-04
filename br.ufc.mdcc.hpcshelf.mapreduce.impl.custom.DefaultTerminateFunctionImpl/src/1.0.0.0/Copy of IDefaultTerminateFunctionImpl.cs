using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.TerminateFunction;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.custom.DefaultTerminateFunctionImpl
{
	public class IDefaultTerminateFunctionImpl<IMK,IMV,ORK,ORV> : BaseIDefaultTerminateFunctionImpl<IMK,IMV,ORK,ORV>, ITerminateFunction<IMK, IMV, ORK, ORV>
where IMK:IData
where IMV:IData
where ORK:IData
where ORV:IData
	{
		private IPortTypeIterator iterate_pairs = null;
		public IPortTypeIterator Iterate_pairs { set {this.iterate_pairs = value; } }

		public override void main()
		{
			IIteratorInstance<IKVPair<ORK, ORV>> output_pairs = (IIteratorInstance<IKVPair<ORK, ORV>>)Output_pairs.Instance;

			// All pairs are sent to the output, i.e. the algorithm is not iterative.
			object pair;
			while (iterate_pairs.fetch_next(out pair))
				output_pairs.put(pair);
		}
	}
}
