using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.hpcshelf.gust.graph.OutputFormat;

namespace br.ufc.mdcc.hpcshelf.gust.graph.OutputFormatDefaultImpl
{
	public class IOutputFormatDefaultImpl<IKey, IValue> : BaseIOutputFormatDefaultImpl<IKey, IValue>, IOutputFormat<IKey, IValue>
where IKey:IData
where IValue:IData
	{
		override public void after_initialize()
		{
			newInstance();
		}
		public object newInstance ()
		{
			IIteratorInstance<IKVPair<IKey,IValue>> output_instance = (IIteratorInstance<IKVPair<IKey,IValue>>)this.Output_pairs.Instance;
			return this.Instance = new IOutputFormatInstanceImpl<IKey,IValue> (output_instance);
		}
		private IOutputFormatInstance<IKey,IValue> instance;

		public object Instance {
			get { return instance;	}
			set { this.instance = (IOutputFormatInstance<IKey,IValue>) value;	}
		}
	}

	[Serializable]
	public class IOutputFormatInstanceImpl<IKey,IValue> : IOutputFormatInstance<IKey,IValue>
		where IKey:IData
		where IValue:IData
	{
		public IOutputFormatInstanceImpl(object _iterator)
		{
			this.iterator = (IIteratorInstance<IKVPair<IKey,IValue>>) _iterator;
		}

		#region IOutputFormatInstance implementation

		private object iterator;

		public object Iterator {
			get { return this.iterator; }
		}

		public object ObjValue {
			get { return new Tuple<object>(this.iterator); }
			set
			{
				this.iterator = ((Tuple<object,object>)value).Item1;
			}
		}

		public string formatRepresentation(object kv_pair){
			IKVPairInstance<IKey,IValue> kv = (IKVPairInstance<IKey,IValue>)kv_pair;
			return kv.Key.ToString() + ":" + kv.Value.ToString();
		}

		#endregion

		#region ICloneable implementation

		public object Clone ()
		{
			IOutputFormatInstance<IKey,IValue> clone = new IOutputFormatInstanceImpl<IKey,IValue>(((ICloneable)this.iterator).Clone());

			return clone;
		}

		#endregion

	}

}
