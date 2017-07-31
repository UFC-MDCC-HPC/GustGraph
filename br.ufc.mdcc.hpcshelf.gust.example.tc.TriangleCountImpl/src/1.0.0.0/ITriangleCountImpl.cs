using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.hpcshelf.gust.example.tc.TriangleCount;
using br.ufc.mdcc.hpcshelf.gust.graph.DirectedGraph;
using br.ufc.mdcc.hpcshelf.gust.graph.container.DataContainerV;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;
using br.ufc.mdcc.hpcshelf.gust.graph.Edge;
using br.ufc.mdcc.hpcshelf.gust.graph.EdgeBasic;
using br.ufc.mdcc.hpcshelf.gust.example.tc.DataTriangle;
using br.ufc.mdcc.hpcshelf.gust.graph.InputFormat;

namespace br.ufc.mdcc.hpcshelf.gust.example.tc.TriangleCountImpl {
	public class ITriangleCountImpl : BaseITriangleCountImpl, ITriangleCount {

		private IDirectedGraphInstance<IVertexBasic, IEdgeBasic<IVertexBasic>, int, IEdgeInstance<IVertexBasic, int>> g = null;
		private int[] partition = null;
		private bool[]  partition_own = null;
		private int partid = 0;
		private int partition_size = 0;
		private int count = 0;
		private IDictionary<int, IList<int>>[] OutMessages = null;
		private IDictionary<int, ICollection<int>> Neighbors = new Dictionary<int, ICollection<int>>();
		public bool isGhost(int v){ return !partition_own[this.partition [v - 1]]; }

		public override void main() { this.input_messages (); }
		#region Create Undirected Graph
		public void graph_creator(IInputFormatInstance gif){
			if (partition_own==null){
				partition = gif.PartitionTABLE;
				partid = gif.PARTID;
				partition_size = gif.PARTITION_SIZE;
				g = Graph.newInstance (gif.VSIZE); // pega-se uma instancia do graph, com vertices do tipo inteiro, com tamanho previsto VSIZE
				g.DataContainer.AllowingLoops = false; // não serão premitidos laços
				g.DataContainer.AllowingMultipleEdges = false; // não serão permitidas múltiplas arestas
				partition_own = new bool[partition_size];
				OutMessages = new Dictionary<int, IList<int>>[partition_size];
				for (int i = 0; i < partition_size; i++)
					OutMessages [i] = new Dictionary<int, IList<int>> ();
			}
			partition_own [gif.PARTID] = true;
			for (int i = 0; i < gif.ESIZE;) {
				if (gif.Target [i] != 0) { // Será usada a forma canonica: i->j, onde i<j, i>0 j>0
					int s = gif.Source [i] < gif.Target [i] ? gif.Source [i] : gif.Target [i];
					int t = gif.Target [i] > gif.Source [i] ? gif.Target [i] : gif.Source [i];
					g.addVertex (s);
					g.addVertex (t);
					if(s!=t) g.noSafeAdd (s, t);
					i++;
				}
			}
			gif.Clear ();
		}
		#endregion

		#region Algorithm implementation
		public void startup(){
			IEnumerator<int> V = g.vertexSet ().GetEnumerator ();
			while (V.MoveNext ()) {
				int v = V.Current;
				if (!isGhost(v)) {
					ICollection<int> vneighbors = g.outgoingVertexOf (v); // TODO: dá erro pois deve-se trocar o tipo do grafo, de undirected para directed
					foreach (int w in vneighbors) {
						if (v < w) {
							if (isGhost(w)) {
								IList<int> l;
								if (!OutMessages[partition[w-1]].TryGetValue (w, out l)) {
									l = new List<int> ();
									OutMessages[partition[w-1]][w] = l;
								}
								l.Add (v);
								if (!Neighbors.ContainsKey (v))
									Neighbors [v] = vneighbors;
							} else {
								//								IEnumerator<int> wneighbors = g.iteratorOutgoingVertexOf (w);
								//								while (wneighbors.MoveNext ()) {
								//									int wz = wneighbors.Current;
								ICollection<int> wneighbors = null;// = g.iteratorOutgoingVertexOf(w);
								if (!Neighbors.TryGetValue (w, out wneighbors))
									wneighbors = Neighbors [w] = g.outgoingVertexOf (w); //emited.Add (w);
								foreach(int wz in wneighbors){
									if (w < wz && vneighbors.Contains (wz)) {
										count++;
									}
								}
							}
						}
					}
				}
			}
		}

		public void input_messages(){
			IKVPairInstance<IVertexBasic,IIterator<IDataTriangle>> input_values_instance = (IKVPairInstance<IVertexBasic,IIterator<IDataTriangle>>)Input_values.Instance;
			IIteratorInstance<IDataTriangle> ivalues = (IIteratorInstance<IDataTriangle>)input_values_instance.Value;

			object o;
			while (ivalues.fetch_next (out o)) {
				IDataTriangleInstance dt = ((IDataTriangleInstance)o);
				if (this.Superstep == 0)
					this.graph_creator ((IInputFormatInstance)dt.Value);
				else {
					Block bin = (Block)dt.Value;
					if (this.Superstep == 1) {
						for (int k = 0; k < bin.SIZE; k++) {
							int w = bin.Keys [k];
							ICollection<int> wneighbors = null;// = g.iteratorOutgoingVertexOf(w);
							if (!Neighbors.TryGetValue (w, out wneighbors))
								wneighbors = Neighbors [w] = g.outgoingVertexOf (w); //emited.Add (w);
							foreach (int wz in wneighbors) {
								if (w < wz) {
									foreach (int v in bin.Values[k]) {
										IList<int> l;
										if (!OutMessages [partition [v - 1]].TryGetValue (v, out l)) {
											l = new List<int> ();
											OutMessages [partition [v - 1]] [v] = l;
										}
										l.Add (wz);
									}
								}
							}
						}
					} else {
						for (int k = 0; k < bin.SIZE; k++) {
							int v = bin.Keys [k];
							foreach (int wz in bin.Values[k]) {
								if (Neighbors [v].Contains (wz)) {
									count++;
								}
							}
						}
					}
				}
			}
		}

		public void gust0(){
			if (this.Superstep == 0)
				this.startup ();
			emitter ();
		}

		public void emitter(){
			IIteratorInstance<IKVPair<IVertexBasic,IDataTriangle>> output_value = (IIteratorInstance<IKVPair<IVertexBasic,IDataTriangle>>)Output_messages.Instance;
			for (int p = 0; p < partition_size; p++) {
				IDictionary<int, IList<int>> block = OutMessages [p];
				if (block.Count > 0) {
					Block bin = new Block(OutMessages[p].Count);
					int count = 0;
					IKVPairInstance<IVertexBasic,IDataTriangle> item = (IKVPairInstance<IVertexBasic,IDataTriangle>)Output_messages.createItem ();
					((IVertexBasicInstance)item.Key).Id = p;
					((IVertexBasicInstance)item.Key).PId = (byte) p;
					foreach (KeyValuePair<int, IList<int>> kv in block) {
						bin.Keys [count] = kv.Key;
						bin.Values[count++] = kv.Value.ToArray ();
					}
					((IDataTriangleInstance)item.Value).Value = bin;
					output_value.put (item);
					OutMessages [p] = new Dictionary<int, IList<int>> ();
				}
			}
			if (this.Superstep == 2) {
				IKVPairInstance<IVertexBasic,IDataTriangle> item = (IKVPairInstance<IVertexBasic,IDataTriangle>)Output_messages.createItem ();
				((IVertexBasicInstance)item.Key).Id = partid;
				((IVertexBasicInstance)item.Key).PId = (byte)partid;
				((IDataTriangleInstance)item.Value).Count = count;
				output_value.put (item);
				output_value.finish ();
			}
		}
		[Serializable]
		public class Block{
			public int SIZE = 0;
			public int[] Keys;
			public int[][] Values;
			public Block(int size){
				this.SIZE = size;
				this.Keys = new int[size];
				this.Values = new int[size][];
			}
		}
		#endregion
	}
}

