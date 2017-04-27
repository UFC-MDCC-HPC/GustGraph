using System;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.gust.graph.DataObject
{
	public interface IDataObject : BaseIDataObject, IData
	{
		//IDataObjectInstance newInstance(object o);
	}
	public interface IDataObjectInstance : IDataInstance, ICloneable
	{
		object Value { set; get; }
	}
}