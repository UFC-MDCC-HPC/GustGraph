/* Automatically Generated Code */

using System;
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

namespace br.ufc.mdcc.hpcshelf.gust.example.sssp.SSSPImpl
{
	public abstract class BaseISSSPImpl: Computation, BaseISSSP
	{
		private IDirectedGraph<IDataContainerKV<IVertex, IEdgeWeighted<IVertex>>, IVertex, IEdgeWeighted<IVertex>> graph = null;
		public IDirectedGraph<IDataContainerKV<IVertex, IEdgeWeighted<IVertex>>, IVertex, IEdgeWeighted<IVertex>> Graph
		{
			get
			{
				if (this.graph == null)
					this.graph = (IDirectedGraph<IDataContainerKV<IVertex, IEdgeWeighted<IVertex>>, IVertex, IEdgeWeighted<IVertex>>) Services.getPort("graph");
				return this.graph;
			}
		}

		private IIterator<IKVPair<IVertexBasic, IDataSSSP>> output_messages = null;
		public IIterator<IKVPair<IVertexBasic, IDataSSSP>> Output_messages
		{
			get
			{
				if (this.output_messages == null)
					this.output_messages = (IIterator<IKVPair<IVertexBasic, IDataSSSP>>) Services.getPort("output_messages");
				return this.output_messages;
			}
		}

		private IKVPair<IVertexBasic, IIterator<IDataSSSP>> input_values = null;
		public IKVPair<IVertexBasic, IIterator<IDataSSSP>> Input_values
		{
			get
			{
				if (this.input_values == null)
					this.input_values = (IKVPair<IVertexBasic, IIterator<IDataSSSP>>) Services.getPort("input_values");
				return this.input_values;
			}
		}

		private IInputFormat input_format = null;
		protected IInputFormat Input_format
		{
			get
			{
				if (this.input_format == null)
					this.input_format = (IInputFormat) Services.getPort("input_format");
				return this.input_format;
			}
		}

		private IKVPair<IVertexBasic, IDataSSSP> output_value = null;
		public IKVPair<IVertexBasic, IDataSSSP> Output_value
		{
			get
			{
				if (this.output_value == null)
					this.output_value = (IKVPair<IVertexBasic, IDataSSSP>) Services.getPort("output_value");
				return this.output_value;
			}
		}

		private IDataSSSP continuation_value = null;
		public IDataSSSP Continuation_value
		{
			get
			{
				if (this.continuation_value == null)
					this.continuation_value = (IDataSSSP) Services.getPort("continuation_value");
				return this.continuation_value;
			}
		}
		private int superstep = 0;
		public int Superstep { get{ return this.superstep; } set{ this.superstep = (int) value; } }
	}
}