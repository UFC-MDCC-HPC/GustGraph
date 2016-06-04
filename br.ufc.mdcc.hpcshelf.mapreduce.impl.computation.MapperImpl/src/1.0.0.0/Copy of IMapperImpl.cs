using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.MapFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.computation.Mapper;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using System.Diagnostics;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.computation.MapperImpl
{
	public class IMapperImpl<IMK, IMV, OMK, OMV, MF> : BaseIMapperImpl<IMK, IMV, OMK, OMV, MF>, IMapper<IMK, IMV, OMK, OMV, MF>
		where MF:IMapFunction<IMK, IMV, OMK, OMV>
		where IMK:IData
		where IMV:IData
		where OMK:IData
		where OMV:IData
	{
		public override void main()
		{
			Console.WriteLine ("STARTING MAPPER ...1");
			IIteratorInstance<IKVPair<IMK,IMV>> input_instance = (IIteratorInstance<IKVPair<IMK,IMV>>)Collect_pairs.Client;
			Console.WriteLine ("STARTING MAPPER ...2");
			IIteratorInstance<IKVPair<OMK,OMV>> output_instance = (IIteratorInstance<IKVPair<OMK,OMV>>)Output.Instance;
			Console.WriteLine ("STARTING MAPPER ...3");
			Feed_pairs.Server = output_instance;

			IActionFuture sync_perform;

			while (true) // next iteration
			{  
				bool finished_stream = false;

				Console.WriteLine ("STARTING MAPPER ...4");

				while (!finished_stream)  // take next chunk ...
				{        
					Console.WriteLine ("LOOP CHUNK MAPPER ...");

					Task_port_mapper.invoke (ITaskPortAdvance.READ_CHUNK);
					Task_port_mapper.invoke (ITaskPortAdvance.PERFORM, out sync_perform);

					object bin_object = null;

					// READ_CHUNK / PERFORM
					IKVPairInstance<IMK,IMV> bin;
					if (input_instance.fetch_next (out bin_object)) 
					{
						bin = (IKVPairInstance<IMK,IMV>)bin_object;
						Map_key.Instance = bin.Key;
						Map_value.Instance = bin.Value;
						Map_function.go ();
		
						while (input_instance.fetch_next (out bin_object)) 
						{
							Map_key.Instance = bin.Key;
							Map_value.Instance = bin.Value;
							Map_function.go ();
						}
					} 
					else 
					{
						finished_stream = true;
					}

					sync_perform.wait ();

					output_instance.finish ();

					Task_port_mapper.invoke (ITaskPortAdvance.CHUNK_READY);
					/* levando em conta que há sincronização pelos iteradores, talvez não haja necessidade de sincronizar o CHUNK_READY para o
				     * shuffler começar a ler os pares */
				}
			}
		}
	}
}
