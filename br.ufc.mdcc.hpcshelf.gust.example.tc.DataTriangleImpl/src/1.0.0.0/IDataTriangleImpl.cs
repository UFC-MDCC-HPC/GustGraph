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

		object _value = null;
		public object Value {
		   get { return this._value; }
		   set { this._value = value; }
		}
		public int V {
			get { return (int)this.Value; }
			set { this.Value = (int) value; }
		}

		public object ObjValue {
			get { return new Tuple<object>(this._value); }
			set {
				this._value = ((Tuple<object>)value).Item1;
			}
		}
		public override int GetHashCode () { return this.Value.GetHashCode(); }
		public override string ToString () { return this.Value.ToString(); }

		public override bool Equals (object obj) {
			if (obj is IDataTriangleInstanceImpl)
				return ( ((IDataTriangleInstanceImpl)obj).Value.Equals(this.Value) );
			else
				return false;
		}
		#endregion

		#region ICloneable implementation

		public object Clone () {
			IDataTriangleInstance clone = new IDataTriangleInstanceImpl ();
			clone.Value = this.Value;
			return clone;
		}

		#endregion

	}


}
