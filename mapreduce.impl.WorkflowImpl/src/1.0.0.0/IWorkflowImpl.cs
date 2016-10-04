// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.17020
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using br.ufc.mdcc.hpcshelf.platform.Maintainer;
using System;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingData;
using System.Threading;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvance;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeData;
using System.Collections.Generic;
using br.ufc.mdcc.hpcshelf.platform.maintainer.SAFeHost;
using mapreduce.Workflow;


namespace mapreduce.impl.WorkflowImpl {
    
    
	public class IWorkflowImpl<M> :br.ufc.pargo.hpe.kinds.Computation ,IWorkflow<M> 
		where M:ISAFeHost
	{
        
		private void read_data_source()
		{
			Console.WriteLine ("read_data_source");
		}
			
		private void split_perform()
		{
			Console.WriteLine ("split_perform");
		}

		private void map_perform()
		{
			Console.WriteLine ("map_perform");
		}

		private void shuffle_perform()
		{
			Console.WriteLine ("shuffle_perform");
		}

		private void reduce_perform()
		{
			Console.WriteLine ("reduce_perform");
		}

		private void write_sink_source()
		{
			Console.WriteLine ("write_sink_source");
		}

		public override void main() 
		{
			Console.WriteLine (this.ThisFacetInstance + "/" + this.Rank + ": WORKFLOW 2");

			Task_port_data.TraceFlag = Task_port_map.TraceFlag = Task_port_reduce.TraceFlag = Task_port_shuffle.TraceFlag = Task_port_split_first.TraceFlag = Task_port_split_next.TraceFlag = true;
			Task_binding_data.TraceFlag = Task_binding_shuffle.TraceFlag = Task_binding_split_first.TraceFlag = Task_binding_split_next.TraceFlag = true;

			IActionFutureSet future_iteration = null;

			IActionFuture future_split_first_chunk_ready = null;
		    Task_port_split_first.invoke (ITaskPortAdvance.CHUNK_READY, out future_split_first_chunk_ready);
			int action_id_split_first_chunk_ready = future_split_first_chunk_ready.GetHashCode ();
			future_iteration = future_split_first_chunk_ready.createSet ();

			IActionFuture future_split_next_chunk_ready = null;
			Task_port_split_next.invoke (ITaskPortAdvance.CHUNK_READY, out future_split_next_chunk_ready);
			int action_id_split_next_chunk_ready = future_split_next_chunk_ready.GetHashCode ();
			future_iteration.addAction(future_split_next_chunk_ready)	;

			Console.WriteLine (this.ThisFacetInstance + "/" + this.Rank + ": WORKFLOW 3");

			IActionFuture future_map_chunk_ready = null;
			Task_port_map.invoke (ITaskPortAdvance.CHUNK_READY, out future_map_chunk_ready);
			int action_id_map_chunk_ready = future_map_chunk_ready.GetHashCode ();
			future_iteration.addAction (future_map_chunk_ready);

			Console.WriteLine (this.ThisFacetInstance + "/" + this.Rank + ": WORKFLOW 4");

			IActionFuture future_shuffle_chunk_ready = null; 
			Task_port_shuffle.invoke (ITaskPortAdvance.CHUNK_READY, out future_shuffle_chunk_ready);
			int action_id_shuffle_chunk_ready = future_shuffle_chunk_ready.GetHashCode ();
			future_iteration.addAction (future_shuffle_chunk_ready);

			Console.WriteLine (this.ThisFacetInstance + "/" + this.Rank + ": WORKFLOW 4");

			IActionFuture future_reduce_chunk_ready = null;
			Task_port_reduce.invoke (ITaskPortAdvance.CHUNK_READY, out future_reduce_chunk_ready);
			int action_id_reduce_chunk_ready = future_reduce_chunk_ready.GetHashCode ();
			future_iteration.addAction (future_reduce_chunk_ready);

			Console.WriteLine (this.ThisFacetInstance + "/" + this.Rank + ": WORKFLOW 5");

			IActionFuture future_data_terminate = null; 
			Task_port_data.invoke (ITaskPortData.TERMINATE, out future_data_terminate);
			future_iteration.addAction (future_data_terminate);
			int action_id_data_terminate = future_data_terminate.GetHashCode ();

			Console.WriteLine (this.ThisFacetInstance + "/" + this.Rank + ": WORKFLOW 6-1");

			Task_port_data.invoke (ITaskPortData.READ_SOURCE);

			Console.WriteLine (this.ThisFacetInstance + "/" + this.Rank + ": WORKFLOW 6-2");

			Task_port_split_first.invoke (ITaskPortAdvance.READ_CHUNK);
			Task_port_split_first.invoke (ITaskPortAdvance.PERFORM);

			Console.WriteLine (this.ThisFacetInstance + "/" + this.Rank + ": WORKFLOW 7");

			IList<Thread> bag_of_tasks = new List<Thread> ();


			bool terminate = false;
			do 
			{
				Console.WriteLine (this.ThisFacetInstance + "/" + this.Rank + ": WORKFLOW 8 - LOOP");

				IActionFuture action = future_iteration.waitAny ();

				int action_id = action.GetHashCode();
				if (action_id == action_id_split_first_chunk_ready)
				{
					Thread t1 = new Thread((ThreadStart)delegate() 
						{
							Console.WriteLine ("INVOKE MAPPER READ_CHUNK - BEFORE");
							Task_port_map.invoke (ITaskPortAdvance.READ_CHUNK); 
							Console.WriteLine ("INVOKE MAPPER READ_CHUNK - AFTER");
							IActionFuture future_map_perform = null;
							Thread thread_map_perform = Task_port_map.invoke (ITaskPortAdvance.PERFORM, map_perform, out future_map_perform);

							Console.WriteLine ("END INVOKE SPLITTER CHUNK_READY");
						});

					bag_of_tasks.Add(t1);
					t1.Start();

					Thread t2 = new Thread((ThreadStart)delegate() 
						{ 
							Console.WriteLine ("INVOKE SPLITTER READ_CHUNK");
							Task_port_split_first.invoke (ITaskPortAdvance.READ_CHUNK);
							Console.WriteLine ("INVOKE SPLITTER PERFORM");
							Task_port_split_first.invoke (ITaskPortAdvance.PERFORM);
							Console.WriteLine ("INVOKE SPLITTER READ_CHUNK/PERFORM - AFTER");
							IActionFuture future_split_chunk_ready_ = null;
							Task_port_split_first.invoke (ITaskPortAdvance.CHUNK_READY, out future_split_chunk_ready_);
							action_id_split_first_chunk_ready = future_split_chunk_ready_.GetHashCode ();
							future_iteration.addAction(future_split_chunk_ready_);
						});
					
					Console.WriteLine ("THREAD LAUNCHED 1");

					bag_of_tasks.Add(t2);
					t2.Start();
				}
				else if (action_id == action_id_map_chunk_ready)
				{
					Task_port_map.invoke (ITaskPortAdvance.CHUNK_READY, out future_map_chunk_ready);
					action_id_map_chunk_ready = future_map_chunk_ready.GetHashCode ();
					future_iteration.addAction(future_map_chunk_ready);

					Thread t = new Thread((ThreadStart)delegate() 
						{

							Console.WriteLine ("INVOKE SHUFFLER READ_CHUNK - BEFORE");  // 110 executados (o 48 completou nos pares, mas não progrediu aqui (????), motivo do erro.
							Task_port_shuffle.invoke (ITaskPortAdvance.READ_CHUNK);   // 
							Console.WriteLine ("INVOKE SHUFFLER READ_CHUNK - AFTER");   // 47 completados 
							IActionFuture future_shuffle_perform = null;
							Thread thread_shuffle_perform = Task_port_shuffle.invoke (ITaskPortAdvance.PERFORM, shuffle_perform, out future_shuffle_perform);

							Console.WriteLine ("END INVOKE MAPPER CHUNK_READY");
						});
					t.Start();
					bag_of_tasks.Add(t);
					Console.WriteLine ("THREAD LAUNCHED 2");
				}
				else if (action_id == action_id_shuffle_chunk_ready)
				{
					Task_port_shuffle.invoke (ITaskPortAdvance.CHUNK_READY, out future_shuffle_chunk_ready);
					action_id_shuffle_chunk_ready = future_shuffle_chunk_ready.GetHashCode ();
					future_iteration.addAction(future_shuffle_chunk_ready);

					Thread t = new Thread((ThreadStart)delegate() 
						{
							Console.WriteLine ("INVOKE REDUCER READ_CHUNK - BEFORE");
							Task_port_reduce.invoke (ITaskPortAdvance.READ_CHUNK); // ****
							Console.WriteLine ("INVOKE REDUCER READ_CHUNK - AFTER");
							IActionFuture future_reduce_perform = null;
							Thread thread_reduce_perform = Task_port_reduce.invoke (ITaskPortAdvance.PERFORM, reduce_perform, out future_reduce_perform);

							Console.WriteLine ("END INVOKE SHUFFLER CHUNK_READY");
						});
					t.Start();
					bag_of_tasks.Add(t);
					Console.WriteLine ("THREAD LAUNCHED 3");
				}
				else if (action_id == action_id_reduce_chunk_ready)
				{
					Task_port_reduce.invoke (ITaskPortAdvance.CHUNK_READY, out future_reduce_chunk_ready);
					action_id_reduce_chunk_ready = future_reduce_chunk_ready.GetHashCode ();
					future_iteration.addAction(future_reduce_chunk_ready);

					Thread t = new Thread((ThreadStart)delegate() 
						{
							Console.WriteLine ("INVOKE SPLITTER NEXT READ_CHUNK - BEFORE");
							Task_port_split_next.invoke (ITaskPortAdvance.READ_CHUNK);  // ****
							Console.WriteLine ("INVOKE SPLITTER NEXT READ_CHUNK - AFTER");
							IActionFuture future_split_perform = null;
							Thread thread_split_perform = Task_port_split_next.invoke (ITaskPortAdvance.PERFORM, split_perform, out future_split_perform);

							Console.WriteLine ("END INVOKE REDUCER CHUNK_READY");
						});
					t.Start();
					bag_of_tasks.Add(t);
					Console.WriteLine ("THREAD LAUNCHED 4");
				}
				else if  (action_id == action_id_split_next_chunk_ready)
				{
					Thread t1 = new Thread((ThreadStart)delegate() 
						{
							Console.WriteLine ("INVOKE MAP READ_CHUNK NEXT - BEFORE");  
							Task_port_map.invoke (ITaskPortAdvance.READ_CHUNK);   // 
							Console.WriteLine ("INVOKE MAP READ_CHUNK NEXT - AFTER");    
							IActionFuture future_map_perform = null;
							Thread thread_map_perform = Task_port_map.invoke (ITaskPortAdvance.PERFORM, map_perform, out future_map_perform);

							Console.WriteLine ("END INVOKE SPLIT NEXT CHUNK_READY");
						});

					bag_of_tasks.Add(t1);
					t1.Start();

					Thread t2 = new Thread((ThreadStart)delegate() 
						{ 
							Console.WriteLine ("INVOKE SPLITTER NEXT READ_CHUNK");
							Task_port_split_next.invoke (ITaskPortAdvance.READ_CHUNK);
							Console.WriteLine ("INVOKE SPLITTER NEXT PERFORM");
							Task_port_split_next.invoke (ITaskPortAdvance.PERFORM);
							Console.WriteLine ("INVOKE SPLITTER NEXT READ_CHUNK/PERFORM - AFTER");

							IActionFuture future_split_next_chunk_ready_ = null;
							Task_port_split_next.invoke (ITaskPortAdvance.CHUNK_READY, out future_split_next_chunk_ready_);
							action_id_split_next_chunk_ready = future_split_next_chunk_ready_.GetHashCode ();
							future_iteration.addAction(future_split_next_chunk_ready_);
						});

					Console.WriteLine ("THREAD LAUNCHED 1");

					bag_of_tasks.Add(t2);
					t2.Start();

					Console.WriteLine ("THREAD LAUNCHED 5");
				}	
				else if (action_id == action_id_data_terminate)
				{
					Thread t = new Thread((ThreadStart)delegate() 
						{
							Console.WriteLine ("INVOKE DATA WRITE_SINK - BEFORE");
							Task_port_data.invoke (ITaskPortData.WRITE_SINK);
							Console.WriteLine ("INVOKE DATA WRITE_SINK - AFTER");
							terminate = true;
						});
					t.Start();
					bag_of_tasks.Add(t);
					Console.WriteLine ("THREAD LAUNCHED 6");
				}
				else
				{
					Console.WriteLine("UNEXPECTED ERROR: ACTION FUTURE NOT RECOGNIZED ! ");
				}

			} while (!terminate) ;

			Console.WriteLine("WORKFLOW FINISHED ! ");

			foreach (Thread t in bag_of_tasks)
				t.Join ();

        }

		private ITaskPort<ITaskPortTypeData> task_port_data = null;
		protected ITaskPort<ITaskPortTypeData> Task_port_data 
		{ 
			get 
			{   
				if (task_port_data == null)
					task_port_data = (ITaskPort<ITaskPortTypeData>)this.Services.getPort ("task_port_data");
				return task_port_data;
			}
		}

		private ITaskPort<ITaskPortTypeAdvance> task_port_split_first = null;
		protected ITaskPort<ITaskPortTypeAdvance> Task_port_split_first
		{ 
			get 
			{   if (task_port_split_first == null)
					task_port_split_first = (ITaskPort<ITaskPortTypeAdvance>) this.Services.getPort ("task_port_split_first");
				return task_port_split_first;
			}
		}

		private ITaskPort<ITaskPortTypeAdvance> task_port_split_next = null;
		protected ITaskPort<ITaskPortTypeAdvance> Task_port_split_next
		{ 
			get 
			{   if (task_port_split_next == null)
				task_port_split_next = (ITaskPort<ITaskPortTypeAdvance>) this.Services.getPort ("task_port_split_next");
				return task_port_split_next;
			}
		}

		private ITaskPort<ITaskPortTypeAdvance> task_port_shuffle = null;
		protected ITaskPort<ITaskPortTypeAdvance> Task_port_shuffle 
		{ 
			get 
			{   
				if (task_port_shuffle == null)
					task_port_shuffle = (ITaskPort<ITaskPortTypeAdvance>) this.Services.getPort ("task_port_shuffle");
				return task_port_shuffle;
			}
		}

		private ITaskPort<ITaskPortTypeAdvance> task_port_reduce = null;
		protected ITaskPort<ITaskPortTypeAdvance> Task_port_reduce 
		{ 
			get 
			{   
				if (task_port_reduce == null)
					task_port_reduce = (ITaskPort<ITaskPortTypeAdvance>) this.Services.getPort ("task_port_reduce");
				return task_port_reduce;
			}
		}

		private ITaskPort<ITaskPortTypeAdvance> task_port_map = null;
		protected ITaskPort<ITaskPortTypeAdvance> Task_port_map 
		{ 
			get 
			{  
				if (task_port_map == null)
					task_port_map = (ITaskPort<ITaskPortTypeAdvance>) this.Services.getPort ("task_port_map");
				return task_port_map;
			}
		}

		private ITaskBindingAdvance task_binding_shuffle; 
		public ITaskBindingAdvance Task_binding_shuffle 
		{
			get 
			{  
				if (task_binding_shuffle == null)
					task_binding_shuffle = (ITaskBindingAdvance) this.Services.getPort ("task_binding_shuffle");
				return task_binding_shuffle;
			}
		}

		private  ITaskBindingAdvance task_binding_split_first; 
		public ITaskBindingAdvance Task_binding_split_first 
		{
			get 
			{  
				if (task_binding_split_first == null)
					task_binding_split_first = (ITaskBindingAdvance) this.Services.getPort ("task_binding_split_first");
				return task_binding_split_first;
			}
		}

		private  ITaskBindingAdvance task_binding_split_next; 
		public ITaskBindingAdvance Task_binding_split_next
		{
			get 
			{  
				if (task_binding_split_next == null)
					task_binding_split_next = (ITaskBindingAdvance) this.Services.getPort ("task_binding_split_next");
				return task_binding_split_next;
			}
		}


		private ITaskBindingAdvance task_reduce; 
		public ITaskBindingAdvance Task_reduce 
		{
			get 
			{  
				if (task_reduce == null)
					task_reduce = (ITaskBindingAdvance) this.Services.getPort ("task_reduce");
				return task_reduce;
			}
		}

		private ITaskBindingAdvance task_map;
		public ITaskBindingAdvance Task_map 
		{
			get 
			{  
				if (task_map == null)
					task_map = (ITaskBindingAdvance) this.Services.getPort ("task_map");
				return task_map;
			}
		}

		private ITaskBindingData task_binding_data;
		public ITaskBindingData Task_binding_data 
		{
			get 
			{   
				if (task_binding_data == null)
					task_binding_data = (ITaskBindingData) this.Services.getPort ("task_binding_data");
				return task_binding_data;
			}
		}

    }
}