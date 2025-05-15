using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Beetle
{
	public class TcpServer : IDisposable
	{
		private EventTcpServerError eventTcpServerError_0;

		private bool bool_0;

		private object object_0 = new object();

		private Class45 class45_0;

		private int int_0 = 255;

		private ChannelCreatingArgs channelCreatingArgs_0 = new ChannelCreatingArgs();

		internal static string string_0 = "73HWrM6iCrk=";

		private Socket socket_0;

		private Class23 class23_0;

		private Queue<Class45> queue_0 = new Queue<Class45>(1024);

		private Dictionary<Type, IIPFiler> dictionary_0 = new Dictionary<Type, IIPFiler>();

		private DetectTimeoutHandler detectTimeoutHandler_0;

		private EventChannglCreating eventChannglCreating_0;

		private bool bool_1;

		public bool EnabledVariant;

		internal Dictionary<long, IChannel> dictionary_1;

		private IPEndPoint ipendPoint_0;

		private EventChannelConnected eventChannelConnected_0;

		private EventChannelDisposed eventChannelDisposed_0;

		private long long_0;

		public static ObjectPool<SocketAsyncEventArgs> SocketAsyncEventArgsPools = new ObjectPool<SocketAsyncEventArgs>(1024);

		private bool bool_2;

		private object object_1 = new object();

		[CompilerGenerated]
		private bool bool_3;

		[CompilerGenerated]
		private bool bool_4;

		[CompilerGenerated]
		private bool bool_5;

		[CompilerGenerated]
		private bool bool_6;

		[CompilerGenerated]
		private Encoding encoding_0;

		[CompilerGenerated]
		private bool bool_7;

		public bool LittleEndian
		{
			[CompilerGenerated]
			get
			{
				return bool_3;
			}
			[CompilerGenerated]
			set
			{
				bool_3 = value;
			}
		}

		public bool EnabledReceiveQueue
		{
			[CompilerGenerated]
			get
			{
				return bool_4;
			}
			[CompilerGenerated]
			set
			{
				bool_4 = value;
			}
		}

		public bool EnabledSendQueue
		{
			[CompilerGenerated]
			get
			{
				return bool_5;
			}
			[CompilerGenerated]
			set
			{
				bool_5 = value;
			}
		}

		public bool EnabledWorkQueue
		{
			[CompilerGenerated]
			get
			{
				return bool_6;
			}
			[CompilerGenerated]
			set
			{
				bool_6 = value;
			}
		}

		public bool IsRunning
		{
			get
			{
				return bool_1;
			}
		}

		public DetectTimeoutHandler DetectHandler
		{
			get
			{
				return detectTimeoutHandler_0;
			}
		}

		public int QueueConnects
		{
			get
			{
				return queue_0.Count;
			}
		}

		public Socket Socket
		{
			get
			{
				return socket_0;
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

		public long OnlineVersion
		{
			get
			{
				return long_0;
			}
		}

		public bool EnabledChannelSendCompeletedEvent
		{
			[CompilerGenerated]
			get
			{
				return bool_7;
			}
			[CompilerGenerated]
			set
			{
				bool_7 = value;
			}
		}

		public int Count
		{
			get
			{
				return method_13();
			}
		}

		public event EventTcpServerError Error
		{
			add
			{
				EventTcpServerError eventTcpServerError = eventTcpServerError_0;
				EventTcpServerError eventTcpServerError2;
				do
				{
					eventTcpServerError2 = eventTcpServerError;
					EventTcpServerError value2 = (EventTcpServerError)Delegate.Combine(eventTcpServerError2, value);
					eventTcpServerError = Interlocked.CompareExchange(ref eventTcpServerError_0, value2, eventTcpServerError2);
				}
				while ((object)eventTcpServerError != eventTcpServerError2);
			}
			remove
			{
				EventTcpServerError eventTcpServerError = eventTcpServerError_0;
				EventTcpServerError eventTcpServerError2;
				do
				{
					eventTcpServerError2 = eventTcpServerError;
					EventTcpServerError value2 = (EventTcpServerError)Delegate.Remove(eventTcpServerError2, value);
					eventTcpServerError = Interlocked.CompareExchange(ref eventTcpServerError_0, value2, eventTcpServerError2);
				}
				while ((object)eventTcpServerError != eventTcpServerError2);
			}
		}

		public event EventChannglCreating ChannelCreating
		{
			add
			{
				EventChannglCreating eventChannglCreating = eventChannglCreating_0;
				EventChannglCreating eventChannglCreating2;
				do
				{
					eventChannglCreating2 = eventChannglCreating;
					EventChannglCreating value2 = (EventChannglCreating)Delegate.Combine(eventChannglCreating2, value);
					eventChannglCreating = Interlocked.CompareExchange(ref eventChannglCreating_0, value2, eventChannglCreating2);
				}
				while ((object)eventChannglCreating != eventChannglCreating2);
			}
			remove
			{
				EventChannglCreating eventChannglCreating = eventChannglCreating_0;
				EventChannglCreating eventChannglCreating2;
				do
				{
					eventChannglCreating2 = eventChannglCreating;
					EventChannglCreating value2 = (EventChannglCreating)Delegate.Remove(eventChannglCreating2, value);
					eventChannglCreating = Interlocked.CompareExchange(ref eventChannglCreating_0, value2, eventChannglCreating2);
				}
				while ((object)eventChannglCreating != eventChannglCreating2);
			}
		}

		public event EventChannelConnected ChannelConnected
		{
			add
			{
				EventChannelConnected eventChannelConnected = eventChannelConnected_0;
				EventChannelConnected eventChannelConnected2;
				do
				{
					eventChannelConnected2 = eventChannelConnected;
					EventChannelConnected value2 = (EventChannelConnected)Delegate.Combine(eventChannelConnected2, value);
					eventChannelConnected = Interlocked.CompareExchange(ref eventChannelConnected_0, value2, eventChannelConnected2);
				}
				while ((object)eventChannelConnected != eventChannelConnected2);
			}
			remove
			{
				EventChannelConnected eventChannelConnected = eventChannelConnected_0;
				EventChannelConnected eventChannelConnected2;
				do
				{
					eventChannelConnected2 = eventChannelConnected;
					EventChannelConnected value2 = (EventChannelConnected)Delegate.Remove(eventChannelConnected2, value);
					eventChannelConnected = Interlocked.CompareExchange(ref eventChannelConnected_0, value2, eventChannelConnected2);
				}
				while ((object)eventChannelConnected != eventChannelConnected2);
			}
		}

		public event EventChannelDisposed ChannelDisposed
		{
			add
			{
				EventChannelDisposed eventChannelDisposed = eventChannelDisposed_0;
				EventChannelDisposed eventChannelDisposed2;
				do
				{
					eventChannelDisposed2 = eventChannelDisposed;
					EventChannelDisposed value2 = (EventChannelDisposed)Delegate.Combine(eventChannelDisposed2, value);
					eventChannelDisposed = Interlocked.CompareExchange(ref eventChannelDisposed_0, value2, eventChannelDisposed2);
				}
				while ((object)eventChannelDisposed != eventChannelDisposed2);
			}
			remove
			{
				EventChannelDisposed eventChannelDisposed = eventChannelDisposed_0;
				EventChannelDisposed eventChannelDisposed2;
				do
				{
					eventChannelDisposed2 = eventChannelDisposed;
					EventChannelDisposed value2 = (EventChannelDisposed)Delegate.Remove(eventChannelDisposed2, value);
					eventChannelDisposed = Interlocked.CompareExchange(ref eventChannelDisposed_0, value2, eventChannelDisposed2);
				}
				while ((object)eventChannelDisposed != eventChannelDisposed2);
			}
		}

		public TcpServer()
		{
			Coding = Encoding.UTF8;
			dictionary_1 = new Dictionary<long, IChannel>(TcpUtils.Connections);
			EnabledChannelSendCompeletedEvent = false;
			detectTimeoutHandler_0 = new DetectTimeoutHandler();
			detectTimeoutHandler_0.Server = this;
			class23_0 = Class23.smethod_12();
			EnabledReceiveQueue = TcpUtils.EnabledReceiveQueue;
			EnabledSendQueue = TcpUtils.EnabledSendQueue;
			EnabledWorkQueue = TcpUtils.EnabledWorkQueue;
			LittleEndian = true;
		}

		protected virtual void OnError(TcpServerErrorArgs tcpServerErrorArgs_0)
		{
			try
			{
				if (eventTcpServerError_0 != null)
				{
					eventTcpServerError_0(this, tcpServerErrorArgs_0);
				}
			}
			catch
			{
			}
		}

		private void method_0(Class45 class45_1)
		{
			lock (queue_0)
			{
				queue_0.Enqueue(class45_1);
			}
		}

		private Class45 method_1()
		{
			lock (queue_0)
			{
				if (queue_0.Count > 0)
				{
					return queue_0.Dequeue();
				}
				return null;
			}
		}

		public void SetFilter<T>() where T : IIPFiler, new()
		{
			lock (dictionary_0)
			{
				dictionary_0[typeof(T)] = new T();
			}
		}

		public T GetFilter<T>() where T : IIPFiler, new()
		{
			lock (dictionary_0)
			{
				Type typeFromHandle = typeof(T);
				if (!dictionary_0.ContainsKey(typeFromHandle))
				{
					dictionary_0.Add(typeFromHandle, new T());
				}
				return (T)dictionary_0[typeFromHandle];
			}
		}

		private void method_2(IChannel ichannel_0)
		{
			lock (object_0)
			{
				dictionary_1.Remove(ichannel_0.ClientID);
				long_0++;
			}
		}

		private void method_3(IChannel ichannel_0)
		{
			lock (object_0)
			{
				dictionary_1.Add(ichannel_0.ClientID, ichannel_0);
				long_0++;
				((Class40)ichannel_0).bool_11 = ((Class40)ichannel_0).int_0 > (int)ichannel_0["_data"];
			}
		}

		public IChannel GetClient(long long_1)
		{
			IChannel value;
			dictionary_1.TryGetValue(long_1, out value);
			return value;
		}

		public IChannel[] GetOnlines()
		{
			lock (object_0)
			{
				try
				{
					Class40[] array = new Class40[dictionary_1.Count];
					dictionary_1.Values.CopyTo(array, 0);
					return array;
				}
				catch (Exception exception_)
				{
					method_4(exception_);
					return new Class40[0];
				}
			}
		}

		public void GetOnlines(OnlineSegment onlineSegment_0)
		{
			lock (object_0)
			{
				try
				{
					if (onlineSegment_0.OnlineVersion != OnlineVersion)
					{
						Dictionary<long, IChannel>.ValueCollection values = dictionary_1.Values;
						values.CopyTo(onlineSegment_0.Channels, 0);
						onlineSegment_0.Count = dictionary_1.Count;
						onlineSegment_0.OnlineVersion = OnlineVersion;
					}
				}
				catch (Exception exception_)
				{
					method_4(exception_);
				}
			}
		}

		private void method_4(Exception exception_0)
		{
			TcpServerErrorArgs tcpServerErrorArgs = new TcpServerErrorArgs();
			tcpServerErrorArgs.Error = exception_0;
			try
			{
				OnError(tcpServerErrorArgs);
			}
			catch
			{
			}
		}

		public IChannel FindClient(long long_1, string name)
		{
			IChannel[] onlines = GetOnlines();
			int num = 0;
			Class40 @class;
			while (true)
			{
				if (num < onlines.Length)
				{
					@class = (Class40)onlines[num];
					if (long_1 == @class.ClientID || (!string.IsNullOrEmpty(name) && @class.Name == name))
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return @class;
		}

		protected void OnConnected(IChannel ichannel_0)
		{
			try
			{
				method_3(ichannel_0);
				((Class40)ichannel_0).method_14(this);
				ichannel_0.ChannelDisposed += OnClientDisposed;
				if (eventChannelConnected_0 != null)
				{
					EventChannelConnected eventChannelConnected = eventChannelConnected_0;
					ChannelDisposedEventArgs channelDisposedEventArgs = new ChannelDisposedEventArgs();
					channelDisposedEventArgs.Channel = ichannel_0;
					channelDisposedEventArgs.Clean = true;
					eventChannelConnected(this, channelDisposedEventArgs);
				}
			}
			catch (Exception ex)
			{
				string message = ex.Message;
				method_4(ex);
			}
		}

		protected void OnClientDisposed(object sender, ChannelDisposedEventArgs e)
		{
			try
			{
				((Class40)e.Channel).method_14(null);
				method_2(e.Channel);
				if (eventChannelDisposed_0 != null)
				{
					eventChannelDisposed_0(this, e);
				}
			}
			catch (Exception exception_)
			{
				method_4(exception_);
			}
		}

		protected void OnChannelCreating(ChannelCreatingArgs channelCreatingArgs_1)
		{
			if (eventChannglCreating_0 != null)
			{
				eventChannglCreating_0(this, channelCreatingArgs_0);
			}
			channelCreatingArgs_1.Cancel = method_13() >= int_0;
		}

		public void Open(IPEndPoint ipendpoint)
		{
			Open(ipendpoint, 100);
		}

		public void Open(IPEndPoint ipendpoint, int listens)
		{
			if (!TcpUtils.bool_0)
			{
				throw NetTcpException.NotInitialize();
			}
			ipendPoint_0 = ipendpoint;
			if (socket_0 != null)
			{
				Dispose();
			}
			socket_0 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			Socket.Bind(ipendpoint);
			Socket.Listen(listens);
			bool_1 = true;
			ThreadPool.QueueUserWorkItem(method_7);
			ThreadPool.QueueUserWorkItem(method_9);
		}

		private void method_5(Socket socket_1)
		{
			try
			{
				socket_1.Disconnect(false);
			}
			catch
			{
			}
			ReleaseSocket(socket_1);
		}

		private int method_6()
		{
			return GetHashCode();
		}

		private void method_7(object object_2)
		{
			while (bool_1)
			{
				try
				{
					class45_0 = method_1();
					if (class45_0 != null)
					{
						channelCreatingArgs_0.Cancel = false;
						channelCreatingArgs_0.Socket = class45_0.socket_0;
						channelCreatingArgs_0.Server = this;
						if (!class23_0.method_1(method_12, class45_0, method_13(), out int_0))
						{
							method_5(class45_0.socket_0);
							continue;
						}
						OnChannelCreating(channelCreatingArgs_0);
						if (!channelCreatingArgs_0.Cancel)
						{
							method_12(class45_0);
						}
						else
						{
							method_5(class45_0.socket_0);
						}
						Class8.smethod_0(method_6(), dictionary_1.Count);
					}
					else
					{
						Thread.Sleep(10);
					}
				}
				catch (Exception exception_)
				{
					method_4(exception_);
				}
			}
		}

		private bool method_8()
		{
			return dictionary_1.Count < Class7.int_0;
		}

		private void method_9(object object_2)
		{
			try
			{
				bool flag = true;
				while (bool_1 && flag && !bool_2)
				{
					SocketAsyncEventArgs socketAsyncEventArgs = SocketAsyncEventArgsPools.Pop();
					socketAsyncEventArgs.Completed += method_10;
					try
					{
						flag = !Socket.AcceptAsync(socketAsyncEventArgs);
						bool_0 = true;
					}
					catch (SocketException exception_)
					{
						method_4(exception_);
						break;
					}
					catch (ObjectDisposedException exception_2)
					{
						method_4(exception_2);
						break;
					}
					if (flag)
					{
						method_11(socketAsyncEventArgs);
					}
				}
			}
			catch (Exception exception_3)
			{
				method_4(exception_3);
			}
		}

		private void method_10(object sender, SocketAsyncEventArgs e)
		{
			method_11(e);
			method_9(null);
		}

		private void method_11(SocketAsyncEventArgs socketAsyncEventArgs_0)
		{
			try
			{
				if (socketAsyncEventArgs_0.SocketError == SocketError.Success && !bool_2)
				{
					Class45 @class = new Class45();
					@class.socket_0 = socketAsyncEventArgs_0.AcceptSocket;
					method_0(@class);
				}
				else
				{
					ReleaseSocket(socketAsyncEventArgs_0.AcceptSocket);
				}
				socketAsyncEventArgs_0.AcceptSocket = null;
			}
			catch (Exception exception_)
			{
				method_4(exception_);
			}
			finally
			{
				Class8.smethod_0(method_6(), dictionary_1.Count);
				bool_0 = false;
				socketAsyncEventArgs_0.Completed -= method_10;
				SocketAsyncEventArgsPools.Push(socketAsyncEventArgs_0);
			}
		}

		private void method_12(Class45 class45_1)
		{
			Class40 @class = null;
			bool flag = true;
			if (dictionary_0.Count > 0)
			{
				using (Dictionary<Type, IIPFiler>.Enumerator enumerator = dictionary_0.GetEnumerator())
				{
					while (enumerator.MoveNext() && (flag = enumerator.Current.Value.Execute((IPEndPoint)class45_1.socket_0.RemoteEndPoint)))
					{
					}
				}
			}
			if (flag)
			{
				@class = new Class40(class45_1.socket_0);
				@class.LittleEndian = LittleEndian;
				@class.bool_7 = EnabledVariant;
				method_14(@class);
				@class.bool_2 = EnabledChannelSendCompeletedEvent;
				@class.bool_3 = EnabledReceiveQueue;
				@class.bool_4 = EnabledSendQueue;
				@class.bool_5 = EnabledWorkQueue;
				OnConnected(@class);
			}
			else
			{
				class45_1.socket_0.Shutdown(SocketShutdown.Both);
				class45_1.socket_0.Close();
			}
		}

		public static void ReleaseSocket(Socket socket)
		{
			if (socket == null)
			{
				return;
			}
			try
			{
				if (socket != null)
				{
					socket.Shutdown(SocketShutdown.Both);
				}
			}
			catch
			{
			}
			try
			{
				if (socket != null)
				{
					socket.Close();
				}
			}
			catch
			{
			}
		}

		public void Open(int port)
		{
			Open(new IPEndPoint(IPAddress.Any, port));
		}

		public void Open(string string_1, int port)
		{
			Open(string_1, port, 100);
		}

		public void Open(string string_1, int port, int listens)
		{
			Open(new IPEndPoint(IPAddress.Parse(string_1), port), listens);
		}

		public static void SetKeepAliveValues(Socket socket, uint first, uint interval)
		{
			byte[] array = new byte[Marshal.SizeOf((object)first) * 3];
			BitConverter.GetBytes(1u).CopyTo(array, 0);
			BitConverter.GetBytes(first).CopyTo(array, Marshal.SizeOf((object)first));
			BitConverter.GetBytes(interval).CopyTo(array, Marshal.SizeOf((object)first) * 2);
			socket.IOControl(IOControlCode.KeepAliveValues, array, null);
		}

		public static IChannel CreateClient(string string_1, int port)
		{
			return CreateClient(new IPEndPoint(IPAddress.Parse(string_1), port));
		}

		public static IChannel CreateClient(IPAddress ipaddress_0, int port)
		{
			return CreateClient(new IPEndPoint(ipaddress_0, port));
		}

		public static IChannel CreateClient(IPEndPoint endpoint)
		{
			Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Connect(endpoint);
			return new Class40(socket);
		}

		public static IChannel CreateClient<T>(string string_1, int port, EventPacketRecievMessage receive) where T : Package
		{
			return CreateClient<T>(new IPEndPoint(IPAddress.Parse(string_1), port), receive);
		}

		public static IChannel CreateClient<T>(IPAddress ipaddress_0, int port, EventPacketRecievMessage receive) where T : Package
		{
			return CreateClient<T>(new IPEndPoint(ipaddress_0, port), receive);
		}

		public static IChannel CreateClient<T>(IPEndPoint endpoint, EventPacketRecievMessage receive) where T : Package
		{
			if (!TcpUtils.bool_0)
			{
				throw NetTcpException.NotInitialize();
			}
			Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Connect(endpoint);
			Class40 @class = new Class40(socket);
			@class.SetPackage<T>().ReceiveMessage = receive;
			return @class;
		}

		public static void CreateClientAsync(string string_1, int port, Action<CreateChannelArgs> result)
		{
			CreateClientAsync(IPAddress.Parse(string_1), port, result);
		}

		public static void CreateClientAsync(IPAddress ipaddress_0, int port, Action<CreateChannelArgs> result)
		{
			CreateClientAsync(new IPEndPoint(ipaddress_0, port), result);
		}

		public static void CreateClientAsync(IPEndPoint endpoint, Action<CreateChannelArgs> result)
		{
			if (!TcpUtils.bool_0)
			{
				throw NetTcpException.NotInitialize();
			}
			SocketAsyncEventArgs socketAsyncEventArgs = SocketAsyncEventArgsPools.Pop();
			socketAsyncEventArgs.Completed += smethod_0;
			try
			{
				socketAsyncEventArgs.UserToken = result;
				Socket socket2 = (socketAsyncEventArgs.AcceptSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp));
				socketAsyncEventArgs.RemoteEndPoint = endpoint;
				if (!socket2.ConnectAsync(socketAsyncEventArgs))
				{
					smethod_0(null, socketAsyncEventArgs);
				}
			}
			catch (Exception ex)
			{
				socketAsyncEventArgs.Completed -= smethod_0;
				SocketAsyncEventArgsPools.Push(socketAsyncEventArgs);
				throw ex;
			}
		}

		public void Pause()
		{
			lock (object_0)
			{
				if (!bool_2)
				{
					bool_2 = true;
				}
			}
		}

		public void Resume()
		{
			lock (object_0)
			{
				if (bool_2)
				{
					bool_2 = false;
					if (!bool_0)
					{
						ThreadPool.QueueUserWorkItem(method_9);
					}
				}
			}
		}

		internal int method_13()
		{
			return dictionary_1.Count;
		}

		private static void smethod_0(object sender, SocketAsyncEventArgs e)
		{
			try
			{
				CreateChannelArgs createChannelArgs = new CreateChannelArgs();
				createChannelArgs.Error = e.SocketError;
				if (e.SocketError == SocketError.Success)
				{
					createChannelArgs.Channel = new Class40(e.AcceptSocket);
				}
				Action<CreateChannelArgs> action = (Action<CreateChannelArgs>)e.UserToken;
				action(createChannelArgs);
			}
			catch
			{
			}
			finally
			{
				e.Completed -= smethod_0;
				SocketAsyncEventArgsPools.Push(e);
			}
		}

		internal void method_14(Class40 class40_0)
		{
			class40_0.int_0 = dictionary_1.Count;
			class40_0["_data"] = int_0;
		}

		public void Dispose()
		{
			lock (this)
			{
				if (bool_1)
				{
					DetectHandler.Server = null;
					bool_1 = false;
					IChannel[] onlines = GetOnlines();
					for (int i = 0; i < onlines.Length; i++)
					{
						Class40 @class = (Class40)onlines[i];
						@class.string_2 = "Server Close!";
						@class.Dispose();
					}
					dictionary_1.Clear();
					if (Socket != null)
					{
						ReleaseSocket(Socket);
						socket_0 = null;
					}
					lock (queue_0)
					{
						queue_0.Clear();
					}
					channelCreatingArgs_0.Server = null;
					channelCreatingArgs_0 = null;
				}
			}
		}
	}
}
