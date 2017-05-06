using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.gust.custom.GustyFunction;
using br.ufc.mdcc.hpcshelf.gust.example.tc.DataTriangle;
using br.ufc.mdcc.hpcshelf.gust.graph.InputFormat;
using br.ufc.mdcc.hpcshelf.gust.graph.UndirectedGraph;
using br.ufc.mdcc.hpcshelf.gust.graph.container.DataContainerV;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;
using br.ufc.mdcc.hpcshelf.gust.graph.EdgeBasic;

namespace br.ufc.mdcc.hpcshelf.gust.example.tc.TC2
{
	public interface ITC2 : BaseITC2, IGustyFunction<
	IVertexBasic,
	IDataTriangle,
	IVertexBasic,
	IDataTriangle,
	IUndirectedGraph<IDataContainerV<IVertexBasic, IEdgeBasic<IVertexBasic>>, IVertexBasic, IEdgeBasic<IVertexBasic>>,
	IInputFormat
	>
	{
	}
}