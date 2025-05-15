using System.Collections.Generic;
using Beetle;
using Beetle.Controller;

internal class BeetleTcpClient
{
	public object object_0;

	public bool bool_0;

	public IList<FilterAttribute> ilist_0 = new List<FilterAttribute>();

	public StreamInputHandler class14_0;

	public object method_0(IChannel ichannel_0, object object_1)
	{
		return class14_0.method_1()(object_0, new object[2] { ichannel_0, object_1 });
	}
}
