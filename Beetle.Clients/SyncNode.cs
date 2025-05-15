using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Beetle.Clients
{
	public class SyncNode : IDisposable
	{
		public class Connection : IDisposable
		{
			private Exception exception_0;

			[CompilerGenerated]
			private SyncNode syncNode_0;

			[CompilerGenerated]
			private ISyncChannel isyncChannel_0;

			internal SyncNode Pool
			{
				[CompilerGenerated]
				get
				{
					return syncNode_0;
				}
				[CompilerGenerated]
				set
				{
					syncNode_0 = value;
				}
			}

			public ISyncChannel Channel
			{
				[CompilerGenerated]
				get
				{
					return isyncChannel_0;
				}
				[CompilerGenerated]
				internal set
				{
					isyncChannel_0 = value;
				}
			}

			public object Send(object data)
			{
				try
				{
					return Channel.Send(data);
				}
				catch (Exception ex)
				{
					throw exception_0 = ex;
				}
			}

			public T Send<T>(object data)
			{
				return (T)Send(data);
			}

			public void SendOnly(object data)
			{
				try
				{
					Channel.SendOnly(data);
				}
				catch (Exception ex)
				{
					throw exception_0 = ex;
				}
			}

			public object Receive()
			{
				try
				{
					return Channel.Receive();
				}
				catch (Exception ex)
				{
					throw exception_0 = ex;
				}
			}

			public T Receive<T>()
			{
				return (T)Receive();
			}

			public void Reset()
			{
				exception_0 = null;
			}

			public void Dispose()
			{
				lock (this)
				{
					if (Pool != null)
					{
						SyncNode pool = Pool;
						Pool = null;
						if (exception_0 == null)
						{
							pool.method_0(this);
						}
						else
						{
							pool.method_4(exception_0);
						}
					}
				}
			}
		}

		private Exception exception_0;

		private Timer timer_0;

		private Queue<Connection> queue_0 = new Queue<Connection>();

		private Type type_0;

		public string[] GroupNodes;

		private bool bool_0;

		private bool bool_1;

		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private int int_1;

		[CompilerGenerated]
		private int int_2;

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private int int_3;

		public string GroupName
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

		public string Host
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

		public int Port
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

		public int DetectTime
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

		public int TimeOut
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

		public string Name
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

		public int MaxConnections
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

		public Exception LastError
		{
			get
			{
				return exception_0;
			}
		}

		public int Connections
		{
			get
			{
				return queue_0.Count;
			}
		}

		public bool Available
		{
			get
			{
				return bool_0;
			}
		}

		public bool IsDisposed
		{
			get
			{
				return bool_1;
			}
		}

		public SyncNode(string host, int port, int maxconnections)
		{
			Host = host;
			Port = port;
			DetectTime = 10;
			TimeOut = -1;
			MaxConnections = maxconnections;
		}

		public Connection Pop()
		{
			Connection connection = null;
			if (!Available)
			{
				return connection;
			}
			for (int i = 1; i < 10; i++)
			{
				lock (this)
				{
					if (queue_0.Count > 0)
					{
						connection = queue_0.Dequeue();
						connection.Reset();
						connection.Pool = this;
						return connection;
					}
				}
				Thread.Sleep(1);
			}
			return connection;
		}

		internal void method_0(Connection connection_0)
		{
			lock (this)
			{
				if (connection_0 != null)
				{
					queue_0.Enqueue(connection_0);
				}
			}
		}

		public RESULT Send<RESULT>(object data)
		{
			return (RESULT)Send(data);
		}

		public object Send(object data)
		{
			Connection connection = Pop();
			if (connection == null)
			{
				throw NetTcpException.ConnectionIsNotAvailable();
			}
			using (connection)
			{
				return connection.Send(data);
			}
		}

		public void Connect<T>() where T : ISyncChannel, new()
		{
			if (timer_0 == null)
			{
				timer_0 = new Timer(method_2, null, -1, DetectTime * 1000);
			}
			type_0 = typeof(T);
			ThreadPool.QueueUserWorkItem(method_2);
		}

		private void method_1(bool bool_2)
		{
			lock (this)
			{
				bool_0 = bool_2;
				if (Available)
				{
					if (timer_0 != null)
					{
						timer_0.Change(-1, DetectTime * 1000);
					}
				}
				else if (timer_0 != null)
				{
					timer_0.Change(DetectTime * 1000, DetectTime * 1000);
				}
			}
		}

		private void method_2(object object_0)
		{
			if (timer_0 != null)
			{
				timer_0.Change(-1, DetectTime * 1000);
			}
			try
			{
				do
				{
					Connection connection_ = method_3();
					method_0(connection_);
				}
				while (queue_0.Count < MaxConnections);
				method_1(true);
			}
			catch (Exception exception_)
			{
				method_4(exception_);
			}
		}

		private Connection method_3()
		{
			Connection connection = new Connection();
			ISyncChannel syncChannel = (ISyncChannel)Activator.CreateInstance(type_0);
			syncChannel.Timeout = TimeOut;
			syncChannel.Connect(Host, Port);
			connection.Channel = syncChannel;
			return connection;
		}

		internal void method_4(Exception exception_1)
		{
			exception_0 = exception_1;
			lock (this)
			{
				while (queue_0.Count > 0)
				{
					queue_0.Dequeue().Channel.Dispose();
				}
			}
			method_1(false);
		}

		public void Dispose()
		{
			lock (this)
			{
				if (!bool_1)
				{
					bool_1 = true;
					while (queue_0.Count > 0)
					{
						queue_0.Dequeue().Channel.Dispose();
					}
				}
			}
		}
	}
}
