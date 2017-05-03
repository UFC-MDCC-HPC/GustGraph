/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.platform.Maintainer;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;
using br.ufc.mdcc.hpcshelf.gust.graph.DataObject;
using br.ufc.mdcc.hpcshelf.gust.graph.InputFormat;
//using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
//using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBaseDirect;
//using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;
//using br.ufc.mdcc.hpcshelf.gust.port.environment.PortTypeDataSourceGraphInterface;

namespace br.ufc.mdcc.hpcshelf.gust.custom.io.DataSourceGraph
{
	public interface BaseIDataSourceGraph<M, IKey, IValue, GIF> : IComputationKind 
		where M:IMaintainer
		where IKey:IVertexBasic
		where IValue:IDataObject
		where GIF:IInputFormat
	{
		// GENERATE: IBindingDirect<IEnvironmentPortTypeSinglePartner, IPortTypeDataSourceGraphInterface> Input_data {get;}
		// IServerBase<IPortTypeDataSourceGraphInterface> Input_data { get; }
	}
}
