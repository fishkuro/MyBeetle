using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Beetle;

internal class EventAttribute : Attribute
{
	private Queue<MessageReceivedEventArgs> queue_0;

	private MessageReceivedEventArgs eventArgs0_0;

	private bool bool_0;

	public EventAttribute()
	{
		WaitCallback waitCallback = null;
		queue_0 = new Queue<MessageReceivedEventArgs>(1024);
		//base._002Ector();
		waitCallback = delegate
		{
			vmethod_1();
		};
		ThreadPool.QueueUserWorkItem(waitCallback);
	}

	public void method_0(MessageReceivedEventArgs eventArgs0_1)
	{
		lock (queue_0)
		{
			queue_0.Enqueue(eventArgs0_1);
		}
	}

	[SpecialName]
	public int method_1()
	{
		return queue_0.Count;
	}

	protected MessageReceivedEventArgs method_2()
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
		eventArgs0_0 = method_2();
		if (eventArgs0_0 != null)
		{
			try
			{
				ConnectionSessionStore class40_ = eventArgs0_0.class40_0;
				if (class40_.Socket != null)
				{
					try
					{
						class40_.channelReceiveEventArgs_0.byteArraySegment_0.SetInfo(eventArgs0_0.Buffer, 0, eventArgs0_0.BytesTransferred);
						class40_.method_11(class40_.channelReceiveEventArgs_0);
						return;
					}
					catch (Exception exception)
					{
						ChannelErrorEventArgs channelErrorEventArgs = new ChannelErrorEventArgs();
						channelErrorEventArgs.Channel = class40_;
						channelErrorEventArgs.Exception = exception;
						class40_.InvokeChannelError(channelErrorEventArgs);
						return;
					}
					finally
					{
						eventArgs0_0.method_1();
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
					queue_0.Dequeue().Dispose();
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
