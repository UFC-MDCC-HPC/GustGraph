/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.TerminateFunction;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.custom.DefaultTerminateFunctionImpl 
{
	public abstract class BaseIDefaultTerminateFunctionImpl<IMK,IMV,ORK,ORV>: Computation, BaseITerminateFunction<IMK, IMV, ORK, ORV>
		where IMK:IData
		where IMV:IData
		where ORK:IData
		where ORV:IData
	{
		private IIterator<IKVPair<ORK, ORV>> output_pairs = null;

		public IIterator<IKVPair<ORK, ORV>> Output_pairs
		{
			get
			{
				if (this.output_pairs == null)
					this.output_pairs = (IIterator<IKVPair<ORK, ORV>>) Services.getPort("output_pairs");
				return this.output_pairs;
			}
		}

/*		private IPortTypeIterator iterate_pairs = null;

		protected IPortTypeIterator Iterate_pairs
		{
			get
			{
				if (this.iterate_pairs == null)
					this.iterate_pairs = (IPortTypeIterator) Services.getPort("iterate_pairs");
				return this.iterate_pairs;
			}
		}
*/
		private IIterator<IKVPair<IMK, IMV>> input_pairs = null;

		public IIterator<IKVPair<IMK, IMV>> Input_pairs
		{
			get
			{
				if (this.input_pairs == null)
					this.input_pairs = (IIterator<IKVPair<IMK, IMV>>) Services.getPort("input_pairs");
				return this.input_pairs;
			}
		}
	}
}