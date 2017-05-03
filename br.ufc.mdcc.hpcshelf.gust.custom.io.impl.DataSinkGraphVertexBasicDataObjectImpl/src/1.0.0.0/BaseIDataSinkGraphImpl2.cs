/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.gust.graph.OutputFormat;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;
using br.ufc.mdcc.hpcshelf.gust.graph.DataObject;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBaseDirect;
using br.ufc.mdcc.hpcshelf.gust.port.environment.PortTypeDataSinkGraphInterface;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;
using br.ufc.mdcc.hpcshelf.platform.Platform;
using br.ufc.mdcc.hpcshelf.platform.maintainer.DataHost;
using br.ufc.mdcc.hpcshelf.gust.custom.io.DataSinkGraph;

namespace br.ufc.mdcc.hpcshelf.gust.custom.io.impl.DataSinkGraphVertexBasicDataObjectImpl
{
	public abstract class BaseIDataSinkGraphImpl<M, IKey, IValue, GOF>: Computation, BaseIDataSinkGraph<M, IKey, IValue, GOF>
		where M:IDataHost
		where IKey:IVertexBasic
		where IValue:IDataObject
		where GOF:IOutputFormat<IKey, IValue>
	{
		private GOF output_format = default(GOF);

		protected GOF Output_format
		{
			get
			{
				if (this.output_format == null)
					this.output_format = (GOF) Services.getPort("output_format");
				return this.output_format;
			}
		}
		private IBindingDirect<IPortTypeDataSinkGraphInterface, IEnvironmentPortTypeSinglePartner> output_data = null;

		public IBindingDirect<IPortTypeDataSinkGraphInterface, IEnvironmentPortTypeSinglePartner> Output_data
		{
			get
			{
				if (this.output_data == null)
					this.output_data = (IBindingDirect<IPortTypeDataSinkGraphInterface, IEnvironmentPortTypeSinglePartner>) Services.getPort("output_data");
				return this.output_data;
			}
		}
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
		private IProcessingNode<M> platform_data_sink = null;

		public IProcessingNode<M> Platform_data_sink
		{
			get
			{
				if (this.platform_data_sink == null)
					this.platform_data_sink = (IProcessingNode<M>) Services.getPort("platform_data_sink");
				return this.platform_data_sink;
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