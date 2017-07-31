using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.hpcshelf.gust.graph.InputFormat;
using br.ufc.mdcc.hpcshelf.gust.example.sssp.DataSSSP;
using br.ufc.mdcc.hpcshelf.gust.example.sssp.SSSP;
using br.ufc.mdcc.hpcshelf.gust.graph.Graph;
using br.ufc.mdcc.hpcshelf.gust.graph.DirectedGraph;
using br.ufc.mdcc.hpcshelf.gust.graph.container.DataContainer;
using br.ufc.mdcc.hpcshelf.gust.graph.container.DataContainerKV;
using br.ufc.mdcc.hpcshelf.gust.graph.Vertex;
using br.ufc.mdcc.hpcshelf.gust.graph.Edge;
using br.ufc.mdcc.hpcshelf.gust.graph.EdgeWeighted;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;

namespace br.ufc.mdcc.hpcshelf.gust.example.sssp.SSSPImpl {
	public class ISSSPImpl : BaseISSSPImpl, ISSSP {

		private IDirectedGraphInstance<IVertex, IEdgeWeighted<IVertex>, int, IEdgeInstance<IVertex, int>> g = null;
		private int[] partition = null;
		private bool[]  partition_own = null;
		private int partition_size = 0;
		private bool[] emite;
		private int partid = 0;
		private int halt_sum = 1;
		private IDictionary<int, float>[] messages = null;
		public bool isGhost(int v){ return !partition_own[this.partition [v - 1]]; }

		public override void main() { } //this.unroll (); }
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
			partition_own [gif.PARTID] = true;
			bool weighted = gif.Weight.Length==gif.Source.Length; float f=1.0f;
			for (int i = 0; i < gif.ESIZE;i++) {
				int s = gif.Source [i];
				int t = gif.Target [i];
				if(weighted) f = gif.Weight [i];
				g.addVertex (s);
				g.addVertex (t);
				if(s!=t) g.noSafeAdd (s, t, f);
				if (s == 0 || t==0) { throw new ArgumentNullException ("WARNING: Vertex id is 0! "); }
			}
			gif.Clear ();
		}
		#endregion

		#region Algorithm implementation
		public void startup() {
			int v = 1; float distance_min; emite = new bool[partition_size]; emite[this.partid] = true; // Prepara source vertex numero 1
			messages = new Dictionary<int, float>[partition_size]; //Preparar buffer de mensagens
			for (int i = 0; i < partition_size; i++)
				messages[i] = new Dictionary<int, float> ();

			if (g.containsVertex (v)) {
				messages[partition [v - 1]][v]=0f;
				Queue<int> queue = new Queue<int> (); queue.Enqueue (v);
				while (queue.Count > 0) { // Busca em profundidade
					v = queue.Dequeue ();
					float v_distance_min_candidate = messages[partition [v - 1]][v];
					IEnumerator<KeyValuePair<int, float>> vneighbors = g.iteratorVertexWeightOf (v); //g.iteratorOutgoingVertexWeightOf (v);
					while (vneighbors.MoveNext ()) {
						int n = vneighbors.Current.Key;
						float n_distance_min_candidate = vneighbors.Current.Value+v_distance_min_candidate;
						if (!messages [partition [n - 1]].TryGetValue(n,out distance_min) || distance_min > n_distance_min_candidate) {
							messages [partition [n - 1]] [n] = n_distance_min_candidate;
							queue.Enqueue (n);
							emite[partition [n - 1]] = true;
						}
					}
				}
			}
		}
		public void unroll() {
			IKVPairInstance<IVertexBasic,IIterator<IDataSSSP>> input_values_instance = (IKVPairInstance<IVertexBasic,IIterator<IDataSSSP>>)Input_values.Instance;
			IVertexBasicInstance ikey = (IVertexBasicInstance)input_values_instance.Key;
			IIteratorInstance<IDataSSSP> ivalues = (IIteratorInstance<IDataSSSP>)input_values_instance.Value;

			object o;
			float distance_min;
			while (ivalues.fetch_next (out o)) {
				IDataSSSPInstance VALUE = (IDataSSSPInstance)o;
				if (this.Superstep == 0)
					this.graph_creator ((IInputFormatInstance)VALUE.Value);
				else {
					halt_sum += VALUE.Halt;
					Block bin = (Block)VALUE.Value;
					for (int k = 0; k < bin.SIZE; k++) {//KeyValuePair<int, float> kv in VALUE.Path_size) {
						float v_distance_min_candidate = bin.Values [k];//kv.Value;
						if (v_distance_min_candidate > 0) {
							int v = bin.Keys[k];//kv.Key; //foreach (KeyValuePair<int, float> kv in VALUE.Path_size) { //	int v = kv.Key; //float v_distance_min_candidate = kv.Value;
							Queue<int> queue = new Queue<int> ();
							if (!messages [partition [v - 1]].TryGetValue (v, out distance_min) || distance_min > v_distance_min_candidate) {
								messages [partition [v - 1]] [v] = v_distance_min_candidate;
								queue.Enqueue (v);
								while (queue.Count > 0) { // Busca em profundidade
									v = queue.Dequeue ();
									v_distance_min_candidate = messages [partition [v - 1]] [v];
									IEnumerator<KeyValuePair<int, float>> vneighbors = g.iteratorVertexWeightOf (v); //g.iteratorOutgoingVertexWeightOf (v);
									while (vneighbors.MoveNext ()) {
										int n = vneighbors.Current.Key;
										float n_distance_min_candidate = vneighbors.Current.Value + v_distance_min_candidate;
										if (!messages [partition [n - 1]].TryGetValue (n, out distance_min) || distance_min > n_distance_min_candidate) {
											messages [partition [n - 1]] [n] = n_distance_min_candidate;
											queue.Enqueue (n);
											emite [partition [n - 1]] = true;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		public void compute(){
			if (this.Superstep == 0)
				this.startup ();
		}
		public void scatter(){
			IIteratorInstance<IKVPair<IVertexBasic,IDataSSSP>> output_value_instance = (IIteratorInstance<IKVPair<IVertexBasic,IDataSSSP>>)Output_messages.Instance;

			bool any_emite = false;
			foreach (bool any in emite)
				any_emite = any_emite || any;
			if (!any_emite && halt_sum == 0) {
				IKVPairInstance<IVertexBasic,IDataSSSP> ITEM = (IKVPairInstance<IVertexBasic,IDataSSSP>)Output_messages.createItem ();
				((IVertexBasicInstance)ITEM.Key).Id = this.partid;
				((IVertexBasicInstance)ITEM.Key).PId = (byte) this.partid;
				((IDataSSSPInstance)ITEM.Value).Path_size = messages [((IVertexBasicInstance)ITEM.Key).PId];
				((IDataSSSPInstance)ITEM.Value).Halt = 0;
				output_value_instance.put (ITEM);

				output_value_instance.finish (); //finish(), preparando-se para a emissão definitiva de saída
			} else {
				for (int i = 0; i < partition_size; i++) {
					IKVPairInstance<IVertexBasic,IDataSSSP> ITEM = (IKVPairInstance<IVertexBasic,IDataSSSP>)Output_messages.createItem ();
					((IVertexBasicInstance)ITEM.Key).Id = i;
					((IVertexBasicInstance)ITEM.Key).PId = (byte) i;
					if (partition_own [i] || !emite [i])
						((IDataSSSPInstance)ITEM.Value).Value = new Block (0);
					else {
						Block bin = new Block (messages[i].Count);
						int count = 0;
						KeyValuePair<int,float>[] kv = messages [i].ToArray ();
						foreach (KeyValuePair<int,float> b in kv) {
							bin.Keys [count] = b.Key;
							bin.Values [count++] = b.Value;
						}
						((IDataSSSPInstance)ITEM.Value).Value = bin;
					}
					((IDataSSSPInstance)ITEM.Value).Halt = any_emite ? 1 : 0;
					output_value_instance.put (ITEM);
				}
			}
			emite = new bool[partition_size];
			halt_sum = 0;
		}
		[Serializable]
		public class Block{
			public int SIZE = 0;
			public int[] Keys;
			public float[] Values;
			public Block(int size){
				this.SIZE = size;
				this.Keys = new int[size];
				this.Values = new float[size];
			}
		}
		#endregion
	}
}
