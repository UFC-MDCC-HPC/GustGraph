using System;
using System.Collections.Generic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.gust.graph.DataObject;

namespace br.ufc.mdcc.hpcshelf.gust.example.sssp.DataSSSP
{
	public interface IDataSSSP : BaseIDataSSSP, IDataObject {
		IDataSSSPInstance InstanceDataSSSP { get; }
	} // end main interface

	public interface IDataSSSPInstance : IDataObjectInstance, ICloneable {
		IDictionary<int, float> Path_size { get; set; }
		int Halt { get; set; }
	}
} // end namespace
