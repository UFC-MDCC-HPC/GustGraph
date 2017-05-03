using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.platform.Maintainer;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;
using br.ufc.mdcc.hpcshelf.gust.graph.DataObject;
using br.ufc.mdcc.hpcshelf.gust.graph.OutputFormat;

namespace br.ufc.mdcc.hpcshelf.gust.custom.io.DataSinkGraph
{
	public interface IDataSinkGraph<M, IKey, IValue, GOF> : BaseIDataSinkGraph<M, IKey, IValue, GOF>
		where M:IMaintainer
		where IKey:IVertexBasic
		where IValue:IDataObject
		where GOF:IOutputFormat<IKey, IValue>
	{
	}
}