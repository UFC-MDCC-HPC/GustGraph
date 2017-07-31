using System;
//using System.Reflection;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.gust.custom.GustyFunction;//using br.ufc.mdcc.hpcshelf.mapreduce.custom.ReduceFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.gust.computation.Gusty;//using br.ufc.mdcc.hpcshelf.mapreduce.computation.Reducer;
using System.Diagnostics;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using System.Threading;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using System.Collections.Generic;
using br.ufc.mdcc.hpcshelf.platform.Maintainer;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvance;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.ReadChunkActionType;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.PerformActionType;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.advance.ChunkReadyActionType;
using br.ufc.mdcc.hpcshelf.gust.graph.InputFormat;

namespace br.ufc.mdcc.hpcshelf.gust.impl.computation.GustyImpl
{
	public class IGustyImpl<M,TKey, TValue, OKey, OValue, RF, G, GIF> : BaseIGustyImpl<M,TKey, TValue, OKey, OValue, RF, G, GIF>, IGusty<M,TKey, TValue, OKey, OValue, RF, G, GIF>
		where M:IMaintainer
		where RF:IGustyFunction<TKey, TValue, OKey, OValue, G, GIF>
		where OKey:IData
		where OValue:IData
		where TKey:IData
		where TValue:IData
		where G:IData
		where GIF:IInputFormat
	{
		public override void main() {
			/* 1. Ler pares chave (TKey) e valores (TValue) de Input.
             * 2. Para cada par, atribuir a Key e Values e chamar Reduce_function.go();
             * 3. Pegar o resultado de Reduction_function.go() de Output_reduce (OValue)
             *    e colocar no iterator Output.
             */
			readPair_OMK_OMVs(); //startThreads();
		}

		private void readPair_OMK_OMVs()
		{
		//	Collect_pairs.TraceFlag = true;	Feed_pairs.TraceFlag = true;Task_reduce.TraceFlag = true;

			Console.WriteLine (this.Rank + ": REDUCE 1");

			IIteratorInstance<IKVPair<TKey, IIterator<TValue>>> input_instance = (IIteratorInstance<IKVPair<TKey, IIterator<TValue>>>)Collect_pairs.Client;
			IIteratorInstance<IKVPair<OKey,OValue>> output_instance = (IIteratorInstance<IKVPair<OKey,OValue>>)Output.Instance;
			Feed_pairs.Server = output_instance;

			IActionFuture sync_perform;

			// TODO: Dividir em chunks a saa de pares (OKey,OValue)

			Console.WriteLine (this.Rank + ": REDUCER 2");

			int superstep = -1;
			bool end_computation = false;
			while (!end_computation)    // new iteration
			{
				Reduce_function.Superstep = ++superstep;

				//IDictionary<object,object> cont_dict = new Dictionary<object, object> ();

				Console.WriteLine (this.Rank + ": REDUCER LOOP");

				end_computation = true;

				bool end_iteration = false;
				while (!end_iteration)    // take next chunk ...
				{
					Console.WriteLine (this.Rank + ": REDUCER ITERATE 1");

					Task_reduce.invoke (READ_CHUNK.name);
					Task_reduce.invoke (PERFORM.name, out sync_perform);

					Console.WriteLine (this.Rank + ": REDUCER ITERATE 2");

					IKVPairInstance<TKey, IIterator<TValue>> kvpair = null;
					object kvpair_object;

					if (!input_instance.has_next ())
						end_iteration = true;
					else
						end_computation = false;

					int count=0;
					while (input_instance.fetch_next (out kvpair_object))
					{
//						Console.WriteLine (this.Rank + ": REDUCER ITERATE INNER LOOP 3 count=" + count);

						kvpair = (IKVPairInstance<TKey, IIterator<TValue>>)kvpair_object;

						//object acc_value;
						//if (!cont_dict.TryGetValue(kvpair.Key, out acc_value))
						//	cont_dict[kvpair.Key] = new object();
						//else
						//	((IDataInstance)Continue_value.Instance).ObjValue = acc_value;

						Input_values.Instance = kvpair;
						Reduce_function.unroll (); 
						//cont_dict [kvpair.Key] = ((IDataInstance)((IKVPairInstance<OKey,OValue>)Output_value.Instance).Value).ObjValue;

						count++;
					}

					Console.WriteLine (this.Rank + ": REDUCER ITERATE 4 count=" + count);

					sync_perform.wait ();

					Console.WriteLine (this.Rank + ": REDUCER ITERATE 5");
				}

				Console.WriteLine (this.Rank + ": REDUCER ITERATE END ITERATION");

				IActionFuture reduce_chunk_ready;
				Task_reduce.invoke (CHUNK_READY.name, out reduce_chunk_ready);  //***

				Reduce_function.compute ();
				Reduce_function.scatter ();
//				foreach (KeyValuePair<object,object> output_pair in cont_dict)
//				{
//					IKVPairInstance<OKey,OValue> new_pair = (IKVPairInstance<OKey,OValue>) Output_value.newInstance ();
//					new_pair.Key = output_pair.Key;
//					new_pair.Value = output_pair.Value;
//					output_instance.put (new_pair);
//				}

				output_instance.finish ();
				reduce_chunk_ready.wait ();

				output_instance.finish ();
				Task_reduce.invoke (CHUNK_READY.name);

				Console.WriteLine (this.Rank + ": REDUCER ITERATE FINISH");
			}

			output_instance.finish ();

			Console.WriteLine (this.Rank + ": REDUCER FINISH ... ");
		}

//		private static ICollection<MethodInfo> getGustMethods(object o){
//			IDictionary<int,MethodInfo> dic = new Dictionary<int,MethodInfo> ();
//			IList<MethodInfo> all_methods = new List<MethodInfo> (o.GetType ().GetMethods ());
//			foreach (MethodInfo m in all_methods) {
//				if (m.Name.Length >= 4) {
//					if (m.Name.Substring (0, 4).ToLower().Equals ("gust") && (m.GetParameters ().Length == 0) ) {
//						int id = -1;
//						if (int.TryParse (m.Name.Substring (4), out id)) dic [id] = m;
//					}
//				}
//			}
//			all_methods.Clear (); int[] array = ( new List<int>(dic.Keys) ).ToArray(); Array.Sort (array);
//			for(int i=0;i<array.Length;i++) all_methods.Add(dic[array[i]]);
//			return all_methods;
//		}

//		private void startThreads() {
//			/*Instancias*/
//			Thread treadPairOMKOMV = new Thread(new ThreadStart(readPair_OMK_OMVs));
//
//			/*Starting*/
//			treadPairOMKOMV.Start();
//			/* Joins*/
//			treadPairOMKOMV.Join();
//		}
   }
}
