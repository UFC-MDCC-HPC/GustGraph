using System;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.gust.example.pgr.DataPGRANK;

namespace br.ufc.mdcc.hpcshelf.gust.example.pgr.DataPGRANKImpl
{
	public class IDataPGRANKImpl : BaseIDataPGRANKImpl, IDataPGRANK {

		public IDataPGRANKImpl () { }

		override public void after_initialize () {
			newInstance ();
		}

		public object newInstance () {
			this.instance = new IDataPGRANKInstanceImpl ();
			return this.Instance;
		}

		private IDataPGRANKInstance instance;

		public object Instance {
			get { return instance; }
			set { this.instance = (IDataPGRANKInstance)value; }
		}
		public IDataPGRANKInstance InstanceDataPGRANK {
			get { return instance; }
		}
	}

	[Serializable]
	public class IDataPGRANKInstanceImpl : IDataPGRANKInstance {

		#region IDataPGRANKInstance implementation

		private IDictionary<int, double> ranks = new Dictionary<int, double>();
		private double slice = 0.0f;

		public IDataPGRANKInstanceImpl(){ }

		object _value = null;
		public object Value {
		   get { return this._value; }
		   set { this._value = value; }
		}

		public IDictionary<int, double> Ranks {
			get { return this.ranks; }
			set { this.ranks = (IDictionary<int, double>) value; }
		}

		public double Slice {
			get { return this.slice; }
			set { this.slice = (double) value; }
		}

		public object ObjValue {
			get { return new Tuple<IDictionary<int, double>, double, object>(this.ranks, this.slice, this._value); }
			set {
				this.ranks = ((Tuple<IDictionary<int, double>, double, object>)value).Item1;
				this.slice = ((Tuple<IDictionary<int, double>, double, object>)value).Item2;
				this._value = ((Tuple<IDictionary<int, double>, double, object>)value).Item3;
			}
		}

		public override string ToString () {
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			IEnumerator<KeyValuePair<int, double>> iterator = this.Ranks.GetEnumerator ();
			if (iterator.MoveNext ()) {
				sb.Append (iterator.Current.Key + ":" + iterator.Current.Value);
				while (iterator.MoveNext ())
					sb.Append (System.Environment.NewLine+iterator.Current.Key + ":" + iterator.Current.Value);
			}
			string r = sb.ToString ();
			sb.Clear ();
			return r;
		}

		#endregion

		#region ICloneable implementation
		public object Clone () {
			IDataPGRANKInstance clone = new IDataPGRANKInstanceImpl ();
			clone.Ranks = new Dictionary<int, double> (this.Ranks);
			clone.Slice = this.slice;
			clone.Value = this._value;
			return clone;
		}
		#endregion
	}
}
