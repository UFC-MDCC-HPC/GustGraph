using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.ReduceFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.computation.Reducer;
using System.Diagnostics;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using System.Threading;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.computation.ReducerImpl
{
	public class IReducerImpl<OMK, OMV, ORK, ORV, RF> : BaseIReducerImpl<OMK, OMV, ORK, ORV, RF>, IReducer<OMK, OMV, ORK, ORV, RF>
		where RF:IReduceFunction<OMK, OMV, ORK, ORV>
		where OMK:IData
		where OMV:IData
		where ORK:IData
		where ORV:IData
	{
		public override void main() {
			/* 1. Ler pares chave (OMK) e valores (OMV) de Input.
             * 2. Para cada par, atribuir a Key e Values e chamar Reduce_function.go();
             * 3. Pegar o resultado de Reduction_function.go() de Output_reduce (ORV) 
             *    e colocar no iterator Output.
             */
			readPair_OMK_OMVs(); //startThreads();
		}

		private void readPair_OMK_OMVs() 	
		{
			IIteratorInstance<IKVPair<OMK, IIterator<OMV>>> input_instance = (IIteratorInstance<IKVPair<OMK, IIterator<OMV>>>)Collect_pairs.Client;
			IIteratorInstance<IKVPair<ORK,ORV>> output_instance = (IIteratorInstance<IKVPair<ORK,ORV>>)Output.Instance;
			Feed_pairs.Server = output_instance;

			IActionFuture sync_perform;

			// TODO: Dividir em chunks a saída de pares (ORK,ORV)

			while (true)    // new iteration
			{
				bool end_iteration = false;
				while (!end_iteration)    // take next chunk ...
				{          
					Task_port_reduce.invoke (ITaskPortAdvance.READ_CHUNK);
					Task_port_reduce.invoke (ITaskPortAdvance.PERFORM, out sync_perform);

					IKVPairInstance<OMK, IIterator<OMV>> kvpair = null;
					object kvpair_object;

					int count=0;
					while (input_instance.fetch_next (out kvpair_object)) 
					{
						kvpair = (IKVPairInstance<OMK, IIterator<OMV>>)kvpair_object;
						Input_reduce.Instance = kvpair;

						//Thread t = new Thread ((ThreadStart) delegate {
							Reduce_function.go ();				
							output_instance.put (Output_reduce.Instance);	 
						//});
						//t.Start ();
					}

					if (count == 0)
						end_iteration = true;

					sync_perform.wait ();

					Task_port_reduce.invoke (ITaskPortAdvance.CHUNK_READY);
					/* levando em conta que há sincronização pelos iteradores, talvez não haja necessidade de sincronizar o CHUNK_READY para o
			     	 * shuffler começar a ler os pares */
				}

				output_instance.finish ();
			}
		}

		private void startThreads() {
			/*Instancias*/
			Thread treadPairOMKOMV = new Thread(new ThreadStart(readPair_OMK_OMVs));

			/*Starting*/
			treadPairOMKOMV.Start(); 	
			/* Joins*/
			treadPairOMKOMV.Join();
		}
			}
}
