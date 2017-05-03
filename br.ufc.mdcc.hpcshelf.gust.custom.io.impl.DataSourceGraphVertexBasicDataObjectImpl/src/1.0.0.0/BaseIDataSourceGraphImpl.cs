/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.gust.port.environment.PortTypeDataSourceGraphInterface;
using br.ufc.mdcc.hpcshelf.gust.custom.io.DataSourceGraph;
using br.ufc.mdcc.hpcshelf.platform.Maintainer;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;
using br.ufc.mdcc.hpcshelf.gust.graph.DataObject;
using br.ufc.mdcc.hpcshelf.gust.graph.InputFormat;
//using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBaseDirect;
//using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;
//using br.ufc.mdcc.hpcshelf.platform.Platform;
//using br.ufc.mdcc.hpcshelf.platform.maintainer.DataHost;

namespace br.ufc.mdcc.hpcshelf.gust.custom.io.impl.DataSourceGraphVertexBasicDataObjectImpl
{
	public abstract class BaseIDataSourceGraphImpl<M, IKey, IValue, GIF>: Computation, BaseIDataSourceGraph<M, IKey, IValue, GIF>
		where M:IMaintainer
		where IKey:IVertexBasic
		where IValue:IDataObject
		where GIF:IInputFormat
	{
		private IServerBase<IPortTypeDataSourceGraphInterface> input_data = null;
		protected IServerBase<IPortTypeDataSourceGraphInterface> Input_data
		{
			get
			{
				if (this.input_data == null)
					this.input_data = (IServerBase<IPortTypeDataSourceGraphInterface>) Services.getPort("input_data");
				return this.input_data;
			}
		}

		private M platform_data_source = default(M);
		protected M Platform_data_source
		{
			get
			{
				if (this.platform_data_source == null)
					this.platform_data_source = (M) Services.getPort("platform_data_source");
				return this.platform_data_source;
			}
		}

//		private IBindingDirect<IEnvironmentPortTypeSinglePartner, IPortTypeDataSourceGraphInterface> input_data = null;
//		public IBindingDirect<IEnvironmentPortTypeSinglePartner, IPortTypeDataSourceGraphInterface> Input_data
//		{
//			get
//			{
//				if (this.input_data == null)
//					this.input_data = (IBindingDirect<IEnvironmentPortTypeSinglePartner, IPortTypeDataSourceGraphInterface>) Services.getPort("input_data");
//				return this.input_data;
//			}
//		}

		private IIterator<IKVPair<IKey, IValue>> input_pairs = null;
		protected IIterator<IKVPair<IKey, IValue>> Input_pairs
		{
			get
			{
				if (this.input_pairs == null)
					this.input_pairs = (IIterator<IKVPair<IKey, IValue>>) Services.getPort("input_pairs");
				return this.input_pairs;
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

		private GIF input_format = default(GIF);
		protected GIF Input_format
		{
			get
			{
				if (this.input_format == null)
					this.input_format = (GIF) Services.getPort("input_format");
				return this.input_format;
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
		//		private IProcessingNode<M> platform_data_source = null;
		//		public IProcessingNode<M> Platform_data_source
		//		{
		//			get
		//			{
		//				if (this.platform_data_source == null)
		//					this.platform_data_source = (IProcessingNode<M>) Services.getPort("platform_data_source");
		//				return this.platform_data_source;
		//			}
		//		}
	}
}