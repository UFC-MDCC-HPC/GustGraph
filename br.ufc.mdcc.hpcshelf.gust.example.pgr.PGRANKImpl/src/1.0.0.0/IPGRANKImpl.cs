using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.hpcshelf.gust.graph.InputFormat;
using br.ufc.mdcc.hpcshelf.gust.example.pgr.DataPGRANK;
using br.ufc.mdcc.hpcshelf.gust.example.pgr.PGRANK;
using br.ufc.mdcc.hpcshelf.gust.graph.Graph;
using br.ufc.mdcc.hpcshelf.gust.graph.DirectedGraph;
using br.ufc.mdcc.hpcshelf.gust.graph.container.DataContainer;
using br.ufc.mdcc.hpcshelf.gust.graph.container.DataContainerKV;
using br.ufc.mdcc.hpcshelf.gust.graph.Vertex;
using br.ufc.mdcc.hpcshelf.gust.graph.Edge;
using br.ufc.mdcc.hpcshelf.gust.graph.EdgeWeighted;

namespace br.ufc.mdcc.hpcshelf.gust.example.pgr.PGRANKImpl {
	public class IPGRANKImpl : BaseIPGRANKImpl, IPGRANK {

		private IDirectedGraphInstance<IVertex, IEdgeWeighted<IVertex>, int, IEdgeInstance<IVertex, int>> g = null;
		private int[] partition = null;
		private bool[]  partition_own = null;
		private int partition_size = 0;
		private float nothing_outgoing = 0;
		private float sum_nothings = 0.0f;
		private int partid = 0;
		private int MAX_ITERATION = 30;
		IDictionary<int, float> before = null;
		private IDictionary<int, float>[] messages = null;
		public bool isGhost(int v){ return !partition_own[this.partition [v - 1]]; }

		public override void main() { this.input_messages (); }
		#region Create Directed Graph Weight
		public void graph_creator(IInputFormatInstance gif){
			if (partition_own==null){
				partition = gif.PartitionTABLE;
				partition_size = gif.PARTITION_SIZE;
				g = Graph.newInstance (gif.VSIZE);
				g.DataContainer.AllowingLoops = false;
				g.DataContainer.AllowingMultipleEdges = false;
				partition_own = new bool[partition_size];
				this.partid = gif.PARTID;
			}
			for (int i = 0; i < gif.ESIZE;i++) {
				int s = gif.Source [i];
				int t = gif.Target [i];
				g.addVertex (s);
				g.addVertex (t);
				g.addEdge (s, t);
			}
			partition_own [gif.PARTID] = true;
			gif.Clear ();
		}
		#endregion

		#region Algorithm implementation
		public void startup() {
			before = new Dictionary<int, float>(g.countV()+1);
			messages = new Dictionary<int, float>[partition_size];
			for (int i = 0; i < partition_size; i++) messages[i] = new Dictionary<int, float> ();

			ICollection<int> vertices = g.vertexSet ();
			foreach (int v in vertices) {
				if (!messages [partition [v - 1]].ContainsKey (v)) messages [partition [v - 1]] [v] = 0.0f;
				if (!isGhost (v)) {
					bool any = false;
					before [v] = 0.0f;
					IEnumerator<int> n = g.iteratorOutgoingVertexOf (v);
					while (n.MoveNext ()) {
						any = true;
						if (!messages [partition [n.Current - 1]].ContainsKey (n.Current)) messages [partition [n.Current - 1]] [n.Current] = 0.0f;
						messages [partition [n.Current - 1]] [n.Current] += 1.0f / g.outDegreeOf (v);
					}
					if (!any) nothing_outgoing+=1.0f;
				}
			}
		}
		public void input_messages() {
			IKVPairInstance<IInteger,IIterator<IDataPGRANK>> input_values_instance = (IKVPairInstance<IInteger,IIterator<IDataPGRANK>>)Input_values.Instance;
			IIntegerInstance ikey = (IIntegerInstance)input_values_instance.Key;
			IIteratorInstance<IDataPGRANK> ivalues = (IIteratorInstance<IDataPGRANK>)input_values_instance.Value;

			object o;
			while (ivalues.fetch_next (out o)) {
				IDataPGRANKInstance VALUE = (IDataPGRANKInstance)o;
				if (this.Superstep == 0)
					this.graph_creator ((IInputFormatInstance)VALUE.Value);
				else {
					foreach (KeyValuePair<int, float> kv in VALUE.Ranks)
						messages [partition [kv.Key - 1]] [kv.Key] += kv.Value;
					sum_nothings += VALUE.Slice;
				}
			}
		}
		public void gust0(){
			if (this.Superstep == 0)
				this.startup ();
			else {
				IIteratorInstance<IKVPair<IInteger,IDataPGRANK>> output_value_instance = (IIteratorInstance<IKVPair<IInteger,IDataPGRANK>>)Output_messages.Instance;

				ICollection<int> vertices = g.vertexSet ();
				foreach (int v in vertices)
					if (!isGhost (v)) {
						before [v] = messages [partition [v - 1]] [v] + sum_nothings - before [v];
						messages [partition [v - 1]] [v] = before [v];
					}
				if (this.Superstep < MAX_ITERATION)
					foreach (int v in vertices) {
						if (!isGhost (v)) {
							bool any = false;
							IEnumerator<int> n = g.iteratorOutgoingVertexOf (v);
							while (n.MoveNext ()) {
								any = true;
								if (!messages [partition [n.Current - 1]].ContainsKey (n.Current))
									messages [partition [n.Current - 1]] [n.Current] = 0.0f;
								messages [partition [n.Current - 1]] [n.Current] += before [v] / g.outDegreeOf (v);
							}
							if (!any)
								nothing_outgoing += before [v];
						}
					}
			}
			emite ();
		}
		private void emite(){
			IIteratorInstance<IKVPair<IInteger,IDataPGRANK>> output_value_instance = (IIteratorInstance<IKVPair<IInteger,IDataPGRANK>>)Output_messages.Instance;
			if (this.Superstep == MAX_ITERATION) {
				output_value_instance.finish ();

				IKVPairInstance<IInteger,IDataPGRANK> ITEM = (IKVPairInstance<IInteger,IDataPGRANK>)Output_messages.createItem ();
				((IIntegerInstance)ITEM.Key).Value = this.partid;
				((IDataPGRANKInstance)ITEM.Value).Ranks = messages [((IIntegerInstance)ITEM.Key).Value];
				output_value_instance.put (ITEM);

			} else {
				for (int i = 0; i < partition_size; i++) {
					IKVPairInstance<IInteger,IDataPGRANK> ITEM = (IKVPairInstance<IInteger,IDataPGRANK>)Output_messages.createItem ();
					((IIntegerInstance)ITEM.Key).Value = i;

					if (partition_own [i])
						((IDataPGRANKInstance)ITEM.Value).Ranks = new Dictionary<int, float> ();
					else {
						((IDataPGRANKInstance)ITEM.Value).Ranks = messages [i];
						messages [i] = new Dictionary<int, float> ();
					}
					((IDataPGRANKInstance)ITEM.Value).Slice = nothing_outgoing / ((float)partition.Length);

					output_value_instance.put (ITEM);
				}
			}
			nothing_outgoing = 0.0f;
			sum_nothings = 0.0f;
		}
		#endregion
	}
}
