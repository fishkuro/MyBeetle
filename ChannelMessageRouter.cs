using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Beetle;

internal class ChannelMessageRouter
{
	public class RequestAcknowledger
	{
		public Type type_0;

		public Delegate delegate_0;
	}

	public IList<RequestAcknowledger> ilist_0 = new List<RequestAcknowledger>();

	[CompilerGenerated]
	private object object_0;

	[SpecialName]
	[CompilerGenerated]
	public object method_0()
	{
		return object_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public void method_1(object object_1)
	{
		object_0 = object_1;
	}

	public void method_2(Type type_0, Delegate delegate_0)
	{
		IList<RequestAcknowledger> list = ilist_0;
		RequestAcknowledger @class = new RequestAcknowledger();
		@class.type_0 = type_0;
		@class.delegate_0 = delegate_0;
		list.Add(@class);
	}

	public void method_3(IChannel ichannel_0, object object_1, object object_2)
	{
		Delegate @delegate = null;
		int num = 0;
		RequestAcknowledger @class;
		while (true)
		{
			if (num < ilist_0.Count)
			{
				@class = ilist_0[num];
				if (@class.type_0 == object_1.GetType())
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		@delegate = @class.delegate_0;
		Type type = Type.GetType("Beetle.EventCallBackHandlerArgs`1");
		type = type.MakeGenericType(@class.type_0);
		object obj = Activator.CreateInstance(type, ichannel_0, object_1, object_2);
		@delegate.DynamicInvoke(obj);
	}
}
