using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.gust.example.tc.DataTriangle;

namespace br.ufc.mdcc.hpcshelf.gust.example.tc.DataTriangleImpl
{
	public class IDataTriangleImpl : BaseIDataTriangleImpl, IDataTriangle {
		public IDataTriangleImpl () {}

		override public void after_initialize () {
			newInstance ();
		}

		public object newInstance () {
			this.instance = new IDataTriangleInstanceImpl ();
			return this.Instance;
		}

		private IDataTriangleInstance instance;
		public object Instance {
			get { return instance; }
			set { this.instance = (IDataTriangleInstance)value; }
		}
	}

	[Serializable]
	public class IDataTriangleInstanceImpl : IDataTriangleInstance {
		#region IDataTriangleInstance implementation

		private object _value = null;
		public object Value {
		   get { return this._value; }
		   set { this._value = value; }
		}

		private int count = 0;
		public int Count {
			get { return (int)this.count; }
			set { this.count = (int) value; }
		}

		public object ObjValue {
			get { return new Tuple<object, int>(this.Value, this.Count); }
			set {
				this.Value = ((Tuple<object, int>)value).Item1;
				this.Count = ((Tuple<object, int>)value).Item2;
			}
		}
		public override int GetHashCode () { return pairingFunction (this.Value.GetHashCode(), this.Count); }
		public override string ToString () { return this.Count.ToString(); }
		public override bool Equals (object obj) {
			if (obj is IDataTriangleInstanceImpl)
				return ( ((IDataTriangleInstanceImpl)obj).Value.Equals(this.Value) && ((IDataTriangleInstanceImpl)obj).Count == this.Count);
			else
				return false;
		}
		public static int pairingFunction (int a, int b) {
			var A = (ulong)(a >= 0 ? 2 * (long)a : -2 * (long)a - 1);
			var B = (ulong)(b >= 0 ? 2 * (long)b : -2 * (long)b - 1);
			var C = (long)((A >= B ? A * A + A + B : A + B * B) / 2);
			var R = a < 0 && b < 0 || a >= 0 && b >= 0 ? C : -C - 1;
			return (int)R;
		}
		#endregion

		#region ICloneable implementation

		public object Clone () {
			IDataTriangleInstance clone = new IDataTriangleInstanceImpl ();
			clone.Value = this.Value;
			clone.Count = this.Count;
			return clone;
		}

		#endregion

	}


}
