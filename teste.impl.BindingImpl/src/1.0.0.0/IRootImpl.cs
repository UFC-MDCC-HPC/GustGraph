using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using teste.Binding;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;

namespace teste.impl.BindingImpl 
{ 
	public class IRootImpl : BaseIRootImpl, IRoot
	{

		public override void server ()
		{
			Console.WriteLine ("ROOT SERVER PROCESS");

			StartServer ();
		}

		public override void client ()
		{
			Console.WriteLine ("ROOT CLIENT PROCESS");

			int r = RootCommunicator.Allreduce (44, minus);
			Console.WriteLine ("ROOT CALCULATED " + r);

			StartClient (r.ToString());
		}

		private int minus(int a, int b) { return a - b; }


		public void StartClient(string data) 
		{
			// Data buffer for incoming data.
			byte[] bytes = new byte[1024];
			Thread.Sleep (10000);

			// Connect to a remote device.
			try {

				int port_client = this.Facet[Math.Abs(this.ThisFacet-1)].port; // int.Parse(System.Environment.GetEnvironmentVariable("BINDING_TEST_CLIENT_PORT"));

				Console.WriteLine("ROOT CLIENT port={0}", port_client);
				// Establish the remote endpoint for the socket.
				// This example uses port 11000 on the local computer.
				IPHostEntry ipHostInfo = Dns.GetHostEntry("localhost" /*Dns.GetHostName()*/);
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress,port_client);
				Console.WriteLine("ROOT CLIENT - ipHostInfo: " + remoteEP.Address);

				// Create a TCP/IP  socket.
				Socket sender = new Socket(AddressFamily.InterNetwork, 
				                           SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp );

				// Connect the socket to the remote endpoint. Catch any errors.
				try {
					sender.Connect(remoteEP);

					Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

					// Encode the data string into a byte array.
					byte[] msg = Encoding.ASCII.GetBytes(data + "<EOF>");
					Console.WriteLine("CLIENT 1");

					// Send the data through the socket.
					int bytesSent = sender.Send(msg);
					Console.WriteLine("CLIENT 2");

					// Receive the response from the remote device.
					int bytesRec = sender.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
					                  Encoding.ASCII.GetString(bytes,0,bytesRec));


				} catch (ArgumentNullException ane) {
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
				} catch (SocketException se) {
					Console.WriteLine("SocketException : {0}",se.ToString());
				} catch (Exception e) {
					Console.WriteLine("Unexpected exception : {0}", e.ToString());
				} 
				finally 
				{
					Console.WriteLine ("CLOSING SOCKET CLIENT");
					// Release the socket.
					sender.Shutdown(SocketShutdown.Both);
					sender.Close();
				}

			} catch (Exception e) {
				Console.WriteLine( e.ToString());
			}
		}

		public void StartServer() 		
		{

			Console.WriteLine ("ROOT SERVER ----- " + ThisFacet);
			foreach (KeyValuePair<int,FacetAccess> fa in this.Facet)
				Console.WriteLine ("ROOT SERVER $$$ " + fa.Key + "/"+ fa.Value.port);

			int port_server = this.Facet[this.ThisFacet].port; //int.Parse(System.Environment.GetEnvironmentVariable("BINDING_TEST_SERVER_PORT"));
			Console.WriteLine("ROOT SERVER port={0}", port_server);


			string data = null;

			// Data buffer for incoming data.
			byte[] bytes = new Byte[1024];

			// Establish the local endpoint for the socket.
			// Dns.GetHostName returns the name of the 
			// host running the application.
			IPHostEntry ipHostInfo = Dns.Resolve("localhost" /*Dns.GetHostName()*/);
			IPAddress ipAddress = ipHostInfo.AddressList[0];	
			Console.WriteLine("ROOT SERVER - ipHostInfo: " + ipAddress);
			IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port_server);

			// Create a TCP/IP socket.
			Socket listener = new Socket(AddressFamily.InterNetwork,
			                             SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp );

			// Bind the socket to the local endpoint and 
			// listen for incoming connections.
			try {
				listener.Bind(localEndPoint);
				listener.Listen(10);

				// Start listening for connections.
				//while (true) {
					Console.WriteLine("Waiting for a connection..." + localEndPoint.Address);
					// Program is suspended while waiting for an incoming connection.
					Socket handler = listener.Accept();
					data = null;

					// An incoming connection needs to be processed.
					while (true) {
						Console.WriteLine("LOOP SERVER BYTE ...");
						bytes = new byte[1024];
						int bytesRec = handler.Receive(bytes);
						data += Encoding.ASCII.GetString(bytes,0,bytesRec);
						if (data.IndexOf("<EOF>") > -1) {
							break;
						}
					}

					// Show the data on the console.
					Console.WriteLine( "Text received : {0}", data);

					// Echo the data back to the client.
					byte[] msg = Encoding.ASCII.GetBytes(data);

					handler.Send(msg);
					handler.Shutdown(SocketShutdown.Both);
					handler.Close();
				//}

			} catch (Exception e) {
				Console.WriteLine(e.ToString());
			}
			finally 
			{
				Console.WriteLine ("CLOSING SOCKET SERVER");
				listener.Shutdown(SocketShutdown.Both);
				listener.Close();
			}


		}


	}
}
