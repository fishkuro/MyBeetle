using System;
using System.Net;
using System.Runtime.CompilerServices;

namespace Beetle
{
	public abstract class ServerBase : IDisposable
	{
		private TcpServer tcpServer_0;

		private bool bool_0;

		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private bool bool_1;

		[CompilerGenerated]
		private string string_0;

		public int Listens
		{
			[CompilerGenerated]
			get
			{
				return int_0;
			}
			[CompilerGenerated]
			set
			{
				int_0 = value;
			}
		}

		public bool LittleEndian
		{
			[CompilerGenerated]
			get
			{
				return bool_1;
			}
			[CompilerGenerated]
			set
			{
				bool_1 = value;
			}
		}

		public string Name
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public TcpServer Server
		{
			get
			{
				return tcpServer_0;
			}
		}

		public ServerBase()
		{
			Listens = 50;
			LittleEndian = true;
		}

		public void Open(string string_1, int port)
		{
			Open(IPAddress.Parse(string_1), port);
		}

		public void Open(int port)
		{
			Open(new IPEndPoint(IPAddress.Any, port));
		}

		public void Open(IPAddress ipaddress_0, int port)
		{
			Open(new IPEndPoint(ipaddress_0, port));
		}

		public void Open(IPEndPoint ipendPoint_0)
		{
			tcpServer_0 = new TcpServer();
			tcpServer_0.LittleEndian = LittleEndian;
			OnBindEvent(tcpServer_0);
			tcpServer_0.Error += OnServerError;
			tcpServer_0.Open(ipendPoint_0, Listens);
			OnOpening();
		}

		protected virtual void OnServerError(object sender, TcpServerErrorArgs tcpServerErrorArgs_0)
		{
		}

		protected virtual void OnOpening()
		{
		}

		protected virtual void OnBindEvent(TcpServer server)
		{
			server.ChannelConnected += OnConnected;
			server.ChannelDisposed += OnDisposed;
			server.ChannelCreating += OnCreatingChannel;
		}

		protected virtual void OnCreatingChannel(object sender, ChannelCreatingArgs channelCreatingArgs_0)
		{
		}

		protected virtual void OnConnected(object sender, ChannelEventArgs e)
		{
			e.Channel.DataReceive = OnReceive;
			e.Channel.ChannelError += OnError;
			e.Channel.BeginReceive();
		}

		protected virtual void OnReceive(object sender, ChannelReceiveEventArgs e)
		{
		}

		protected virtual void OnDisposed(object sender, ChannelDisposedEventArgs e)
		{
		}

		protected virtual void OnError(object sender, ChannelErrorEventArgs e)
		{
		}

		protected virtual void OnServerDisposed()
		{
			if (tcpServer_0 != null)
			{
				tcpServer_0.Dispose();
				tcpServer_0 = null;
			}
		}

		public void Dispose()
		{
			lock (this)
			{
				if (!bool_0)
				{
					bool_0 = true;
					OnServerDisposed();
				}
			}
		}
	}
	public abstract class ServerBase<T> : ServerBase where T : Package
	{
		protected override void OnConnected(object sender, ChannelEventArgs e)
		{
			e.Channel.SetPackage<T>().ReceiveMessage = OnMessageReceive;
			e.Channel.ChannelError += OnError;
			e.Channel.BeginReceive();
		}

		protected virtual void OnMessageReceive(PacketRecieveMessagerArgs packetRecieveMessagerArgs_0)
		{
		}
	}
}
