using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.platform.Maintainer;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;
using br.ufc.mdcc.hpcshelf.gust.graph.DataObject;
using br.ufc.mdcc.hpcshelf.gust.graph.InputFormat;

namespace br.ufc.mdcc.hpcshelf.gust.custom.io.DataSourceGraph
{
	public interface IDataSourceGraph<M, IKey, IValue, GIF> : BaseIDataSourceGraph<M, IKey, IValue, GIF>
		where M:IMaintainer
		where IKey:IVertexBasic
		where IValue:IDataObject
		where GIF:IInputFormat
	{
	}
}