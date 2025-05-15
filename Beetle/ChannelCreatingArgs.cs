using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace Beetle
{
	public class ChannelCreatingArgs : EventArgs
	{
		[CompilerGenerated]
		private Socket socket_0;

		[CompilerGenerated]
		private TcpServer tcpServer_0;

		[CompilerGenerated]
		private bool bool_0;

		public Socket Socket
		{
			[CompilerGenerated]
			get
			{
				return socket_0;
			}
			[CompilerGenerated]
			internal set
			{
				socket_0 = value;
			}
		}

		public TcpServer Server
		{
			[CompilerGenerated]
			get
			{
				return tcpServer_0;
			}
			[CompilerGenerated]
			internal set
			{
				tcpServer_0 = value;
			}
		}

		public bool Cancel
		{
			[CompilerGenerated]
			get
			{
				return bool_0;
			}
			[CompilerGenerated]
			set
			{
				bool_0 = value;
			}
		}

		public ChannelCreatingArgs()
		{
			Cancel = false;
		}
	}
}
