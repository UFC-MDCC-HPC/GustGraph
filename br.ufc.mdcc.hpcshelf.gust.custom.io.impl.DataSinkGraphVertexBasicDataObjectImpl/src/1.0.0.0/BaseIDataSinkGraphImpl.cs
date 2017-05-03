/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.gust.graph.OutputFormat;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;
using br.ufc.mdcc.hpcshelf.gust.graph.DataObject;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
//using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBaseDirect;
using br.ufc.mdcc.hpcshelf.gust.port.environment.PortTypeDataSinkGraphInterface;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;
//using br.ufc.mdcc.hpcshelf.platform.Platform;
//using br.ufc.mdcc.hpcshelf.platform.maintainer.DataHost;
using br.ufc.mdcc.hpcshelf.platform.Maintainer;
using br.ufc.mdcc.hpcshelf.gust.custom.io.DataSinkGraph;

namespace br.ufc.mdcc.hpcshelf.gust.custom.io.impl.DataSinkGraphVertexBasicDataObjectImpl
{
	public abstract class BaseIDataSinkGraphImpl<M, IKey, IValue, GOF>: Computation, BaseIDataSinkGraph<M, IKey, IValue, GOF>
		where M:IMaintainer
		where IKey:IVertexBasic
		where IValue:IDataObject
		where GOF:IOutputFormat<IKey, IValue>
	{
		private M platform_data_sink = default(M);
		public M Platform_data_sink
		{
			get
			{
				if (this.platform_data_sink == null)
					this.platform_data_sink = (M) Services.getPort("platform_data_sink");
				return this.platform_data_sink;
			}
		}

		private IClientBase<IPortTypeDataSinkGraphInterface> output_data = null;
		protected IClientBase<IPortTypeDataSinkGraphInterface> Output_data
		{
			get
			{
				if (this.output_data == null)
					this.output_data = (IClientBase<IPortTypeDataSinkGraphInterface>) Services.getPort("output_data");
				return this.output_data;
			}
		}

		private GOF graph_output_format = default(GOF);
		protected GOF Graph_output_format
		{
			get
			{
				if (this.graph_output_format == null)
					this.graph_output_format = (GOF) Services.getPort("output_format");
				return this.graph_output_format;
			}
		}

//		private IBindingDirect<IPortTypeDataSinkGraphInterface, IEnvironmentPortTypeSinglePartner> output_data = null;
//		public IBindingDirect<IPortTypeDataSinkGraphInterface, IEnvironmentPortTypeSinglePartner> Output_data
//		{
//			get
//			{
//				if (this.output_data == null)
//					this.output_data = (IBindingDirect<IPortTypeDataSinkGraphInterface, IEnvironmentPortTypeSinglePartner>) Services.getPort("output_data");
//				return this.output_data;
//			}
//		}

		private IKey input_key = default(IKey);
		protected IKey Input_key
		{
			get
			{
				if (this.input_key == null)
					this.input_key = (IKey) Services.getPort("input_key");
				return this.input_key;
			}
		}

		private IValue input_value = default(IValue);
		protected IValue Input_value
		{
			get
			{
				if (this.input_value == null)
					this.input_value = (IValue) Services.getPort("input_value");
				return this.input_value;
			}
		}
	}
}