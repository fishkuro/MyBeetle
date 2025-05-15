using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading;
using Beetle;

internal class SocketAsyncControl : IDisposable
{
	private ConcurrentQueue<ProtocolPacketParser> concurrentQueue_0;

	private ProtocolPacketParser class33_0;

	private bool bool_0;

	[CommandAttribute("")]
	public static string string_0;

	[EventAttribute]
	public static string string_1;

	internal static Timer timer_0;

	public int int_0;

	static SocketAsyncControl()
	{
		string_0 = "KntezZn3/HTLy0OE4rsKQJAtd7Q9rU8fhn1//PZnJ+RTNMXQ+MkO6QwQJqnn3RqN9ou6CzyfMrZWjXY9HyYCHRZ3CSvJyMY1qvMp1J9trG64OxZeCVcYGpObKBlmULBtct+eQl7GpmLt7sW4mdDuXyYWKu7XJjY893CstYfSgZa9qJnxayzFELm0iQbGDtho3l/Kp1MxUKteGuVzjquNBHG3HeJKbtv1uItsbIZ7vsIwmYb26IybmgjrUY7lPR62sbWxQr+v44PgM6AW4P1g4Q9Fs3e5Eer6O9WW1VeBO9XxxhIpvj6ardz8oC6rr5HNii7ip/k9WkSr3FT9sCkrtF4KnD7tnlkFluByl9Yk0IObLEiaZX9ZxYeXjd5jqITrieIJBe9IoCJc+zakXnuDoVWG0Wrxg1/d4QIJAHqo+6lwjPJAW9j7zyzbCSoL/k5YBrEWn92HYhZjW1aFh3SGVJ8wNgnmLj7BsNiozlP2mA2GpGyXLf7D1oSSl6Ycf/ynPDeUCBf+3ZcuF/czpArdNKjPeo24AoEYSDP+ZGvTHIw=";
		string_1 = "baxxfKKgHV9XwOpsrn1uYA==";
		SocketTransportAdapter.smethod_12();
	}

	public SocketAsyncControl()
	{
		WaitCallback waitCallback = null;
		concurrentQueue_0 = new ConcurrentQueue<ProtocolPacketParser>();
		int_0 = 1;
		//base._002Ector();
		waitCallback = delegate
		{
			vmethod_1();
		};
		ThreadPool.QueueUserWorkItem(waitCallback);
		smethod_1();
	}

	public static void smethod_0()
	{
		if (timer_0 != null)
		{
			timer_0.Dispose();
			timer_0 = null;
		}
	}

	public static void smethod_1()
	{
		if (timer_0 == null)
		{
			timer_0 = new Timer(SocketAsyncContext.smethod_0, null, 30000, 30000);
		}
	}

	public void method_0(ProtocolPacketParser class33_1)
	{
		concurrentQueue_0.Enqueue(class33_1);
	}

	protected ProtocolPacketParser method_1()
	{
		ProtocolPacketParser result = null;
		if (!concurrentQueue_0.TryDequeue(out result))
		{
			result = null;
		}
		return result;
	}

	[SpecialName]
	public int method_2()
	{
		return concurrentQueue_0.Count;
	}

	protected virtual void vmethod_0()
	{
		class33_0 = method_1();
		if (class33_0 != null)
		{
			try
			{
				using (class33_0)
				{
					class33_0.vmethod_0();
					return;
				}
			}
			catch
			{
				return;
			}
		}
		Thread.Sleep(int_0);
	}

	public virtual void vmethod_1()
	{
		TcpUtils.smethod_8();
		while (!bool_0)
		{
			vmethod_0();
		}
	}

	public void Dispose()
	{
		lock (this)
		{
			if (!bool_0)
			{
				ProtocolPacketParser result = null;
				while (concurrentQueue_0.TryDequeue(out result))
				{
					result.Dispose();
				}
				bool_0 = true;
			}
		}
	}

	[CompilerGenerated]
	private void method_3(object object_0)
	{
		vmethod_1();
	}
}
