using System;
using MPI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace br.ufc.mdcc.hpc.storm.binding.channel.Binding
{
	/*
	public enum AliencommunicatorOperation {
		SEND, 
		RECEIVE, 
		SEND_ARRAY,
		RECEIVE_ARRAY,
		PROBE,
		ALL_GATHER,
		ALL_GATHER_FLATTENED,
		ALL_REDUCE,
		ALL_REDUCE_ARRAY,
		ALL_TO_ALL,
		ALL_TO_ALL_FLATTENED,
		REDUCE_SCATTER,
		BROADCAST,
		BROADCAST_ARRAY,
		SCATTER,
		SCATTER_FROM_FLATTENED,
		GATHER,
		GATHER_FLATTENED,
		REDUCE,
		REDUCE_ARRAY
	};
	*/

	public class AliencommunicatorOperation {
		public const int SEND = 0; 
		public const int RECEIVE = 1;
		public const int SEND_ARRAY = 2;
		public const int RECEIVE_ARRAY = 3;
		public const int PROBE = 4;
		public const int ALL_GATHER = 5;
		public const int ALL_GATHER_FLATTENED= 6;
		public const int ALL_REDUCE = 7;
		public const int ALL_REDUCE_ARRAY = 8;
		public const int ALL_TO_ALL = 9;
		public const int ALL_TO_ALL_FLATTENED = 10;
		public const int REDUCE_SCATTER = 11;
		public const int BROADCAST = 12;
		public const int BROADCAST_ARRAY = 13;
		public const int SCATTER = 14;
		public const int SCATTER_FROM_FLATTENED = 15;
		public const int GATHER = 16;
		public const int GATHER_FLATTENED = 17;
		public const int REDUCE = 18;
		public const int REDUCE_ARRAY = 19;
		public const int SYNC_SEND = 20; 
	};

	public interface Aliencommunicator
	{
		#region point-to-point operations

		// Value versions ...

		void Send<T> (T value, Tuple<int,int> dest, int tag);

		//		void SendReceive<T> (T inValue, int dest, int tag, out T outValue); /* ok */
		//		void SendReceive<T> (T inValue, int dest, int sendTag, int source, int recvTag, out T outValue); /* ok */
		//		void SendReceive<T> (T inValue, int dest, int sendTag, int source, int recvTag, out T outValue, out CompletedStatus status);

		T Receive<T> (Tuple<int,int> source, int tag); /* ok */
		void Receive<T>(Tuple<int,int> source, int tag, out T value); /* ok */
		void Receive<T> (Tuple<int,int> source, int tag, out T value, out CompletedStatus status);

		IRequest ImmediateSend<T> (T value, Tuple<int,int> dest, int tag);
		IReceiveRequest ImmediateReceive<T> (Tuple<int,int> source, int tag);

		// Array versions ... 
		void Send<T> (T[] values, Tuple<int,int> dest, int tag);

		void Receive<T> (Tuple<int,int> source, int tag, ref T[] values); /* ok */
		void Receive<T> (Tuple<int,int> source, int tag, ref T[] values, out CompletedStatus status);

		IRequest ImmediateSend<T> (T[] values, Tuple<int,int> dest, int tag);
		IReceiveRequest ImmediateReceive<T> (Tuple<int,int> source, int tag, T[] values);

		// Probe.

		//TODO		Status Probe (Tuple<int,int> source, int tag);
		//TODO		Status ImmediateProbe (Tuple<int,int> source, int tag);

		//		void SendReceive<T>(T[] inValues, int dest, int tag, ref T[] outValues); /* ok */
		//		void SendReceive<T>(T[] inValues, int dest, int sendTag, int source, int recvTag, ref T[] outValues); /* ok */
		//		void SendReceive<T> (T[] inValues, int dest, int sendTag, int source, int recvTag, ref T[] outValues, out CompletedStatus status);

		#endregion point-to-point operations

		#region collective operations

		#region AllToAll

		//TODO		T[] Allgather<T> (int facet, T value);
		//TODO		void Allgather<T> (int facet, T inValue, ref T[] outValues);

		//TODO		void AllgatherFlattened<T> (int facet, T[] inValues, int count, ref T[] outValues);
		//TODO		void AllgatherFlattened<T> (int facet, T[] inValues, int[] counts, ref T[] outValues);

		//TODO		T Allreduce<T>(int facet, T value, ReductionOperation<T> op);
		//TODO		T[] Allreduce<T> (int facet, T[] values, ReductionOperation<T> op);
		//TODO		void Allreduce<T> (int facet, T[] inValues, ReductionOperation<T> op, ref T[] outValues);

		//TODO		T[] Alltoall<T> (int facet, T[] values);
		//TODO		void Alltoall<T> (int facet, T[] inValues, ref T[] outValues);

		//TODO void AlltoallFlattened<T> (int facet, T[] inValues, int[] sendCounts, int[] recvCounts, ref T[] outValues);

		//TODO		T[] ReduceScatter<T> (int facet, T[] values, ReductionOperation<T> op, int[] counts);
		//TODO		void ReduceScatter<T> (int facet, T[] inValues, ReductionOperation<T> op, int[] counts, ref T[] outValues);

		#endregion AllToAll


		#region OneToAll

		//TODO		void Broadcast<T> (int facet, ref T value, int root);
		//TODO		void Broadcast<T> (int facet, ref T[] values, int root);

		//TODO		void Scatter<T> (int facet, T[] values);
		//TODO		T Scatter<T>(int facet, int root);
		//TODO		void Scatter<T>(int facet);

		//TODO		void ScatterFromFlattened<T> (int facet, T[] inValues, int count);
		//TODO		void ScatterFromFlattened<T> (int facet, T[] inValues, int[] counts);
		//TODO		void ScatterFromFlattened<T> (int facet, int count, int root, ref T[] outValues);
		//TODO		void ScatterFromFlattened<T> (int facet, int[] counts, int root, ref T[] outValues);
		//TODO		void ScatterFromFlattened<T> (int facet);
		//TODO		void ScatterFromFlattened<T> (int facet, T[] inValues, int count, int root, ref T[] outValues);
		//TODO		void ScatterFromFlattened<T> (int facet, T[] inValues, int[] counts, int root, ref T[] outValues);

		#endregion OneToAll


		#region AllToOne

		//TODO		T[] Gather<T> (int facet, T value, int root);
		//TODO		T[] Gather<T> (int facet, int root);
		//TODO		void Gather<T>(int facet);
		//TODO		void Gather<T>(int facet, T inValue, int root, ref T[] outValues);

		//TODO		void GatherFlattened<T>(int facet, int count, ref T[] outValues);
		//TODO		T[] GatherFlattened<T>(int facet, int count);
		//TODO		void GatherFlattened<T> (int facet, T[] inValues, int root);
		//TODO		void GatherFlattened<T>(int facet);
		//TODO		void GatherFlattened<T> (int facet, int[] counts, ref T[] outValues);
		//TODO		T[] GatherFlattened<T>(int facet, int[] counts);

		//TODO		T Reduce<T> (int facet, T value, ReductionOperation<T> op, int root);
		//TODO		T[] Reduce<T>(int facet, T[] values, ReductionOperation<T> op, int root);
		//TODO		void Reduce<T>(int facet, T[] inValues, ReductionOperation<T> op, int root, ref T[] outValues);

		#endregion AllToOne


		#endregion collective operations

	}


	public interface Status 
	{
		Tuple<int,int> Source { get; }
		int Tag { get; }
		int? Count (Type type);
		bool Cancelled { get; }
	}

	public interface CompletedStatus : Status
	{
		int? Count { get; }
	}

	public class SAFeStatus : Status
	{

		/// <summary>
		///   Constructs a <code>Status</code> object from a low-level <see cref="Unsafe.MPI_Status"/> structure.
		/// </summary>
		internal SAFeStatus(Tuple<int,int> source, int tag)
		{
			this.source = source;
			this.tag = tag;
		}

		Tuple<int,int> source;

		/// <summary>
		/// The rank of the process that sent the message.
		/// </summary>
		public Tuple<int,int> Source
		{
			get
			{
				return source;
			}
		}

		int tag;

		/// <summary>
		/// The tag used to send the message.
		/// </summary>
		public int Tag
		{
			get
			{
				return tag;
			}
		}

		/// <summary>
		/// Determine the number of elements transmitted by the communication
		/// operation associated with this object.
		/// </summary>
		/// <param name="type">
		///   The type of data that will be stored in the message.
		/// </param>
		/// <returns>
		///   If the type of the data is a value type, returns the number
		///   of elements in the message. Otherwise, returns <c>null</c>,
		///   because the number of elements stored in the message won't
		///   be known until the message is received.
		/// </returns>
		public int? Count(Type type)
		{
			// TODO:
			return null;
		}

		/// <summary>
		/// Whether the communication was cancelled before it completed.
		/// </summary>
		public bool Cancelled
		{
			get
			{
				// TODO: cancel functionality not implemented ...
				return false;
			}
		}
	}

	/// <summary>
	/// Information about a specific message that has already been
	/// transferred via MPI.
	/// </summary>
	public class SAFeCompletedStatus : SAFeStatus, CompletedStatus
	{
		/// <summary>
		///   Constructs a <code>Status</code> object from a low-level <see cref="Unsafe.MPI_Status"/> structure
		///   and a count of the number of elements received.
		/// </summary>
		internal SAFeCompletedStatus(Tuple<int,int> source, int tag, int count) : base(source, tag)
		{
			this.count = count;
		}

		internal SAFeCompletedStatus(Tuple<int,int> source, int tag) : base(source, tag)
		{
		}

		public static CompletedStatus createStatus(Tuple<int,int> source, int tag, int count)
		{
			return new SAFeCompletedStatus(source, tag, count);
		}

		public static CompletedStatus createStatus(Tuple<int,int> source, int tag)
		{
			return new SAFeCompletedStatus(source, tag);
		}

		private int? count = null;

		/// <summary>
		/// Determines the number of elements in the transmitted message.
		/// </summary>
		public int? Count
		{
			get { return count; } set { count = value; }
		}

	}





	public class MPIStatus : Status
	{
		private MPI.Status internal_status;

		/// <summary>
		///   Constructs a <code>Status</code> object from a low-level <see cref="Unsafe.MPI_Status"/> structure.
		/// </summary>
		internal MPIStatus(MPI.Status internal_status, Tuple<int,int> source)
		{
			this.source = source;
			this.internal_status = internal_status;
		}

		Tuple<int,int> source;

		/// <summary>
		/// The rank of the process that sent the message.
		/// </summary>
		public Tuple<int,int> Source
		{
			get
			{
				return source;
			}
		}

		/// <summary>
		/// The tag used to send the message.
		/// </summary>
		public int Tag
		{
			get
			{
				return internal_status.Tag;
			}
		}

		/// <summary>
		/// Determine the number of elements transmitted by the communication
		/// operation associated with this object.
		/// </summary>
		/// <param name="type">
		///   The type of data that will be stored in the message.
		/// </param>
		/// <returns>
		///   If the type of the data is a value type, returns the number
		///   of elements in the message. Otherwise, returns <c>null</c>,
		///   because the number of elements stored in the message won't
		///   be known until the message is received.
		/// </returns>
		public int? Count(Type type)
		{
			return internal_status.Count(type);
		}

		/// <summary>
		/// Whether the communication was cancelled before it completed.
		/// </summary>
		public bool Cancelled
		{
			get
			{
				return internal_status.Cancelled;
			}
		}

	}

	/// <summary>
	/// Information about a specific message that has already been
	/// transferred via MPI.
	/// </summary>
	public class MPICompletedStatus : MPIStatus, CompletedStatus
	{
		private MPI.CompletedStatus internal_status;

		/// <summary>
		///   Constructs a <code>Status</code> object from a low-level <see cref="Unsafe.MPI_Status"/> structure
		///   and a count of the number of elements received.
		/// </summary>
		internal MPICompletedStatus(MPI.CompletedStatus internal_status, Tuple<int,int> source) : base(internal_status, source)
		{
			this.internal_status = internal_status;
		}

		public static CompletedStatus createStatus(MPI.CompletedStatus internal_status, Tuple<int,int> source)
		{
			return new MPICompletedStatus(internal_status, source);
		}

		/// <summary>
		/// Determines the number of elements in the transmitted message.
		/// </summary>
		public int? Count {
			get { return internal_status.Count (); }
		}

	}

	public interface IRequest
	{
		void registerWaitingSet (AutoResetEvent waiting_set);
		void unregisterWaitingSet (AutoResetEvent waiting_set);
		CompletedStatus Wait();
		CompletedStatus Test();
		void Cancel ();
    }

	public class Request : IRequest // Without MPI
	{
		private Tuple<int,int> source;
		int tag;

		private ManualResetEvent e;
		private Thread waiting_request = null;
		protected ManualResetEvent initial_signal = new ManualResetEvent (false);
		private bool completed = false;

		bool completed_request = false;


		internal Request(ManualResetEvent e, Tuple<int,int> source, int tag)
		{
			this.e = e;
			this.source = source;
			this.tag = tag;
			new Thread (new ThreadStart (delegate() {
				e.WaitOne();
				completed_request = true;
			})).Start();

		}


		private object wait_lock = new object ();

		private IList<AutoResetEvent> waiting_sets = new List<AutoResetEvent>();

		public void registerWaitingSet(AutoResetEvent waiting_set)
		{   
			waiting_request = new Thread(new ThreadStart(delegate 
				{
					while (true) 
					{
						initial_signal.WaitOne();
						e.WaitOne();
						lock (wait_lock)
						{
							completed = true;
							foreach (AutoResetEvent ws in waiting_sets)
								ws.Set();
						}
					}
				}));

			waiting_request.Start ();

			lock (wait_lock) 
			{
				if (completed)
					waiting_set.Set ();
				else 
				{
					waiting_sets.Add (waiting_set);
					initial_signal.Set ();
				}
			}
		}

		public void unregisterWaitingSet(AutoResetEvent waiting_set)
		{
			waiting_sets.Remove (waiting_set);
			initial_signal.Reset ();
			waiting_request.Abort ();
			waiting_request = null;
		}

		/// <summary>
		/// Wait until this non-blocking operation has completed.
		/// </summary>
		/// <returns>
		///   Information about the completed communication operation.
		/// </returns>
		public CompletedStatus Wait()
		{
			e.WaitOne ();
			return SAFeCompletedStatus.createStatus (source, tag);
		}

		/// <summary>
		/// Determine whether this non-blocking operation has completed.
		/// </summary>
		/// <returns>
		/// If the non-blocking operation has completed, returns information
		/// about the completed communication operation. Otherwise, returns
		/// <c>null</c> to indicate that the operation has not completed.
		/// </returns>
		public CompletedStatus Test() 
		{
			return completed_request ? SAFeCompletedStatus.createStatus (source, tag) : null;
		}

		/// <summary>
		/// Cancel this communication request.
		/// </summary>
		public void Cancel() 
		{
			// TODO: cancel functionality not implemented ...
			//internal_request.Cancel ();
		}

		public static IRequest createRequest(ManualResetEvent e, Tuple<int,int> source, int tag)
		{
			return new Request(e, source, tag);
		}

		// Convert an object to a byte array
		protected static byte[] ObjectToByteArray(Object obj)
		{
			if(obj == null)
				return null;
			BinaryFormatter bf = new BinaryFormatter();
			MemoryStream ms = new MemoryStream();
			bf.Serialize(ms, obj);
			return ms.ToArray();
		}

		protected static Object ByteArrayToObject(byte[] arrBytes)
		{
			MemoryStream memStream = new MemoryStream();
			BinaryFormatter binForm = new BinaryFormatter();
			memStream.Write(arrBytes, 0, arrBytes.Length);
			memStream.Seek(0, SeekOrigin.Begin);
			Object obj = (Object) binForm.Deserialize(memStream);
			return obj;
		}

	}




	/// <summary>
	/// A non-blocking communication request.
	/// </summary>
	/// <remarks>
	/// Each request object refers to a single
	/// communication operation, such as non-blocking send 
	/// (see <see cref="Communicator.ImmediateSend&lt;T&gt;(T, int, int)"/>)
	/// or receive. Non-blocking operations may progress in the background, and can complete
	/// without any user intervention. However, it is crucial that outstanding communication
	/// requests be completed with a successful call to <see cref="Wait"/> or <see cref="Test"/>
	/// before the request object is lost.
	/// </remarks>
	public class MPIRequest : IRequest
	{
		private MPI.Request internal_request;
		private Tuple<int,int> source;

		private Thread waiting_request = null;
		protected ManualResetEvent initial_signal = new ManualResetEvent (false);
		private bool completed = false;

		internal MPIRequest(MPI.Request internal_request, Tuple<int,int> source)
		{
			this.internal_request = internal_request;
			this.source = source;
		}


		private object wait_lock = new object ();

		private IList<AutoResetEvent> waiting_sets = new List<AutoResetEvent>();

		public void registerWaitingSet(AutoResetEvent waiting_set)
		{   
			waiting_request = new Thread(new ThreadStart(delegate 
			{
					while (true) 
					{
						initial_signal.WaitOne();
						internal_request.Wait();
						lock (wait_lock)
						{
						    completed = true;
							foreach (AutoResetEvent ws in waiting_sets)
								ws.Set();
						}
					}
			}));
			
			waiting_request.Start ();

			lock (wait_lock) 
			{
				if (completed)
					waiting_set.Set ();
				else 
				{
					waiting_sets.Add (waiting_set);
					initial_signal.Set ();
				}
			}
		}

		public void unregisterWaitingSet(AutoResetEvent waiting_set)
		{
			waiting_sets.Remove (waiting_set);
			initial_signal.Reset ();
			waiting_request.Abort ();
			waiting_request = null;
		}

		/// <summary>
		/// Wait until this non-blocking operation has completed.
		/// </summary>
		/// <returns>
		///   Information about the completed communication operation.
		/// </returns>
		public CompletedStatus Wait()
		{
			MPI.CompletedStatus internal_status = internal_request.Wait ();
			return MPICompletedStatus.createStatus (internal_status, source);
		}

		/// <summary>
		/// Determine whether this non-blocking operation has completed.
		/// </summary>
		/// <returns>
		/// If the non-blocking operation has completed, returns information
		/// about the completed communication operation. Otherwise, returns
		/// <c>null</c> to indicate that the operation has not completed.
		/// </returns>
		public CompletedStatus Test() 
		{
			MPI.CompletedStatus internal_status = internal_request.Test ();
			return internal_status != null ? MPICompletedStatus.createStatus (internal_status, source) : null;
		}

		/// <summary>
		/// Cancel this communication request.
		/// </summary>
		public void Cancel() 
		{
			internal_request.Cancel ();
		}

		public static IRequest createRequest(MPI.Request internal_status, Tuple<int,int> source)
		{
			return new MPIRequest(internal_status, source);
		}

		// Convert an object to a byte array
		protected static byte[] ObjectToByteArray(Object obj)
		{
			if(obj == null)
				return null;
			BinaryFormatter bf = new BinaryFormatter();
			MemoryStream ms = new MemoryStream();
			bf.Serialize(ms, obj);
			return ms.ToArray();
		}

		protected static Object ByteArrayToObject(byte[] arrBytes)
		{
			MemoryStream memStream = new MemoryStream();
			BinaryFormatter binForm = new BinaryFormatter();
			memStream.Write(arrBytes, 0, arrBytes.Length);
			memStream.Seek(0, SeekOrigin.Begin);
			Object obj = (Object) binForm.Deserialize(memStream);
			return obj;
		}

	}

	public interface IReceiveRequest : IRequest
	{
		object GetValue ();
	}

	public abstract class ReceiveRequest : Request, IReceiveRequest
	{
		internal ReceiveRequest(ManualResetEvent e, Tuple<int,int> source, int tag) : base(e, source, tag)
		{
		}
		/// <summary>
		/// Retrieve the value received via this communication. The value
		/// will only be available when the communication has completed.
		/// </summary>
		/// <returns>The value received by this communication.</returns>
		public abstract object GetValue ();
	}
	/// <summary>
	/// A non-blocking receive request. 
	/// </summary>
	/// <remarks>
	/// This class allows one to test a receive
	/// request for completion, wait for completion of a request, cancel a request,
	/// or extract the value received by this communication request.
	/// </remarks>
	public abstract class MPIReceiveRequest : MPIRequest, IReceiveRequest
	{

		internal MPIReceiveRequest(MPI.ReceiveRequest internal_request, Tuple<int,int> source) : base(internal_request, source)
		{
		}
		/// <summary>
		/// Retrieve the value received via this communication. The value
		/// will only be available when the communication has completed.
		/// </summary>
		/// <returns>The value received by this communication.</returns>
		public abstract object GetValue ();
    }

	/// <summary>
	/// A non-blocking receive request. 
	/// </summary>
	/// <remarks>
	/// This class allows one to test a receive
	/// request for completion, wait for completion of a request, cancel a request,
	/// or extract the value received by this communication request.
	/// </remarks>
	public class ValueReceiveRequest<T> : ReceiveRequest
	{
		Tuple<int,int> source = null; 
		int? tag = null;

		internal ValueReceiveRequest(ManualResetEvent e, Tuple<int,int> source, int tag) : base(e, source, tag)
		{
			this.source = source;
			this.tag = tag;
		}

		private object value = null;

		/// <summary>
		/// Retrieve the value received via this communication. The value
		/// will only be available when the communication has completed.
		/// </summary>
		/// <returns>The value received by this communication.</returns>
		public override object GetValue()
		{
			return value;
		}

		public void SetValue(byte[] v)
		{
			value = (T) ByteArrayToObject(v);
		}

		public static new ValueReceiveRequest<T> createRequest(ManualResetEvent e, Tuple<int,int> source, int tag)
		{
			return new ValueReceiveRequest<T> (e, source, tag);
		}

		public new CompletedStatus Wait()
		{
			SAFeCompletedStatus status = (SAFeCompletedStatus) base.Wait ();
			status.Count = 1;
			return status;
		}

		public new CompletedStatus Test() 
		{
			SAFeCompletedStatus status = (SAFeCompletedStatus) base.Test ();

			if (status != null)
				status.Count = 1;

			return status;
		}
	}


	/// <summary>
	/// A non-blocking receive request. 
	/// </summary>
	/// <remarks>
	/// This class allows one to test a receive
	/// request for completion, wait for completion of a request, cancel a request,
	/// or extract the value received by this communication request.
	/// </remarks>
	public class MPIValueReceiveRequest<T> : MPIReceiveRequest
	{
		private MPI.ReceiveRequest internal_request;

		internal MPIValueReceiveRequest(MPI.ReceiveRequest internal_request, Tuple<int,int> source) : base(internal_request, source)
		{
			this.internal_request = internal_request;
		}

		/// <summary>
		/// Retrieve the value received via this communication. The value
		/// will only be available when the communication has completed.
		/// </summary>
		/// <returns>The value received by this communication.</returns>
		public override object GetValue()
		{
			byte[] v = (byte[]) this.internal_request.GetValue ();
			return (T) ByteArrayToObject(v);
		}

		public static MPIValueReceiveRequest<T> createRequest(MPI.ReceiveRequest internal_status, Tuple<int,int> source)
		{
			return new MPIValueReceiveRequest<T>(internal_status, source);
		}

	}

	/// <summary>
	/// A non-blocking receive request. 
	/// </summary>
	/// <remarks>
	/// This class allows one to test a receive
	/// request for completion, wait for completion of a request, cancel a request,
	/// or extract the value received by this communication request.
	/// </remarks>
	public class ArrayReceiveRequest<T> : ReceiveRequest
	{
		private T[] values = null;
		private byte[] v = null;
		Tuple<int,int> source = null;
		int? tag = null; 

		internal ArrayReceiveRequest(ManualResetEvent e, Tuple<int,int> source, int tag, T[] values) : base(e,source,tag)
		{
			this.values = values;
			this.source = source;
			this.tag = null;
		}

		/// <summary>
		/// Retrieve the value received via this communication. The value
		/// will only be available when the communication has completed.
		/// </summary>
		/// <returns>The value received by this communication.</returns>
		public override object GetValue()
		{
			if (v == null)
				return null;

			T[] values_= (T[]) ByteArrayToObject(v);

			// Copy the received values to the destination array (forcing original MPI semantics)
			int size = values.Length <= values_.Length ? values.Length : values_.Length;
			for (int i=0; i<size; i++)
				values[i] = values_[i];

			return values;
		}

		public void SetValue(byte[] v)
		{
			values = (T[]) ByteArrayToObject(v);
		}


		public static ArrayReceiveRequest<T> createRequest(ManualResetEvent e, Tuple<int,int> source, int tag, T[] values)
		{
			return new ArrayReceiveRequest<T>(e, source, tag, values);
		}

		public new CompletedStatus Wait()
		{
			SAFeCompletedStatus status = (SAFeCompletedStatus) base.Wait ();
			status.Count = values.Length;
			return status;
		}

		public new CompletedStatus Test() 
		{
			SAFeCompletedStatus status = (SAFeCompletedStatus) base.Test ();

			if (status != null)
				status.Count = values.Length;

			return status;
		}

	}


	/// <summary>
	/// A non-blocking receive request. 
	/// </summary>
	/// <remarks>
	/// This class allows one to test a receive
	/// request for completion, wait for completion of a request, cancel a request,
	/// or extract the value received by this communication request.
	/// </remarks>
	public class MPIArrayReceiveRequest<T> : MPIReceiveRequest
	{
		private MPI.ReceiveRequest internal_request;
		private T[] values = null;

		internal MPIArrayReceiveRequest(MPI.ReceiveRequest internal_request, Tuple<int,int> source, T[] values) : base(internal_request, source)
		{
			this.internal_request = internal_request;
			this.values = values;
		}

		/// <summary>
		/// Retrieve the value received via this communication. The value
		/// will only be available when the communication has completed.
		/// </summary>
		/// <returns>The value received by this communication.</returns>
		public override object GetValue()
		{
			byte[] v = (byte[]) this.internal_request.GetValue ();
			T[] values_= (T[]) ByteArrayToObject(v);

			// Copy the received values to the destination array (forcing original MPI semantics)
			int size = values.Length <= values_.Length ? values.Length : values_.Length;
			for (int i=0; i<size; i++)
				values[i] = values_[i];

			return values;
		}

		public static MPIArrayReceiveRequest<T> createRequest(MPI.ReceiveRequest internal_status, Tuple<int,int> source, T[] values)
		{
			return new MPIArrayReceiveRequest<T>(internal_status, source, values);
		}


	}


	/// <summary>
	/// A request list contains a list of outstanding MPI requests. 
	/// </summary>
	/// 
	/// <remarks>
	/// The requests in a <c>RequestList</c>
	/// are typically non-blocking send or receive operations (e.g.,
	/// <see cref="Communicator.ImmediateSend&lt;T&gt;(T, int, int)"/>,
	/// <see cref="Communicator.ImmediateReceive&lt;T&gt;(int, int)"/>). The
	/// request list provides the ability to operate on the set of MPI requests
	/// as a whole, for example by waiting until all requests complete before
	/// returning or testing whether any of the requests have completed.
	/// </remarks>
	public class RequestList
	{
		/// <summary>
		/// Create a new, empty request list.
		/// </summary>
		public RequestList()
		{
			this.requests = new List<IRequest>();
		}



		/// <summary>
		/// Add a new request to the request list.
		/// </summary>
		/// <param name="request">The request to add.</param>
		public void Add(IRequest request)
		{
			requests.Add(request);

			if (sync_request != null)
				request.registerWaitingSet (sync_request);
		}

		/// <summary>
		/// Remove a request from the request list.
		/// </summary>
		/// <param name="request">Request to remove.</param>
		public void Remove(IRequest request)
		{
			requests.Remove(request);
		}

		/// <summary>
		/// Retrieves the number of elements in this list of requests.
		/// </summary>
		public int Count
		{
			get
			{
				return this.requests.Count;
			}
		}

		AutoResetEvent sync_request = null;

		/// <summary>
		/// Waits until any request has completed. That request will then be removed 
		/// from the request list and returned.
		/// </summary>
		/// <returns>The completed request, which has been removed from the request list.</returns>
		public IRequest WaitAny()
		{
			if (requests.Count == 0)
				throw new ArgumentException("Cannot call MPI.RequestList.WaitAny with an empty request list");

			sync_request = new AutoResetEvent (false);

			foreach (IRequest req_item in requests)
				req_item.registerWaitingSet (sync_request);

			sync_request.WaitOne ();
			sync_request = null;

			IRequest req = this.TestAny ();

			foreach (IRequest req_item in requests)
				req_item.unregisterWaitingSet (sync_request);

			return req;


/*			while (true)
			{
				Thread.Sleep (200);
				Request req = TestAny();
				if (req != null)
					return req;
			}*/

		}

		/// <summary>
		/// Determines whether any request has completed. If so, that request will be removed
		/// from the request list and returned. 
		/// </summary>
		/// <returns>
		///   The first request that has completed, if any. Otherwise, returns <c>null</c> to
		///   indicate that no request has completed.
		/// </returns>
		public IRequest TestAny()
		{
			int n = requests.Count;
			for (int i = 0; i < n; ++i)
			{
				IRequest req = requests[i];
				if (req.Test() != null)
				{
					requests.RemoveAt(i);
					return req;
				}
			}

			return null;
		}

		/// <summary>
		/// Wait until all of the requests has completed before returning.
		/// </summary>
		/// <returns>A list containing all of the completed requests.</returns>
		public List<IRequest> WaitAll()
		{
			List<IRequest> result = new List<IRequest>();
			foreach (IRequest req in requests) 
			{
				req.Wait ();
				result.Add (req);
			}

			/*
			List<Request> result = new List<Request>();
			while (requests.Count > 0)
			{
				Request req = WaitAny();
				result.Add(req);
			}*/

			return result;
		}

		/// <summary>
		/// Test whether all of the requests have completed. If all of the
		/// requests have completed, the result is the list of requests. 
		/// Otherwise, the result is <c>null</c>.
		/// </summary>
		/// <returns>Either the list of all completed requests, or null.</returns>
		public List<IRequest> TestAll()
		{
			int n = requests.Count;
			for (int i = 0; i < n; ++i)
			{
				if (requests[i].Test() == null)
					return null;
			}

			List<IRequest> result = requests;
			requests = new List<IRequest>();
			return result;
		}

		/// <summary>
		/// Wait for at least one request to complete, then return a list of
		/// all of the requests that have completed at this point.
		/// </summary>
		/// <returns>
		///   A list of all of the requests that have completed, which
		///   will contain at least one element.
		/// </returns>
		public List<IRequest> WaitSome()
		{
			if (requests.Count == 0)
				throw new ArgumentException("Cannot call MPI.RequestList.WaitAny with an empty request list");

			List<IRequest> result = new List<IRequest>();
			while (result.Count == 0)
			{
				int n = requests.Count;
				for (int i = 0; i < n; ++i)
				{
					IRequest req = requests[i];
					if (req.Test() != null)
					{
						requests.RemoveAt(i);
						--i;
						--n;
						result.Add(req);
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Return a list of all requests that have completed.
		/// </summary>
		/// <returns>
		///   A list of all of the requests that have completed. If
		///   no requests have completed, returns <c>null</c>.
		/// </returns>
		public List<IRequest> TestSome()
		{
			List<IRequest> result = null;
			int n = requests.Count;
			for (int i = 0; i < n; ++i)
			{
				IRequest req = requests[i];
				if (req.Test() != null)
				{
					requests.RemoveAt(i);
					--i;
					--n;

					if (result == null)
						result = new List<IRequest>();
					result.Add(req);
				}
			}
			return result;
		}

		/// <summary>
		/// The actual list of requests.
		/// </summary>
		protected List<IRequest> requests;
	}



}

