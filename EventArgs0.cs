using System;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Beetle;

internal class EventArgs0 : SocketAsyncEventArgs
{
	internal Class37 class37_0;

	public Class41 class41_0;

	public Class40 class40_0;

	public EventArgs0(int int_0)
	{
		byte[] array = new byte[int_0];
		SetBuffer(array, 0, array.Length);
	}

	public static string smethod_0()
	{
		try
		{
			FieldInfo[] fields = typeof(Class40).GetFields(BindingFlags.Static | BindingFlags.Public);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (fieldInfo.GetCustomAttributes(typeof(Attribute2), false).Length > 0)
				{
					return (string)fieldInfo.GetValue(null);
				}
			}
		}
		catch
		{
		}
		return null;
	}

	public static string smethod_1()
	{
		try
		{
			FieldInfo[] fields = typeof(Class41).GetFields(BindingFlags.Static | BindingFlags.Public);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (fieldInfo.GetCustomAttributes(typeof(Attribute3), false).Length > 0)
				{
					string s = (string)fieldInfo.GetValue(null);
					return Encoding.UTF8.GetString(Convert.FromBase64String(s));
				}
			}
		}
		catch
		{
		}
		return null;
	}

	public static bool smethod_2(string string_0)
	{
		return smethod_3(string_0) == Class8.string_0;
	}

	public static string smethod_3(string string_0)
	{
		if (string_0 == "")
		{
			return "";
		}
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] bytes = Encoding.UTF8.GetBytes(string_0);
		bytes = mD5CryptoServiceProvider.ComputeHash(bytes);
		mD5CryptoServiceProvider.Clear();
		StringBuilder stringBuilder = new StringBuilder();
		byte[] array = bytes;
		foreach (byte b in array)
		{
			stringBuilder.Append(b.ToString("x2").ToLower());
		}
		return stringBuilder.ToString();
	}

	public EventArgs0()
	{
	}

	public void method_0()
	{
		if (base.Buffer != null)
		{
			SetBuffer(0, base.Buffer.Length);
		}
	}

	public void method_1()
	{
		class40_0 = null;
		if (class41_0 != null)
		{
			class41_0.vmethod_1(this);
		}
	}

	protected override void OnCompleted(SocketAsyncEventArgs socketAsyncEventArgs_0)
	{
		base.OnCompleted(socketAsyncEventArgs_0);
		if (socketAsyncEventArgs_0.LastOperation == SocketAsyncOperation.Send)
		{
			method_3((EventArgs0)socketAsyncEventArgs_0);
		}
		else if (socketAsyncEventArgs_0.LastOperation == SocketAsyncOperation.Receive)
		{
			method_2((EventArgs0)socketAsyncEventArgs_0);
		}
		else if (socketAsyncEventArgs_0.SocketError != 0)
		{
			class40_0.string_2 = "completed SocketError:" + socketAsyncEventArgs_0.SocketError;
			class40_0.Dispose();
		}
	}

	internal void method_2(EventArgs0 eventArgs0_0)
	{
		try
		{
			Class40 @class = eventArgs0_0.class40_0;
			if (eventArgs0_0.BytesTransferred > 0 && eventArgs0_0.SocketError == SocketError.Success && !@class.bool_11)
			{
				@class.int_2 = Environment.TickCount;
				if (TcpUtils.Statistics)
				{
					Interlocked.Add(ref TcpUtils.ReceiveBytes, eventArgs0_0.BytesTransferred);
					Interlocked.Add(ref @class.long_1, eventArgs0_0.BytesTransferred);
					Interlocked.Increment(ref TcpUtils.ReceiveDataIO);
				}
				Class37 class2 = eventArgs0_0.class37_0;
				if (class2 == null)
				{
					class2 = (eventArgs0_0.class37_0 = new Class37());
				}
				class2.class40_0 = @class;
				class2.int_0 = eventArgs0_0.BytesTransferred;
				class2.eventArgs0_0 = eventArgs0_0;
				Interlocked.Increment(ref @class.int_1);
				if (TcpUtils.ChannelMaxQueueData > 0 && @class.int_1 > TcpUtils.ChannelMaxQueueData)
				{
					@class.string_2 = "Channel Queue Data Overflow!";
					eventArgs0_0.method_1();
					@class.Dispose();
					return;
				}
				if (@class.bool_5)
				{
					@class.class42_0.method_0(class2);
				}
				else
				{
					using (class2)
					{
						class2.vmethod_0();
					}
				}
				@class.BeginReceive();
			}
			else
			{
				@class.string_2 = string.Format("Receive:{0},{1},{2},{3}", eventArgs0_0.SocketError, eventArgs0_0.BytesTransferred, @class.bool_10, @class.class29_0.bool_0);
				eventArgs0_0.method_1();
				@class.Dispose();
			}
		}
		catch
		{
		}
	}

	internal void method_3(EventArgs0 eventArgs0_0)
	{
		Class43 @class = (Class43)eventArgs0_0.UserToken;
		try
		{
			Class40 class2 = eventArgs0_0.class40_0;
			if (eventArgs0_0.SocketError == SocketError.Success && eventArgs0_0.BytesTransferred > 0 && !class2.bool_11 && class2.class29_0.bool_0)
			{
				if (TcpUtils.Statistics)
				{
					Interlocked.Add(ref TcpUtils.SendBytes, eventArgs0_0.BytesTransferred);
					Interlocked.Add(ref class2.long_2, eventArgs0_0.BytesTransferred);
					Interlocked.Increment(ref TcpUtils.SendDataIO);
				}
				if (eventArgs0_0.BytesTransferred < eventArgs0_0.Count)
				{
					int offset = eventArgs0_0.Offset + eventArgs0_0.BytesTransferred;
					int count = eventArgs0_0.Count - eventArgs0_0.BytesTransferred;
					eventArgs0_0.SetBuffer(offset, count);
					TcpUtils.smethod_8();
					if (!class2.Socket.SendAsync(eventArgs0_0))
					{
						method_3(eventArgs0_0);
					}
					return;
				}
				if (@class.method_0())
				{
					if (TcpUtils.SendPacketSpacing > 0)
					{
						Thread.Sleep(TcpUtils.SendPacketSpacing);
					}
					class2.method_8(@class);
					return;
				}
				if (TcpUtils.SendMessageSpacing > 0)
				{
					Thread.Sleep(TcpUtils.SendMessageSpacing);
				}
				if (class2.bool_2)
				{
					class2.sendMessageCompletedArgs_0.Success = true;
					class2.method_10();
				}
				class2.method_2(false);
				class2.Send(null);
			}
			else
			{
				@class.method_1();
				if (class2.bool_2)
				{
					class2.sendMessageCompletedArgs_0.Success = false;
					class2.method_10();
				}
				class2.string_2 = string.Format("Send:{0},{1},{2},{3}", eventArgs0_0.SocketError, eventArgs0_0.BytesTransferred, class2.bool_10, class2.class29_0.bool_0);
				class2.Dispose();
			}
		}
		catch (Exception exception)
		{
			try
			{
				Class40 class3 = class40_0;
				ChannelErrorEventArgs channelErrorEventArgs = new ChannelErrorEventArgs();
				channelErrorEventArgs.Channel = class40_0;
				channelErrorEventArgs.Exception = exception;
				class3.InvokeChannelError(channelErrorEventArgs);
			}
			catch
			{
			}
		}
	}
}
