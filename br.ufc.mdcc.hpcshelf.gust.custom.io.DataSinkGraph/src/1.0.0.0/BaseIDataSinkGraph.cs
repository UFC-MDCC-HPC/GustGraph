/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
//using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBaseDirect;
//using br.ufc.mdcc.hpcshelf.gust.port.environment.PortTypeDataSinkGraphInterface;
//using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;
//using br.ufc.mdcc.common.Iterator;
//using br.ufc.mdcc.common.KVPair;
//using br.ufc.mdcc.common.Data;
//using br.ufc.mdcc.hpcshelf.platform.Platform;
using br.ufc.mdcc.hpcshelf.platform.Maintainer;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;
using br.ufc.mdcc.hpcshelf.gust.graph.DataObject;
using br.ufc.mdcc.hpcshelf.gust.graph.OutputFormat;

namespace br.ufc.mdcc.hpcshelf.gust.custom.io.DataSinkGraph
{
	public interface BaseIDataSinkGraph<M, IKey, IValue, GOF> : IComputationKind
		where M:IMaintainer
		where IKey:IVertexBasic
		where IValue:IDataObject
		where GOF:IOutputFormat<IKey, IValue>
	{
		//IBindingDirect<IPortTypeDataSinkGraphInterface, IEnvironmentPortTypeSinglePartner> Output_data {get;}
		//IProcessingNode<M> Platform_data_sink {get;}
	}
}