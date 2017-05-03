/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.gust.custom.GustyFunction;
using br.ufc.mdcc.hpcshelf.gust.example.pgr.DataPGRANK;
using br.ufc.mdcc.hpcshelf.gust.graph.InputFormat;
using br.ufc.mdcc.hpcshelf.gust.graph.Graph;
using br.ufc.mdcc.hpcshelf.gust.graph.DirectedGraph;
using br.ufc.mdcc.hpcshelf.gust.graph.container.DataContainer;
using br.ufc.mdcc.hpcshelf.gust.graph.container.DataContainerKV;
using br.ufc.mdcc.hpcshelf.gust.graph.Vertex;
using br.ufc.mdcc.hpcshelf.gust.graph.Edge;
using br.ufc.mdcc.hpcshelf.gust.graph.EdgeWeighted;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;

namespace br.ufc.mdcc.hpcshelf.gust.example.pgr.PGRANK
{
	public interface BaseIPGRANK : BaseIGustyFunction<
	IVertexBasic,
	IDataPGRANK,
	IVertexBasic,
	IDataPGRANK,
	IDirectedGraph<IDataContainerKV<IVertex, IEdgeWeighted<IVertex>>, IVertex, IEdgeWeighted<IVertex>>,
	IInputFormat
	>, IComputationKind
	{
	}
}