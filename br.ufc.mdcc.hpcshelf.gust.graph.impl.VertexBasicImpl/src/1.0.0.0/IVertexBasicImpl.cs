using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.gust.graph.Vertex;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;

namespace br.ufc.mdcc.hpcshelf.gust.graph.impl.VertexBasicImpl 
{
	public class IVertexBasicImpl : BaseIVertexBasicImpl, IVertexBasic 
	{

		public IVertexBasicImpl () { }

		override public void after_initialize () {
			newInstance (); 
		}

		public IVertexInstance newInstance (int i) {
			IVertexBasicInstance instance = (IVertexBasicInstance)newInstance ();
			instance.Id = i;
			return instance;
		}

		public object newInstance () {
			this.instance = new IVertexBasicInstanceImpl ();
			return this.Instance;
		}

		private IVertexBasicInstance instance;

		public object Instance {
			get { return instance; }
			set { this.instance = (IVertexBasicInstance)value; }
		}
		public IVertexInstance VInstance {
			get { return instance; }
		}
	}

	[Serializable]
	public class IVertexBasicInstanceImpl : IVertexBasicInstance {

		#region IVertexBasicInstance implementation
		private int val;
		private byte pid = 0;

		public int Id {
			get { return val; }
			set { this.val = value; }
		}
		public byte PId {
			get { return pid; }
			set { this.pid = (byte)value; }
		}

		public object ObjValue {
			get { return val; }
			set { this.val = (int)value; }
		}

		public override string ToString () {
			return Id.ToString ();
		}

		public override int GetHashCode () {
			return pairingFunction(this.Id, this.PId);
		}
		public override bool Equals (object obj) {
			if (typeof(IVertexBasicInstance).IsAssignableFrom (obj.GetType ()))
				return (this.Id == ((IVertexBasicInstance)obj).Id && this.PId == ((IVertexBasicInstance)obj).PId);
			return false;
		}
		public int pairingFunction (int a, int b) {
			var A = (ulong)(a >= 0 ? 2 * (long)a : -2 * (long)a - 1);
			var B = (ulong)(b >= 0 ? 2 * (long)b : -2 * (long)b - 1);
			var C = (long)((A >= B ? A * A + A + B : A + B * B) / 2);
			var R = a < 0 && b < 0 || a >= 0 && b >= 0 ? C : -C - 1;
			return (int)R;
		}
		#endregion

		#region ICloneable implementation
		public object Clone () {
			IVertexBasicInstance clone = new IVertexBasicInstanceImpl ();
			clone.Id = this.Id;
			clone.PId = this.PId;
			return clone;
		}
		#endregion
	}
}
