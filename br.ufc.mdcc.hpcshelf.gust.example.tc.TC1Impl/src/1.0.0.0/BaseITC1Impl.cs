/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.hpcshelf.gust.example.tc.DataTriangle;
using br.ufc.mdcc.hpcshelf.gust.graph.InputFormat;
using br.ufc.mdcc.hpcshelf.gust.example.tc.TC1;
using br.ufc.mdcc.hpcshelf.gust.graph.UndirectedGraph;
using br.ufc.mdcc.hpcshelf.gust.graph.container.DataContainerV;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;
using br.ufc.mdcc.hpcshelf.gust.graph.EdgeBasic;

namespace br.ufc.mdcc.hpcshelf.gust.example.tc.TC1Impl
{
	public abstract class BaseITC1Impl: Computation, BaseITC1
	{
		private IUndirectedGraph<IDataContainerV<IVertexBasic, IEdgeBasic<IVertexBasic>>, IVertexBasic, IEdgeBasic<IVertexBasic>> graph = null;
		public IUndirectedGraph<IDataContainerV<IVertexBasic, IEdgeBasic<IVertexBasic>>, IVertexBasic, IEdgeBasic<IVertexBasic>> Graph
		{
			get
			{
				if (this.graph == null)
					this.graph = (IUndirectedGraph<IDataContainerV<IVertexBasic, IEdgeBasic<IVertexBasic>>, IVertexBasic, IEdgeBasic<IVertexBasic>>) Services.getPort("graph");
				return this.graph;
			}
		}

		private IKVPair<IVertexBasic, IIterator<IDataTriangle>> input_values = null;
		public IKVPair<IVertexBasic, IIterator<IDataTriangle>> Input_values
		{
			get
			{
				if (this.input_values == null)
					this.input_values = (IKVPair<IVertexBasic, IIterator<IDataTriangle>>) Services.getPort("input_values");
				return this.input_values;
			}
		}

		private IIterator<IKVPair<IVertexBasic, IDataTriangle>> output_messages = null;
		public IIterator<IKVPair<IVertexBasic, IDataTriangle>> Output_messages
		{
			get
			{
				if (this.output_messages == null)
					this.output_messages = (IIterator<IKVPair<IVertexBasic, IDataTriangle>>) Services.getPort("output_messages");
				return this.output_messages;
			}
		}

		private IDataTriangle continuation_value = null;
		public IDataTriangle Continuation_value
		{
			get
			{
				if (this.continuation_value == null)
					this.continuation_value = (IDataTriangle) Services.getPort("continuation_value");
				return this.continuation_value;
			}
		}

		private IKVPair<IVertexBasic, IDataTriangle> output_value = null;
		public IKVPair<IVertexBasic, IDataTriangle> Output_value
		{
			get
			{
				if (this.output_value == null)
					this.output_value = (IKVPair<IVertexBasic, IDataTriangle>) Services.getPort("output_value");
				return this.output_value;
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
		private int superstep = 0;
		public int Superstep { get{ return this.superstep; } set{ this.superstep = (int) value; } }
	}
}