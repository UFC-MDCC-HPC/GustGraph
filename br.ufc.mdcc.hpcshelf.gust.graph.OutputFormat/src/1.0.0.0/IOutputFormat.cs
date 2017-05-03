using System;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.gust.graph.OutputFormat
{
	public interface IOutputFormat<IKey,IValue> : BaseIOutputFormat<IKey,IValue>, IData
		where IKey:IData
		where IValue:IData
	{
		//IOutputFormatInstance<OKey,OValue> newInstance(object iterator);
	}
	public interface IOutputFormatInstance<IKey,IValue> : IDataInstance, ICloneable
		where IKey:IData
		where IValue:IData
	{
        object Iterator{get;}
        string formatRepresentation(object kv_pair);
	}
}