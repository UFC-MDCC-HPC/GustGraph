using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.hpcshelf.gust.example.tc.TC1;
using br.ufc.mdcc.hpcshelf.gust.graph.UndirectedGraph;
using br.ufc.mdcc.hpcshelf.gust.graph.container.DataContainerV;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;
using br.ufc.mdcc.hpcshelf.gust.graph.Edge;
using br.ufc.mdcc.hpcshelf.gust.graph.EdgeBasic;
using br.ufc.mdcc.hpcshelf.gust.example.tc.DataTriangle;
using br.ufc.mdcc.hpcshelf.gust.graph.InputFormat;

namespace br.ufc.mdcc.hpcshelf.gust.example.tc.TC1Impl {
	public class ITC1Impl : BaseITC1Impl, ITC1 {

		private IUndirectedGraphInstance<IVertexBasic, IEdgeBasic<IVertexBasic>, int, IEdgeInstance<IVertexBasic, int>> g = null;
		private int[] partition = null;
		private bool[]  partition_own = null;
		private int partid = 0;
		private int partition_size = 0;
		private int count = 0;
		private IDictionary<int, IList<int>> InMessages = new Dictionary<int, IList<int>>();
		private IDictionary<int, IList<int>> OutMessages = new Dictionary<int, IList<int>>();
		private IList<IInputFormatInstance> OutGifs = new List<IInputFormatInstance> ();
		public bool isGhost(int v){ return !partition_own[this.partition [v - 1]]; }

		public override void main() { this.input_messages (); }
		#region Create Undirected Graph
		public void graph_creator(IInputFormatInstance gif, int tcount){
			if (partition_own==null){
				partition = gif.PartitionTABLE;
				partid = gif.PARTID;
				partition_size = gif.PARTITION_SIZE;
				g = Graph.newInstance (gif.VSIZE); // pega-se uma instancia do graph, com vertices do tipo inteiro, com tamanho previsto VSIZE
				g.DataContainer.AllowingLoops = false; // não serão premitidos laços
				g.DataContainer.AllowingMultipleEdges = false; // não serão permitidas múltiplas arestas
				partition_own = new bool[partition_size];
			}
			partition_own [gif.PARTID] = true;
			for (int i = 0; i < gif.ESIZE;) {
				if (gif.Target [i] != 0) { // Será usada a forma canonica: i->j, onde i<j, i>0 j>0
					int s = gif.Source [i] < gif.Target [i] ? gif.Source [i] : gif.Target [i];
					int t = gif.Target [i] > gif.Source [i] ? gif.Target [i] : gif.Source [i];
					g.addVertex (s);
					g.addVertex (t);
					g.noSafeAdd (s, t);
					i++;
				}
			}
			OutGifs.Add (gif);
			count = count + tcount;
		}
		#endregion

		#region Algorithm implementation
		public void input_messages(){
			IKVPairInstance<IVertexBasic,IIterator<IDataTriangle>> input_values_instance = (IKVPairInstance<IVertexBasic,IIterator<IDataTriangle>>)Input_values.Instance;
			IVertexBasicInstance ikey = (IVertexBasicInstance)input_values_instance.Key;
			IIteratorInstance<IDataTriangle> ivalues = (IIteratorInstance<IDataTriangle>)input_values_instance.Value;

			object o; int w = ikey.Id;
			while (ivalues.fetch_next (out o)) {
				IDataTriangleInstance dt = ((IDataTriangleInstance)o);
				if (dt.Count >= 0)
					this.graph_creator ((IInputFormatInstance) dt.Value, dt.Count);
				else {
					IList<int> tri = (IList<int>)dt.Value;
					foreach (int v in tri) {
						IList<int> l;
						if (!InMessages.TryGetValue (w, out l)) {
							l = new List<int> ();
							InMessages[w] = l;
						}
						l.Add (v);
					}
				}
			}
		}

		public void gust0(){
			foreach (KeyValuePair<int, IList<int>> TRI in InMessages) {
				int w = TRI.Key;
				IEnumerator<int> wneighbors = g.iteratorNeighborsOf (w);
				while (wneighbors.MoveNext ()) {
					int vw = wneighbors.Current;
					if (w < vw) {
						foreach (int v in TRI.Value) {
							IList<int> l;
							if (!OutMessages.TryGetValue (v, out l)) {
								l = new List<int> ();
								OutMessages[v] = l;
							}
							l.Add (vw);
						}
					}
				}
			}
			emitter ();
		}
		public void emitter(){
			IIteratorInstance<IKVPair<IVertexBasic,IDataTriangle>> output_value = (IIteratorInstance<IKVPair<IVertexBasic,IDataTriangle>>)Output_messages.Instance;
			foreach (KeyValuePair<int, IList<int>> TRI in OutMessages) {
				IKVPairInstance<IVertexBasic,IDataTriangle> item = (IKVPairInstance<IVertexBasic,IDataTriangle>)Output_messages.createItem ();
				((IVertexBasicInstance)item.Key).Id = TRI.Key;
				((IVertexBasicInstance)item.Key).PId = (byte)this.partition [TRI.Key - 1];
				((IDataTriangleInstance)item.Value).Value = TRI.Value;
				((IDataTriangleInstance)item.Value).Count = -1;
				output_value.put (item);
			}
			foreach (IInputFormatInstance gif in OutGifs) {
				IKVPairInstance<IVertexBasic,IDataTriangle> item_own = (IKVPairInstance<IVertexBasic,IDataTriangle>)Output_messages.createItem ();
				((IVertexBasicInstance)item_own.Key).Id = gif.PARTID;
				((IVertexBasicInstance)item_own.Key).PId = (byte)gif.PARTID;
				((IDataTriangleInstance)item_own.Value).Count = count;
				((IDataTriangleInstance)item_own.Value).Value = gif;
				count = 0;
				output_value.put (item_own);
			}
			output_value.finish ();
			InMessages.Clear ();
			OutMessages.Clear ();
		}
		#endregion
	}
}

