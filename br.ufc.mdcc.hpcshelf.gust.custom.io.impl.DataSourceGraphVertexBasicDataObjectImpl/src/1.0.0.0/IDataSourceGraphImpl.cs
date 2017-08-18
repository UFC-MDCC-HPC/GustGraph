using System;
using System.IO;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.platform.Maintainer;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;
using br.ufc.mdcc.hpcshelf.gust.graph.DataObject;
using br.ufc.mdcc.hpcshelf.gust.graph.InputFormat;
using br.ufc.mdcc.hpcshelf.gust.custom.io.DataSourceGraph;
using br.ufc.mdcc.hpcshelf.gust.port.environment.PortTypeDataSourceGraphInterface;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
//using br.ufc.mdcc.hpcshelf.platform.maintainer.DataHost;

namespace br.ufc.mdcc.hpcshelf.gust.custom.io.impl.DataSourceGraphVertexBasicDataObjectImpl {
	public class IDataSourceGraphImpl<M, IKey, IValue, GIF>: BaseIDataSourceGraphImpl<M, IKey, IValue, GIF>, IDataSourceGraph<M, IKey, IValue, GIF>
where M:IMaintainer
where IKey:IVertexBasic
where IValue:IDataObject
where GIF:IInputFormat {
		// For Default InputFormat implementation, each line of PATH_GRAPH_FILE include:
		// i j, like source and target integers ids of vertices
		private static string PATH_GRAPH_FILE = "PATH_GRAPH_FILE";
		public override void main () { }

		public override void after_initialize () 
		{ //Input_data.TraceFlag = true;
 			DataSourceReader<IKey, IValue, GIF> graph_server = new DataSourceReader<IKey, IValue, GIF> (Input_format.newInstanceIF (), Input_pairs);
			Input_data.Server = graph_server;
 		}
		private class DataSourceReader<IKey, IValue, GIF>: IPortTypeDataSourceGraphInterface 
			where IKey:IVertexBasic
			where IValue:IDataObject
			where GIF:IInputFormat
		{
			private IInputFormatInstance gif_instance = null;
			private IIterator<IKVPair<IKey, IValue>> Input_pairs_reference = null;

			public object IteratorInstance{ get { return Emitter; } }
			public IIteratorInstance<IKVPair<IKey, IValue>> Emitter{ get { return (IIteratorInstance<IKVPair<IKey, IValue>>) Input_pairs_reference.Instance; } }
			public IInputFormatInstance Gif_instance{ get { return this.gif_instance; } }

			public DataSourceReader(IInputFormatInstance gif, IIterator<IKVPair<IKey, IValue>> input_reference)
			{
				this.gif_instance = gif;
				this.Input_pairs_reference = input_reference;
			}
			public IEnumerable<object> fetchContentsKeyValue()
			{
                string path_graph_file = System.Environment.GetEnvironmentVariable(PATH_GRAPH_FILE);
				IDictionary<int, IInputFormatInstance> BINS = Gif_instance.extractBins (path_graph_file);
				foreach(KeyValuePair<int, IInputFormatInstance> dictionary_kv_pair in BINS) 
				{
                    Console.WriteLine("IDataSourceGraphImpl - BIN {0}", dictionary_kv_pair.Key);
					IKVPairInstance<IKey, IValue> item = (IKVPairInstance<IKey, IValue>)Input_pairs_reference.createItem ();
					((IVertexBasicInstance)item.Key).Id = dictionary_kv_pair.Key;
					((IVertexBasicInstance)item.Key).PId = (byte) dictionary_kv_pair.Key;
					((IDataObjectInstance)item.Value).Value = dictionary_kv_pair.Value;
					//Emitter.put (item);
					yield return item; //dictionary_kv_pair.Key;
				}
			}
		}
	}
}
