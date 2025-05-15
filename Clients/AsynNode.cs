using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Beetle.Clients
{
	public class AsynNode<T> where T : Package
	{
		private Action<IChannel> action_0;

		private EventPacketRecievMessage eventPacketRecievMessage_0;

		private EventChannelError eventChannelError_0;

		private bool bool_0;

		private Timer timer_0;

		private int int_0;

		private List<IChannel> list_0 = new List<IChannel>();

		private Exception exception_0;

		private bool bool_1;

		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private int int_1;

		[CompilerGenerated]
		private int int_2;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private string[] string_2;

		[CompilerGenerated]
		private int int_3;

		[CompilerGenerated]
		private string string_3;

		public string Host
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			private set
			{
				string_0 = value;
			}
		}

		public int Port
		{
			[CompilerGenerated]
			get
			{
				return int_1;
			}
			[CompilerGenerated]
			private set
			{
				int_1 = value;
			}
		}

		public int MaxConnections
		{
			[CompilerGenerated]
			get
			{
				return int_2;
			}
			[CompilerGenerated]
			set
			{
				int_2 = value;
			}
		}

		public string GroupName
		{
			[CompilerGenerated]
			get
			{
				return string_1;
			}
			[CompilerGenerated]
			set
			{
				string_1 = value;
			}
		}

		public string[] GroupNodes
		{
			[CompilerGenerated]
			get
			{
				return string_2;
			}
			[CompilerGenerated]
			set
			{
				string_2 = value;
			}
		}

		public int DetectTime
		{
			[CompilerGenerated]
			get
			{
				return int_3;
			}
			[CompilerGenerated]
			set
			{
				int_3 = value;
			}
		}

		public string Name
		{
			[CompilerGenerated]
			get
			{
				return string_3;
			}
			[CompilerGenerated]
			set
			{
				string_3 = value;
			}
		}

		public Exception LastError
		{
			get
			{
				return exception_0;
			}
		}

		public IList<IChannel> Channels
		{
			get
			{
				return list_0;
			}
		}

		public bool Available
		{
			get
			{
				return bool_1;
			}
		}

		public AsynNode(string host, int port, int maxconnections, EventPacketRecievMessage receive, EventChannelError error, Action<IChannel> channelCreated)
		{
			DetectTime = 10;
			Host = host;
			Port = port;
			MaxConnections = maxconnections;
			bool_1 = false;
			eventPacketRecievMessage_0 = receive;
			eventChannelError_0 = error;
			action_0 = channelCreated;
		}

		private void method_0(object sender, ChannelDisposedEventArgs e)
		{
			method_2(e.Channel);
			method_7(false);
		}

		private void method_1(IChannel ichannel_0)
		{
			lock (this)
			{
				method_1(ichannel_0);
			}
		}

		private void method_2(IChannel ichannel_0)
		{
			lock (this)
			{
				list_0.Remove(ichannel_0);
			}
		}

		public void Connect()
		{
			if (timer_0 == null)
			{
				timer_0 = new Timer(method_3, null, -1, DetectTime * 1000);
			}
			ThreadPool.QueueUserWorkItem(method_3);
		}

		private void method_3(object object_0)
		{
			if (timer_0 != null)
			{
				timer_0.Change(-1, DetectTime * 1000);
			}
			try
			{
				do
				{
					IChannel channel = method_4();
					if (action_0 != null)
					{
						action_0(channel);
					}
					list_0.Add(channel);
				}
				while (list_0.Count < MaxConnections);
				bool_0 = false;
				method_7(true);
			}
			catch (Exception exception_)
			{
				bool_0 = false;
				method_5(exception_);
				method_7(false);
			}
		}

		private IChannel method_4()
		{
			IChannel channel = TcpServer.CreateClient<T>(Host, Port, eventPacketRecievMessage_0);
			channel.ChannelError += eventChannelError_0;
			channel.ChannelDisposed += method_0;
			TcpServer.SetKeepAliveValues(channel.Socket, 5000u, 5000u);
			channel.BeginReceive();
			return channel;
		}

		internal void method_5(Exception exception_1)
		{
			exception_0 = exception_1;
		}

		private IChannel method_6()
		{
			lock (this)
			{
				if (Available && list_0.Count != 0)
				{
					int_0++;
					if (int_0 >= list_0.Count)
					{
						int_0 = 0;
					}
					return list_0[int_0];
				}
				return null;
			}
		}

		public bool Send(object object_0)
		{
			if (list_0.Count == 0)
			{
				return false;
			}
			IChannel channel = method_6();
			if (channel == null)
			{
				return false;
			}
			return channel.Send(object_0);
		}

		private void method_7(bool bool_2)
		{
			lock (this)
			{
				bool_1 = bool_2;
				if (bool_1)
				{
					return;
				}
				foreach (IChannel item in list_0)
				{
					item.Dispose();
				}
				list_0.Clear();
				if (!bool_0)
				{
					bool_0 = true;
					if (timer_0 != null)
					{
						timer_0.Change(DetectTime * 1000, DetectTime * 1000);
					}
				}
			}
		}
	}
}
