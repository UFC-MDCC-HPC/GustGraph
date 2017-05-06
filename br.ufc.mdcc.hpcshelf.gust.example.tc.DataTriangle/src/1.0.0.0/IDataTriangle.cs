using System;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.gust.graph.DataObject;

namespace br.ufc.mdcc.hpcshelf.gust.example.tc.DataTriangle
{
	public interface IDataTriangle : BaseIDataTriangle, IDataObject {
	} // end main interface

	public interface IDataTriangleInstance : IDataObjectInstance, ICloneable {
		int Count { set; get; }
	}
} // end namespace
