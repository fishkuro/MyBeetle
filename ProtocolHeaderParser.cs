using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

internal class ProtocolHeaderParser : IDisposable
{
	[HandlerAttribute]
	public static string string_0;

	protected Queue<MessageReceivedEventArgs> queue_0;

	private int int_0;

	private bool bool_0;

	static ProtocolHeaderParser()
	{
		string_0 = "bGljZW5zZS5zbg==";
		HeartbeatMonitor.smethod_1();
	}

	public ProtocolHeaderParser(int int_1)
	{
		queue_0 = new Queue<MessageReceivedEventArgs>(int_1);
		for (int i = 0; i < int_1; i++)
		{
			queue_0.Enqueue(method_1());
		}
	}

	public ProtocolHeaderParser(int int_1, int int_2)
	{
		int_0 = int_2;
		queue_0 = new Queue<MessageReceivedEventArgs>(int_1);
		for (int i = 0; i < int_1; i++)
		{
			queue_0.Enqueue(method_1());
		}
	}

	[SpecialName]
	public int method_0()
	{
		return queue_0.Count;
	}

	protected MessageReceivedEventArgs method_1()
	{
		MessageReceivedEventArgs eventArgs = null;
		eventArgs = ((int_0 <= 0) ? new MessageReceivedEventArgs() : new MessageReceivedEventArgs(int_0));
		eventArgs.class41_0 = this;
		return eventArgs;
	}

	public virtual MessageReceivedEventArgs vmethod_0()
	{
		lock (queue_0)
		{
			MessageReceivedEventArgs eventArgs = null;
			eventArgs = ((queue_0.Count <= 0) ? method_1() : queue_0.Dequeue());
			eventArgs.method_0();
			return eventArgs;
		}
	}

	public virtual void vmethod_1(MessageReceivedEventArgs eventArgs0_0)
	{
		eventArgs0_0.class40_0 = null;
		lock (queue_0)
		{
			eventArgs0_0.class40_0 = null;
			queue_0.Enqueue(eventArgs0_0);
		}
	}

	private void method_2()
	{
		while (queue_0.Count > 0)
		{
			MessageReceivedEventArgs eventArgs = queue_0.Dequeue();
			eventArgs.class41_0 = null;
			eventArgs.SetBuffer(null, 0, 0);
		}
	}

	public void Dispose()
	{
		lock (this)
		{
			if (!bool_0)
			{
				method_2();
				bool_0 = true;
			}
		}
	}
}
