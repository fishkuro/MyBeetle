using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Beetle.Clients
{
	public class SyncChannel<T> : ISyncChannel where T : Package, new()
	{
		public long ReceiveBytes;

		public long SendBytes;

		private bool bool_0;

		private bool bool_1;

		private Stream0 stream0_0;

		private byte[] byte_0 = new byte[8192];

		private object object_0;

		private Package package_0;

		private Hashtable hashtable_0 = new Hashtable();

		private int int_0;

		[CompilerGenerated]
		private Socket socket_0;

		[CompilerGenerated]
		private int int_1;

		[CompilerGenerated]
		private Encoding encoding_0;

		public Package Package
		{
			get
			{
				return package_0;
			}
		}

		public Socket Socket
		{
			[CompilerGenerated]
			get
			{
				return socket_0;
			}
			[CompilerGenerated]
			private set
			{
				socket_0 = value;
			}
		}

		public Hashtable Properties
		{
			get
			{
				return hashtable_0;
			}
		}

		public object this[string name]
		{
			get
			{
				return hashtable_0[name];
			}
			set
			{
				hashtable_0[name] = value;
			}
		}

		public int Timeout
		{
			[CompilerGenerated]
			get
			{
				return int_1;
			}
			[CompilerGenerated]
			set
			{
				int_1 = value;
			}
		}

		public Encoding Coding
		{
			[CompilerGenerated]
			get
			{
				return encoding_0;
			}
			[CompilerGenerated]
			set
			{
				encoding_0 = value;
			}
		}

		public bool IsDisposed
		{
			get
			{
				return bool_0;
			}
		}

		public bool Connected
		{
			get
			{
				return bool_1;
			}
		}

		public SyncChannel()
		{
			Timeout = 0;
			Coding = Encoding.UTF8;
		}

		protected virtual void OnInit()
		{
			package_0 = new T();
			package_0.GetPools();
			package_0.CreateWriterReader();
			package_0.ReceiveMessage = method_1;
			stream0_0 = new Stream0(TcpUtils.class7_0);
			package_0.ReadSinglePackage = true;
		}

		private void method_1(PacketRecieveMessagerArgs packetRecieveMessagerArgs_0)
		{
			object_0 = packetRecieveMessagerArgs_0.Message;
		}

		protected object OnSend(IMessage data, bool sendOnly = false)
		{
			object_0 = null;
			stream0_0.Reset();
			package_0.MessageWrite(data, stream0_0);
			method_2(stream0_0.method_4());
			if (!sendOnly)
			{
				method_3();
			}
			return object_0;
		}

		private void method_2(Class43 class43_0)
		{
			try
			{
				int num = 0;
				int_0 = 0;
				while (class43_0.attribute1_0 != null)
				{
					Attribute1 attribute1_ = class43_0.attribute1_0;
					num = 0;
					while (num < attribute1_.int_2)
					{
						int num2 = Socket.Send(attribute1_.byte_0, num, attribute1_.int_2 - num, SocketFlags.None);
						Interlocked.Add(ref SendBytes, num2);
						if (num2 != 0)
						{
							num += num2;
							int_0 += num2;
							continue;
						}
						throw NetTcpException.ClientIsDisposed();
					}
					class43_0.method_0();
				}
			}
			catch (Exception innerexception)
			{
				Dispose();
				throw NetTcpException.ClientDataProcessError(innerexception);
			}
			finally
			{
				class43_0.method_1();
			}
		}

		public object Receive()
		{
			object_0 = null;
			method_3();
			return object_0;
		}

		public RESULT Receive<RESULT>()
		{
			return (RESULT)Receive();
		}

		private void method_3()
		{
			try
			{
				if (package_0.BufferCount > 0)
				{
					package_0.Import(byte_0, package_0.BufferOffset, package_0.BufferCount);
				}
				while (true)
				{
					if (object_0 == null)
					{
						int num = Socket.Receive(byte_0);
						Interlocked.Add(ref ReceiveBytes, num);
						if (num == 0)
						{
							break;
						}
						package_0.Import(byte_0, 0, num);
						continue;
					}
					return;
				}
				throw NetTcpException.ClientIsDisposed();
			}
			catch (NetTcpException ex)
			{
				Dispose();
				throw ex;
			}
			catch (Exception innerexception)
			{
				Dispose();
				throw NetTcpException.ClientDataProcessError(innerexception);
			}
		}

		protected virtual void OnDisposed()
		{
			if (package_0 != null)
			{
				package_0.Dispose();
			}
			stream0_0.Dispose();
			TcpServer.ReleaseSocket(Socket);
		}

		public virtual void SendOnly(object data)
		{
			if (!Connected)
			{
				throw NetTcpException.ClientMustBeConnected();
			}
			if (bool_0)
			{
				throw NetTcpException.ClientIsDisposed();
			}
			OnSend((IMessage)Package.WriteCast(data), true);
		}

		public virtual object Send(object data)
		{
			if (!Connected)
			{
				throw NetTcpException.ClientMustBeConnected();
			}
			if (bool_0)
			{
				throw NetTcpException.ClientIsDisposed();
			}
			return OnSend((IMessage)Package.WriteCast(data));
		}

		public RESULT Send<RESULT>(object data)
		{
			return (RESULT)Send(data);
		}

		public void Connect(string host, int port)
		{
			if (!bool_1)
			{
				if (!TcpUtils.bool_0)
				{
					throw NetTcpException.NotInitialize();
				}
				if (bool_0)
				{
					throw NetTcpException.ClientIsDisposed();
				}
				IPAddress[] hostAddresses = Dns.GetHostAddresses(host);
				Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				Socket.Connect(new IPEndPoint(hostAddresses[0], port));
				Socket.ReceiveTimeout = Timeout;
				Socket.SendTimeout = Timeout;
				OnInit();
				bool_1 = true;
			}
		}

		public void Dispose()
		{
			lock (this)
			{
				if (!bool_0)
				{
					bool_0 = true;
					bool_1 = false;
					OnDisposed();
				}
			}
		}
	}
}
