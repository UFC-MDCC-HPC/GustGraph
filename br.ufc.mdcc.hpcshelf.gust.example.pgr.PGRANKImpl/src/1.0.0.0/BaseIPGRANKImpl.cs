/* Automatically Generated Code */

using System;
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

namespace br.ufc.mdcc.hpcshelf.gust.example.pgr.PGRANKImpl
{
	public abstract class BaseIPGRANKImpl: Computation, BaseIPGRANK
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
		private IIterator<IKVPair<IInteger, IDataPGRANK>> output_messages = null;

		public IIterator<IKVPair<IInteger, IDataPGRANK>> Output_messages
		{
			get
			{
				if (this.output_messages == null)
					this.output_messages = (IIterator<IKVPair<IInteger, IDataPGRANK>>) Services.getPort("output_messages");
				return this.output_messages;
			}
		}
		private IKVPair<IInteger, IIterator<IDataPGRANK>> input_values = null;

		public IKVPair<IInteger, IIterator<IDataPGRANK>> Input_values
		{
			get
			{
				if (this.input_values == null)
					this.input_values = (IKVPair<IInteger, IIterator<IDataPGRANK>>) Services.getPort("input_values");
				return this.input_values;
			}
		}
		private IDataPGRANK continuation_value = null;

		public IDataPGRANK Continuation_value
		{
			get
			{
				if (this.continuation_value == null)
					this.continuation_value = (IDataPGRANK) Services.getPort("continuation_value");
				return this.continuation_value;
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
		private IKVPair<IInteger, IDataPGRANK> output_value = null;

		public IKVPair<IInteger, IDataPGRANK> Output_value
		{
			get
			{
				if (this.output_value == null)
					this.output_value = (IKVPair<IInteger, IDataPGRANK>) Services.getPort("output_value");
				return this.output_value;
			}
		}
		private int superstep = 0;
		public int Superstep { get{ return this.superstep; } set{ this.superstep = (int) value; } }
	}
}