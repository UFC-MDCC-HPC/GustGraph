using System;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.gust.graph.DataObject;

namespace br.ufc.mdcc.hpcshelf.gust.example.tc.DataTriangle
{
	public interface IDataTriangle : BaseIDataTriangle, IDataObject {
		IDataTriangleInstance newInstance(int v);
		IDataTriangleInstance newInstance(int v, int w);
	} // end main interface

	public interface IDataTriangleInstance : IDataObjectInstance, ICloneable {
		int V { set; get; }
		int W { set; get; }
	}
} // end namespace
