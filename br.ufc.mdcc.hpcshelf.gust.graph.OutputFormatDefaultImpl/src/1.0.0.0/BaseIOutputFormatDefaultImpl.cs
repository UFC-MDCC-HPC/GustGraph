/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.gust.graph.OutputFormat;

namespace br.ufc.mdcc.hpcshelf.gust.graph.OutputFormatDefaultImpl
{
	public abstract class BaseIOutputFormatDefaultImpl<IKey, IValue>: DataStructure, BaseIOutputFormat<IKey, IValue>
		where IKey:IData
		where IValue:IData
	{
		private IIterator<IKVPair<IKey, IValue>> output_format_pairs = null;

		protected IIterator<IKVPair<IKey, IValue>> Output_format_pairs
		{
			get
			{
				if (this.output_format_pairs == null)
					this.output_format_pairs = (IIterator<IKVPair<IKey, IValue>>) Services.getPort("output_format_pairs");
				return this.output_format_pairs;
			}
		}
	}
}