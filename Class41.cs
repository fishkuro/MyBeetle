using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

internal class Class41 : IDisposable
{
	[Attribute3]
	public static string string_0;

	protected Queue<EventArgs0> queue_0;

	private int int_0;

	private bool bool_0;

	static Class41()
	{
		string_0 = "bGljZW5zZS5zbg==";
		Class29.smethod_1();
	}

	public Class41(int int_1)
	{
		queue_0 = new Queue<EventArgs0>(int_1);
		for (int i = 0; i < int_1; i++)
		{
			queue_0.Enqueue(method_1());
		}
	}

	public Class41(int int_1, int int_2)
	{
		int_0 = int_2;
		queue_0 = new Queue<EventArgs0>(int_1);
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

	protected EventArgs0 method_1()
	{
		EventArgs0 eventArgs = null;
		eventArgs = ((int_0 <= 0) ? new EventArgs0() : new EventArgs0(int_0));
		eventArgs.class41_0 = this;
		return eventArgs;
	}

	public virtual EventArgs0 vmethod_0()
	{
		lock (queue_0)
		{
			EventArgs0 eventArgs = null;
			eventArgs = ((queue_0.Count <= 0) ? method_1() : queue_0.Dequeue());
			eventArgs.method_0();
			return eventArgs;
		}
	}

	public virtual void vmethod_1(EventArgs0 eventArgs0_0)
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
			EventArgs0 eventArgs = queue_0.Dequeue();
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
