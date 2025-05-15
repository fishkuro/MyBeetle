using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Beetle;

internal class SocketKeepAliveManager
{
	private Queue<ConnectionSessionStore> queue_0;

	private ConnectionSessionStore class40_0;

	private bool bool_0;

	public SocketKeepAliveManager()
	{
		WaitCallback waitCallback = null;
		queue_0 = new Queue<ConnectionSessionStore>(1024);
		//base._002Ector();
		waitCallback = delegate
		{
			vmethod_1();
		};
		ThreadPool.QueueUserWorkItem(waitCallback);
	}

	public void method_0(ConnectionSessionStore class40_1)
	{
		lock (queue_0)
		{
			queue_0.Enqueue(class40_1);
		}
	}

	[SpecialName]
	public int method_1()
	{
		return queue_0.Count;
	}

	protected ConnectionSessionStore method_2()
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

	protected virtual void vmethod_0()
	{
		class40_0 = method_2();
		if (class40_0 != null)
		{
			try
			{
				if (!class40_0.bool_11)
				{
					try
					{
						class40_0.method_9();
						return;
					}
					catch (Exception exception)
					{
						ConnectionSessionStore @class = class40_0;
						ChannelErrorEventArgs channelErrorEventArgs = new ChannelErrorEventArgs();
						channelErrorEventArgs.Channel = class40_0;
						channelErrorEventArgs.Exception = exception;
						@class.InvokeChannelError(channelErrorEventArgs);
						return;
					}
				}
				return;
			}
			catch
			{
				return;
			}
		}
		Thread.Sleep(TcpUtils.SocketDespatchSleepTime);
	}

	public virtual void vmethod_1()
	{
		if (!TcpUtils.ExecutionContext)
		{
			ExecutionContext.SuppressFlow();
		}
		while (!bool_0)
		{
			vmethod_0();
		}
	}

	public void method_3()
	{
		lock (this)
		{
			if (!bool_0)
			{
				while (queue_0.Count > 0)
				{
					ConnectionSessionStore @class = queue_0.Dequeue();
					@class.string_2 = "receive despatch close!";
					@class.Dispose();
				}
				bool_0 = true;
			}
		}
	}

	[CompilerGenerated]
	private void method_4(object object_0)
	{
		vmethod_1();
	}
}
