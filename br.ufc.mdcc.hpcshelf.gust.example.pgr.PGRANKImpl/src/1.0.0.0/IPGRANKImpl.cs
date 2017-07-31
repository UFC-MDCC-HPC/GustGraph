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
using br.ufc.mdcc.hpcshelf.gust.example.pgr.DataPGRANK;
using br.ufc.mdcc.hpcshelf.gust.example.pgr.PGRANK;
using br.ufc.mdcc.hpcshelf.gust.graph.Graph;
using br.ufc.mdcc.hpcshelf.gust.graph.DirectedGraph;
using br.ufc.mdcc.hpcshelf.gust.graph.container.DataContainer;
using br.ufc.mdcc.hpcshelf.gust.graph.container.DataContainerKV;
using br.ufc.mdcc.hpcshelf.gust.graph.Vertex;
using br.ufc.mdcc.hpcshelf.gust.graph.Edge;
using br.ufc.mdcc.hpcshelf.gust.graph.EdgeWeighted;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;

namespace br.ufc.mdcc.hpcshelf.gust.example.pgr.PGRANKImpl {
	public class IPGRANKImpl : BaseIPGRANKImpl, IPGRANK {

		private IDirectedGraphInstance<IVertex, IEdgeWeighted<IVertex>, int, IEdgeInstance<IVertex, int>> g = null;
		private int[] partition = null;
		private bool[]  partition_own = null;
		private int partition_size = 0;
		private double nothing_outgoing = 0;
		private double sum_nothings = 0.0f;
		private int partid = 0;
		private int MAX_ITERATION = 30;
		private double d = 0.85f;
		IDictionary<int, double> before = new Dictionary<int, double>();
		private IDictionary<int, double>[] messages = null;
		private IDictionary<int, ICollection<int>> cache = new Dictionary<int, ICollection<int>>();
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
				messages = new Dictionary<int, double>[partition_size];
			}
			for (int i = 0; i < gif.ESIZE;i++) {
				int s = gif.Source [i];
				int t = gif.Target [i];
				g.addVertex (s);
				g.addVertex (t); //g.addEdge (s, t);
				if(s!=t) g.noSafeAdd (s, t);
				if (s == 0 || t==0) { throw new ArgumentNullException ("WARNING: Vertex id is 0! "); }
			}
			partition_own [gif.PARTID] = true;
			gif.Clear ();
		}
		#endregion

		#region Algorithm implementation
		public void startup() {
			before = new Dictionary<int, double>(g.countV()+1);
			messages = new Dictionary<int, double>[partition_size];
			for (int i = 0; i < partition_size; i++) messages[i] = new Dictionary<int, double> ();

			ICollection<int> vertices = g.vertexSet ();
			foreach (int v in vertices) {
				if (!messages [partition [v - 1]].ContainsKey (v)) messages [partition [v - 1]] [v] = 0.0f;
				if (!isGhost (v)) {
					bool any = false;
					before [v] = 0.0f;
					ICollection<int> vneighbors = g.outgoingVertexOf (v);
					if (!cache.ContainsKey (v))
						cache [v] = vneighbors;
					foreach(int n in vneighbors) {
						any = true;
						if (!messages [partition [n - 1]].ContainsKey (n)) messages [partition [n - 1]] [n] = 0.0f;
						messages [partition [n - 1]] [n] += 1.0f*d / g.outDegreeOf (v);
					}
					if (!any) nothing_outgoing+=1.0f*d;
				}
			}
		}
		public void unroll() {
			IKVPairInstance<IVertexBasic,IIterator<IDataPGRANK>> input_values_instance = (IKVPairInstance<IVertexBasic,IIterator<IDataPGRANK>>)Input_values.Instance;
			IIteratorInstance<IDataPGRANK> ivalues = (IIteratorInstance<IDataPGRANK>)input_values_instance.Value;

			object o;
			while (ivalues.fetch_next (out o)) {
				IDataPGRANKInstance VALUE = (IDataPGRANKInstance)o;
				if (this.Superstep == 0)
					this.graph_creator ((IInputFormatInstance)VALUE.Value);
				else {
					Block bin = (Block)VALUE.Value;
					for (int k = 0; k < bin.SIZE; k++) {
						double rank_value = bin.Values [k];
						if (rank_value > 0) {
							int rank_key = bin.Keys[k];
							messages [partition [rank_key - 1]] [rank_key] += rank_value;
						}
					}
					sum_nothings += VALUE.Slice;
				}
			}
		}
		public void compute(){
			if (this.Superstep == 0)
				this.startup ();
			else {
				ISet<int> bag = new HashSet<int> ();
				ICollection<int> vertices = g.vertexSet ();
				if (this.Superstep < MAX_ITERATION) {
					foreach (int v in vertices) {
						if (!isGhost (v)) {
							if (!bag.Contains(v)) {
								bag.Add (v);
								before [v] = messages [partition [v - 1]] [v] + sum_nothings - before [v] + (1 - d);
								messages [partition [v - 1]] [v] = before [v];
							}

							bool any = false;
							ICollection<int> vneighbors = cache [v];//g.iteratorOutgoingVertexOf (v);
							foreach (int n in vneighbors) { //while(vneighbors.MoveNext()){ int n = vneighbors.Current;
								if (!isGhost(n) && !bag.Contains(n)) {
									bag.Add (n);
									before [n] = messages [partition [n - 1]] [n] + sum_nothings - before [n] + (1 - d);
									messages [partition [n - 1]] [n] = before [n];
								}

								any = true;
								if (!messages [partition [n - 1]].ContainsKey (n))
									messages [partition [n - 1]] [n] = 0.0f;
								messages [partition [n - 1]] [n] += before [v] * d / g.outDegreeOf (v);
							}
							if (!any) nothing_outgoing += before [v] * d;
						}
					}
				} else {
					foreach (int v in vertices) {
						if (!isGhost (v)) {
							before [v] = messages [partition [v - 1]] [v] + sum_nothings - before [v] + (1 - d);
							messages [partition [v - 1]] [v] = before [v];
						}
					}
				}
			}
		}
		public void scatter(){
			IIteratorInstance<IKVPair<IVertexBasic,IDataPGRANK>> output_value_instance = (IIteratorInstance<IKVPair<IVertexBasic,IDataPGRANK>>)Output_messages.Instance;
			if (this.Superstep == MAX_ITERATION) {
				IKVPairInstance<IVertexBasic,IDataPGRANK> ITEM = (IKVPairInstance<IVertexBasic,IDataPGRANK>)Output_messages.createItem ();
				((IVertexBasicInstance)ITEM.Key).Id = this.partid;
				((IVertexBasicInstance)ITEM.Key).PId = (byte)this.partid;
				((IDataPGRANKInstance)ITEM.Value).Ranks = messages [((IVertexBasicInstance)ITEM.Key).PId];
				output_value_instance.put (ITEM);
				output_value_instance.finish ();
			} else {
				for (int i = 0; i < partition_size; i++) {
					IKVPairInstance<IVertexBasic,IDataPGRANK> ITEM = (IKVPairInstance<IVertexBasic,IDataPGRANK>)Output_messages.createItem ();
					((IVertexBasicInstance)ITEM.Key).Id = i;
					((IVertexBasicInstance)ITEM.Key).PId = (byte) i;
					if (partition_own [i])
						((IDataPGRANKInstance)ITEM.Value).Value = new Block (0);
					else {
						KeyValuePair<int,double>[] kv = messages [i].ToArray ();
						Block bin = new Block(messages[i].Count);
						int count = 0;
						foreach (KeyValuePair<int,double> b in kv) {
							bin.Keys[count] = b.Key;
							bin.Values [count++] = (float) b.Value;
						}
						((IDataPGRANKInstance)ITEM.Value).Value = bin;
						messages [i] = new Dictionary<int, double> ();
					}
					((IDataPGRANKInstance)ITEM.Value).Slice = nothing_outgoing / ((double)partition.Length);

					output_value_instance.put (ITEM);
				}
			}
			nothing_outgoing = 0.0f;
			sum_nothings = 0.0f;
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
