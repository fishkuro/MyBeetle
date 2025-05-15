using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Beetle;

internal class Class40 : IChannel
{
	internal const string string_0 = "<Exponent>{0}</Exponent>";

	[Attribute2]
	public static string string_1 = "PFJTQUtleVZhbHVlPjxNb2R1bHVzPnBrZVREcm1COGNRVUM3emQvQ1N0ZHIwMnZtZ24xVHNjS0dWREx1RFRlSjFJM3prelFtbFlBeS9GdlJPVVRJZnZKbmYvc05yRXNsODZvNTBYYVRVWFF5NmtQbTVLbWFvaTNBMjRFYWpFTEtocTcrbE9qakY3akM3V0E1RHdJT2pUYjR3Wi8zcnphb3VWYmR5VVlFTTZYUlRGVVZ4ZUlLZ3BsenBWVllQanY0dUQzUDV5OVhWS3RUM2x0Y3BOUFZrK0FKakt3YXNaUlE0YS9yM0l0OUZsNGlzS2kxMjJWV1dwWmQzdENhK1E4dXNYMVZ2RFpZdVJFZXFsNWllazIxY2E4YWFMVDF6eFpxL2ovNlYrdnlVeFFIM0dJZmFBSThOaXBHMDludTlFVTZDSHFqbFF1Q1dCZkg4NjVDYnJqTWlSbU01S0J5QXNDNUphekROU01yUm81UT09PC9Nb2R1bHVzPjxFeHBvbmVudD5BUUFCPC9FeHBvbmVudD48L1JTQUtleVZhbHVlPg==";

	private static long long_0 = 0L;

	internal bool bool_0;

	public bool bool_1;

	internal int int_0 = -1;

	internal int int_1;

	internal TcpServer tcpServer_0;

	private Hashtable hashtable_0 = new Hashtable(4);

	public string string_2 = "";

	public long long_1;

	public long long_2;

	public bool bool_2;

	public int int_2 = Environment.TickCount;

	public EventSendMessageCompleted eventSendMessageCompleted_0;

	internal bool bool_3 = true;

	internal bool bool_4 = true;

	internal bool bool_5 = true;

	internal Package package_0;

	public EventDataReceive eventDataReceive_0;

	public EventMessageWriter eventMessageWriter_0;

	public EventMessageWriter eventMessageWriter_1;

	private EventChannelError eventChannelError_0;

	private EventChannelDisposed eventChannelDisposed_0;

	private bool bool_6;

	internal static string string_3 = "V/r2I2CpRaI=";

	public bool bool_7;

	internal Class29 class29_0;

	internal Class42 class42_0;

	internal Class42 class42_1;

	internal Class42 class42_2;

	internal ChannelReceiveEventArgs channelReceiveEventArgs_0 = new ChannelReceiveEventArgs();

	private Socket socket_0;

	private bool bool_8;

	private Class34 class34_0 = new Class34();

	private Class35 class35_0 = new Class35();

	private IDataWriter idataWriter_0;

	private int int_3;

	internal Queue<IMessage> queue_0 = new Queue<IMessage>(256);

	internal SendMessageCompletedArgs sendMessageCompletedArgs_0 = new SendMessageCompletedArgs();

	internal bool bool_9;

	internal bool bool_10;

	internal bool bool_11;

	[CompilerGenerated]
	private ChannelStatus channelStatus_0;

	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private Encoding encoding_0;

	[CompilerGenerated]
	private long long_3;

	[CompilerGenerated]
	private IPEndPoint ipendPoint_0;

	[CompilerGenerated]
	private string string_4;

	[CompilerGenerated]
	private LinkedListNode<LRUDetect.Node> linkedListNode_0;

	public LinkedListNode<LRUDetect.Node> Node
	{
		[CompilerGenerated]
		get
		{
			return linkedListNode_0;
		}
		[CompilerGenerated]
		set
		{
			linkedListNode_0 = value;
		}
	}

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return string_4;
		}
		[CompilerGenerated]
		set
		{
			string_4 = value;
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

	public ChannelStatus Status
	{
		[CompilerGenerated]
		get
		{
			return channelStatus_0;
		}
		[CompilerGenerated]
		set
		{
			channelStatus_0 = value;
		}
	}

	public DateTime CreateTime
	{
		[CompilerGenerated]
		get
		{
			return dateTime_0;
		}
	}

	public int TickCount
	{
		get
		{
			return int_2;
		}
	}

	public object Tag
	{
		[CompilerGenerated]
		get
		{
			return object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	public Package Package
	{
		get
		{
			return package_0;
		}
	}

	public bool LittleEndian
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
			if (Package != null)
			{
				Package.LittleEndian = value;
			}
			idataWriter_0.LittleEndian = value;
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

	public long ClientID
	{
		[CompilerGenerated]
		get
		{
			return long_3;
		}
	}

	public TcpServer Server
	{
		get
		{
			return tcpServer_0;
		}
	}

	public bool IsDisposed
	{
		get
		{
			return bool_11;
		}
	}

	public IPEndPoint EndPoint
	{
		[CompilerGenerated]
		get
		{
			return ipendPoint_0;
		}
	}

	public EventSendMessageCompleted SendMessageCompleted
	{
		get
		{
			return eventSendMessageCompleted_0;
		}
		set
		{
			eventSendMessageCompleted_0 = value;
		}
	}

	public EventDataReceive DataReceive
	{
		get
		{
			return eventDataReceive_0;
		}
		set
		{
			eventDataReceive_0 = value;
		}
	}

	public EventMessageWriter MessageWriting
	{
		get
		{
			return eventMessageWriter_0;
		}
		set
		{
			eventMessageWriter_0 = value;
		}
	}

	public EventMessageWriter MessageWrited
	{
		get
		{
			return eventMessageWriter_1;
		}
		set
		{
			eventMessageWriter_1 = value;
		}
	}

	public bool EnabledSendCompeletedEvent
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public event EventChannelError ChannelError
	{
		add
		{
			EventChannelError eventChannelError = eventChannelError_0;
			EventChannelError eventChannelError2;
			do
			{
				eventChannelError2 = eventChannelError;
				EventChannelError value2 = (EventChannelError)Delegate.Combine(eventChannelError2, value);
				eventChannelError = Interlocked.CompareExchange(ref eventChannelError_0, value2, eventChannelError2);
			}
			while ((object)eventChannelError != eventChannelError2);
		}
		remove
		{
			EventChannelError eventChannelError = eventChannelError_0;
			EventChannelError eventChannelError2;
			do
			{
				eventChannelError2 = eventChannelError;
				EventChannelError value2 = (EventChannelError)Delegate.Remove(eventChannelError2, value);
				eventChannelError = Interlocked.CompareExchange(ref eventChannelError_0, value2, eventChannelError2);
			}
			while ((object)eventChannelError != eventChannelError2);
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

	private static void smethod_0(Class40 class40_0)
	{
		lock (typeof(Class40))
		{
			class40_0["_data"] = 255;
			long_0++;
			class40_0.method_12(long_0);
		}
	}

	[SpecialName]
	public Hashtable method_0()
	{
		return hashtable_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public void method_1(DateTime dateTime_1)
	{
		dateTime_0 = dateTime_1;
	}

	public Package SetPackage<T>() where T : Package
	{
		package_0 = (Package)Activator.CreateInstance(typeof(T), this);
		package_0.LittleEndian = LittleEndian;
		return package_0;
	}

	public Class40(Socket socket_1)
	{
		if (!TcpUtils.bool_0)
		{
			throw NetTcpException.NotInitialize();
		}
		Coding = Encoding.UTF8;
		socket_0 = socket_1;
		method_1(DateTime.Now);
		class42_0 = TcpUtils.smethod_6();
		class42_1 = TcpUtils.smethod_4();
		class42_2 = TcpUtils.smethod_5();
		smethod_0(this);
		method_15((IPEndPoint)socket_1.RemoteEndPoint);
		idataWriter_0 = new Stream0(TcpUtils.class7_0);
		((Stream0)idataWriter_0).Channel = this;
		channelReceiveEventArgs_0.Channel = this;
		class29_0 = Class29.smethod_1();
		bool_6 = true;
	}

	internal void method_2(bool bool_12)
	{
		bool_8 = bool_12;
	}

	public bool Send(object message)
	{
		if (package_0 != null && message != null)
		{
			return method_3((IMessage)package_0.WriteCast(message));
		}
		return method_3((IMessage)message);
	}

	private bool method_3(IMessage imessage_0)
	{
		if (socket_0 != null && !bool_11 && !bool_9)
		{
			if (bool_4)
			{
				lock (queue_0)
				{
					if (imessage_0 != null)
					{
						queue_0.Enqueue(imessage_0);
					}
					if (queue_0.Count > 0 && !bool_8 && !bool_11)
					{
						method_2(true);
						class34_0.class40_0 = this;
						class42_1.method_0(class34_0);
					}
				}
			}
			else if (imessage_0 != null)
			{
				try
				{
					lock (this)
					{
						while (bool_8 && !bool_11)
						{
							Thread.Sleep(1);
						}
						method_2(true);
						method_5(imessage_0);
					}
				}
				catch (Exception exception)
				{
					ChannelErrorEventArgs channelErrorEventArgs = new ChannelErrorEventArgs();
					channelErrorEventArgs.Channel = this;
					channelErrorEventArgs.Exception = exception;
					InvokeChannelError(channelErrorEventArgs);
				}
			}
			return true;
		}
		if (imessage_0 is ICounterMessage)
		{
			((ICounterMessage)imessage_0).Decrement();
		}
		return false;
	}

	[SpecialName]
	public int method_4()
	{
		return queue_0.Count;
	}

	private void method_5(IMessage imessage_0)
	{
		if (bool_2 && sendMessageCompletedArgs_0.Messages.Count > 0)
		{
			sendMessageCompletedArgs_0.Messages.Clear();
		}
		idataWriter_0.Reset();
		if (bool_2)
		{
			sendMessageCompletedArgs_0.Messages.Add(imessage_0);
		}
		if (eventMessageWriter_0 == null)
		{
			imessage_0.Save(idataWriter_0);
		}
		else
		{
			eventMessageWriter_0(imessage_0, idataWriter_0);
			if (eventMessageWriter_1 != null)
			{
				eventMessageWriter_1(imessage_0, idataWriter_0);
			}
		}
		Interlocked.Increment(ref TcpUtils.SendMessages);
		if (imessage_0 is ICounterMessage)
		{
			((ICounterMessage)imessage_0).Decrement();
		}
		method_8(((Stream0)idataWriter_0).method_4());
	}

	internal void method_6()
	{
		lock (queue_0)
		{
			if (queue_0.Count == 0)
			{
				return;
			}
			if (bool_2 && sendMessageCompletedArgs_0.Messages.Count > 0)
			{
				sendMessageCompletedArgs_0.Messages.Clear();
			}
			if (Socket == null || bool_11)
			{
				while (queue_0.Count > 0)
				{
					IMessage message = queue_0.Dequeue();
					if (message is ICounterMessage)
					{
						((ICounterMessage)message).Decrement();
					}
					if (bool_2)
					{
						sendMessageCompletedArgs_0.Messages.Add(message);
					}
				}
				sendMessageCompletedArgs_0.Success = false;
				method_10();
				return;
			}
			idataWriter_0.Reset();
			while (queue_0.Count > 0)
			{
				IMessage message = queue_0.Dequeue();
				if (bool_2)
				{
					sendMessageCompletedArgs_0.Messages.Add(message);
				}
				if (eventMessageWriter_0 == null)
				{
					message.Save(idataWriter_0);
				}
				else
				{
					eventMessageWriter_0(message, idataWriter_0);
					if (eventMessageWriter_1 != null)
					{
						eventMessageWriter_1(message, idataWriter_0);
					}
				}
				Interlocked.Increment(ref TcpUtils.SendMessages);
				if (message is ICounterMessage)
				{
					((ICounterMessage)message).Decrement();
				}
			}
		}
		method_8(((Stream0)idataWriter_0).method_4());
	}

	private void method_7(Class43 class43_0)
	{
		Attribute1 attribute = null;
		int num = 0;
		try
		{
			while (class43_0.attribute1_0 != null)
			{
				attribute = class43_0.attribute1_0;
				num = 0;
				while (num < attribute.int_2 && !bool_11)
				{
					int num2 = Socket.Send(attribute.byte_0, num, attribute.int_2 - num, SocketFlags.None);
					num += num2;
					if (TcpUtils.Statistics)
					{
						lock (TcpUtils.object_1)
						{
							TcpUtils.SendBytes += num2;
							long_2 += num2;
							TcpUtils.SendDataIO++;
						}
					}
				}
				class43_0.method_0();
			}
		}
		finally
		{
			class43_0.method_1();
		}
		method_2(false);
		Send(null);
	}

	internal void method_8(Class43 class43_0)
	{
		Attribute1 attribute = null;
		try
		{
			if (bool_1)
			{
				method_7(class43_0);
				return;
			}
			attribute = class43_0.attribute1_0;
			if (attribute == null)
			{
				return;
			}
			if (!bool_11)
			{
				TcpUtils.smethod_8();
				EventArgs0 eventArgs = attribute.method_0();
				eventArgs.class40_0 = this;
				eventArgs.UserToken = class43_0;
				if (!Socket.SendAsync(eventArgs))
				{
					eventArgs.method_3(eventArgs);
				}
			}
			else
			{
				class43_0.method_1();
			}
		}
		catch (Exception ex)
		{
			class43_0.method_1();
			throw ex;
		}
	}

	public void BeginReceive()
	{
		if (bool_3)
		{
			class35_0.class40_0 = this;
			class42_2.method_0(class35_0);
		}
		else
		{
			method_9();
		}
	}

	internal void method_9()
	{
		if (bool_11 || !class29_0.bool_0)
		{
			return;
		}
		TcpUtils.smethod_8();
		EventArgs0 eventArgs = TcpUtils.class41_0.vmethod_0();
		eventArgs.class40_0 = this;
		try
		{
			if (!Socket.ReceiveAsync(eventArgs))
			{
				eventArgs.method_2(eventArgs);
			}
		}
		catch (Exception exception)
		{
			eventArgs.method_1();
			ChannelErrorEventArgs channelErrorEventArgs = new ChannelErrorEventArgs();
			channelErrorEventArgs.Channel = this;
			channelErrorEventArgs.Exception = exception;
			InvokeChannelError(channelErrorEventArgs);
		}
	}

	internal void method_10()
	{
		try
		{
			if (eventSendMessageCompleted_0 != null)
			{
				sendMessageCompletedArgs_0.Channel = this;
				eventSendMessageCompleted_0(this, sendMessageCompletedArgs_0);
			}
		}
		catch
		{
		}
		finally
		{
			sendMessageCompletedArgs_0.Channel = null;
		}
	}

	internal void method_11(ChannelReceiveEventArgs channelReceiveEventArgs_1)
	{
		vmethod_0(channelReceiveEventArgs_1);
	}

	protected virtual void vmethod_0(ChannelReceiveEventArgs channelReceiveEventArgs_1)
	{
		if (eventDataReceive_0 != null && !bool_10)
		{
			eventDataReceive_0(this, channelReceiveEventArgs_1);
		}
	}

	public void InvokeChannelError(ChannelErrorEventArgs channelErrorEventArgs_0)
	{
		try
		{
			ThreadPool.QueueUserWorkItem(vmethod_1, channelErrorEventArgs_0);
		}
		catch
		{
		}
	}

	protected virtual void vmethod_1(object object_1)
	{
		ChannelErrorEventArgs channelErrorEventArgs = (ChannelErrorEventArgs)object_1;
		try
		{
			if (eventChannelError_0 != null && !bool_11)
			{
				eventChannelError_0(this, channelErrorEventArgs);
			}
		}
		catch
		{
		}
		try
		{
			if (channelErrorEventArgs.Exception is SocketException || channelErrorEventArgs.Exception is ObjectDisposedException || channelErrorEventArgs.Exception is NetTcpException)
			{
				string_2 = "Socket Disposed!";
				Dispose();
			}
		}
		catch
		{
		}
	}

	protected virtual void vmethod_2(ChannelDisposedEventArgs channelDisposedEventArgs_0)
	{
		if (eventChannelDisposed_0 != null)
		{
			eventChannelDisposed_0(this, channelDisposedEventArgs_0);
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal void method_12(long long_4)
	{
		long_3 = long_4;
	}

	private void method_13()
	{
		if (tcpServer_0 != null)
		{
			bool_9 = tcpServer_0.dictionary_1.Count > Class7.int_0;
		}
	}

	[SpecialName]
	internal void method_14(TcpServer tcpServer_1)
	{
		tcpServer_0 = tcpServer_1;
		method_13();
	}

	[SpecialName]
	[CompilerGenerated]
	internal void method_15(IPEndPoint ipendPoint_1)
	{
		ipendPoint_0 = ipendPoint_1;
	}

	internal void method_16()
	{
		bool_10 = true;
		Node = null;
		TcpServer.ReleaseSocket(Socket);
		socket_0 = null;
		if (idataWriter_0 != null)
		{
			((Stream0)idataWriter_0).Channel = null;
			((Stream0)idataWriter_0).method_5(true);
		}
		if (package_0 != null)
		{
			package_0.Dispose();
			package_0 = null;
		}
		try
		{
			lock (queue_0)
			{
				while (queue_0.Count > 0)
				{
					IMessage message = queue_0.Dequeue();
					if (message is ICounterMessage)
					{
						((ICounterMessage)message).Decrement();
					}
				}
			}
		}
		catch
		{
		}
		class35_0.class40_0 = null;
		class35_0 = null;
		class34_0.class40_0 = null;
		class34_0 = null;
		eventMessageWriter_0 = null;
		hashtable_0.Clear();
		idataWriter_0 = null;
		channelReceiveEventArgs_0.Channel = null;
		channelReceiveEventArgs_0 = null;
		method_14(null);
		Tag = null;
	}

	public void Dispose()
	{
		if (bool_11)
		{
			return;
		}
		lock (this)
		{
			if (!bool_11)
			{
				bool_11 = true;
				ChannelDisposedEventArgs channelDisposedEventArgs = new ChannelDisposedEventArgs();
				channelDisposedEventArgs.Message = queue_0;
				channelDisposedEventArgs.Clean = true;
				channelDisposedEventArgs.Channel = this;
				try
				{
					vmethod_2(channelDisposedEventArgs);
				}
				catch
				{
				}
				if (channelDisposedEventArgs.Clean)
				{
					channelDisposedEventArgs.Channel = null;
					method_16();
				}
				else
				{
					ChannelDisposedQueue.DisposedQueue.Add(channelDisposedEventArgs);
				}
			}
		}
	}

	public void TimeOut()
	{
		string_2 = "time out!";
		Dispose();
	}

	public long GetSendBytes()
	{
		return long_2;
	}

	public long GetReceiveBytes()
	{
		return long_1;
	}

	public int GetSendQueues()
	{
		return queue_0.Count;
	}

	public int GetReceiveQueues()
	{
		return int_1;
	}

	public string GetCloseStatus()
	{
		return string_2;
	}

	public bool Send<T, T1, T2>(ICallBackMessage icallBackMessage_0, EventCallBackHandler<T> callback, EventCallBackHandler<T1> callback1, EventCallBackHandler<T2> callback2, object usertoken = null) where T : ICallBackMessage where T1 : ICallBackMessage where T2 : ICallBackMessage
	{
		if (bool_11)
		{
			return false;
		}
		if (icallBackMessage_0.MessageID == 0L)
		{
			icallBackMessage_0.MessageID = Interlocked.Increment(ref int_3);
		}
		Class38 @class = new Class38();
		@class.method_2(typeof(T), callback);
		@class.method_2(typeof(T1), callback1);
		@class.method_2(typeof(T2), callback2);
		@class.method_1(usertoken);
		if (Package != null)
		{
			Package.method_0(icallBackMessage_0.MessageID, @class);
		}
		return Send(icallBackMessage_0);
	}

	public bool Send<T, T1>(ICallBackMessage icallBackMessage_0, EventCallBackHandler<T> callback, EventCallBackHandler<T1> callback1, object usertoken = null) where T : ICallBackMessage where T1 : ICallBackMessage
	{
		if (bool_11)
		{
			return false;
		}
		if (icallBackMessage_0.MessageID == 0L)
		{
			icallBackMessage_0.MessageID = Interlocked.Increment(ref int_3);
		}
		Class38 @class = new Class38();
		@class.method_2(typeof(T), callback);
		@class.method_2(typeof(T1), callback1);
		@class.method_1(usertoken);
		if (Package != null)
		{
			Package.method_0(icallBackMessage_0.MessageID, @class);
		}
		return Send(icallBackMessage_0);
	}

	public bool Send<T>(ICallBackMessage icallBackMessage_0, EventCallBackHandler<T> callback, object usertoken = null) where T : ICallBackMessage
	{
		if (bool_11)
		{
			return false;
		}
		if (icallBackMessage_0.MessageID == 0L)
		{
			icallBackMessage_0.MessageID = Interlocked.Increment(ref int_3);
		}
		Class38 @class = new Class38();
		@class.method_2(typeof(T), callback);
		@class.method_1(usertoken);
		if (Package != null)
		{
			Package.method_0(icallBackMessage_0.MessageID, @class);
		}
		return Send(icallBackMessage_0);
	}
}
