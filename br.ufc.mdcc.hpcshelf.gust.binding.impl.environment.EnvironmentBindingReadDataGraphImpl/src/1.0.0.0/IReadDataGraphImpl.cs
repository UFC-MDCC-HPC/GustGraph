using System;
using System.Collections.Generic;
using System.Threading;
using br.ufc.mdcc.hpcshelf.gust.binding.environment.EnvironmentBindingReadDataGraph;//
using br.ufc.mdcc.hpcshelf.gust.port.environment.PortTypeDataSourceGraphInterface;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;

namespace br.ufc.mdcc.hpcshelf.gust.binding.impl.environment.EnvironmentBindingReadDataGraphImpl
{
    public class IReadDataGraphImpl<S>: BaseIReadDataGraphImpl<S>, IReadDataGraph<S>
		where S:IPortTypeDataSourceGraphInterface {
		public override void main(){ }

		private Thread thread_file_reader = null;

		public override void after_initialize() 
        {
            startReadSource ();
		}

		private void ask_for_next_item() {
			e.Set ();
		}

		AutoResetEvent e = new AutoResetEvent(false);
		ManualResetEvent client_ok = new ManualResetEvent(false); 
		AutoResetEvent server_ok = new AutoResetEvent(false);

		public void startReadSource() {
			thread_file_reader = new Thread (file_reader);
			thread_file_reader.Start ();
		}

		private IPortTypeIterator client = null;
		public IPortTypeIterator Client { 
			get {
				client_ok.WaitOne ();
				return client; 
			} 
		}
		private S server = default(S);
		public S Server { 
			set { 
				server = value; 
                client = (IPortTypeIterator)(server.IteratorInstance);
				client.IsEmptyAction = ask_for_next_item;
				server_ok.Set ();
				client_ok.Set ();
			} 
		}

		private static int CHUNK_SIZE = 50;

		int counter_write_chunk = 0;
		int counter_write_global = 0;

		private void file_reader() {

            Console.WriteLine("STARTING FILE READER 1");

            server_ok.WaitOne();

			Console.WriteLine("STARTING FILE READER 2");

            IEnumerable<object> enumerable_obj = server.fetchContentsKeyValue ();
			foreach (object item_kv in enumerable_obj) 
            {
				e.WaitOne (); 
                Console.WriteLine("IReadGraphImpl - NEW ITEM " + item_kv);
				client.put(item_kv);

				counter_write_chunk++;
				counter_write_global++;

				if (counter_write_chunk >= CHUNK_SIZE) {
					Console.WriteLine ("NEW CHUNK size=" + counter_write_chunk);
					counter_write_chunk = 0;
					client.finish ();
				}
			}
			// CLOSE THE LAST CHUNK.
			if (counter_write_chunk > 0)
				client.finish ();

			// SEND ITERATION TERMINATION CHUNK.
			client.finish ();

			// SEND COMPUTATION TERMINATION CHUNK.
			client.finish ();

			Console.WriteLine ("FINISHING READING DATA SOURCE");
		}
	}
}
