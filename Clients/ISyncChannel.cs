using System;
using System.Collections;
using System.Net.Sockets;
using System.Text;

namespace Beetle.Clients
{
	public interface ISyncChannel : IDisposable
	{
		Package Package { get; }

		Socket Socket { get; }

		Hashtable Properties { get; }

		object this[string name] { get; set; }

		int Timeout { get; set; }

		Encoding Coding { get; set; }

		bool IsDisposed { get; }

		bool Connected { get; }

		object Send(object data);

		void Connect(string host, int port);

		void SendOnly(object data);

		object Receive();

		RESULT Receive<RESULT>();
	}
}
