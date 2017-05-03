using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.platform.maintainer.DataHost;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;
using br.ufc.mdcc.hpcshelf.gust.graph.DataObject;
using br.ufc.mdcc.hpcshelf.gust.graph.OutputFormat;
using br.ufc.mdcc.hpcshelf.gust.custom.io.DataSinkGraph;

namespace br.ufc.mdcc.hpcshelf.gust.custom.io.impl.DataSinkGraphVertexBasicDataObjectImpl
{
	public class IDataSinkGraphImpl<M, IKey, IValue, GOF>: BaseIDataSinkGraphImpl<M, IKey, IValue, GOF>, IDataSinkGraph<M, IKey, IValue, GOF>
where M:IDataHost
where IKey:IVertexBasic
where IValue:IDataObject
where GOF:IOutputFormat<IKey, IValue>
	{
		public override void main()
		{
		}
	}
}
