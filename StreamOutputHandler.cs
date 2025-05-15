using System;
using System.Runtime.CompilerServices;
using Beetle.Controller;

internal class StreamOutputHandler
{
	private ObjectInstanceHandler objectInstanceHandler_0;

	public StreamOutputHandler(Type type_0)
	{
		objectInstanceHandler_0 = SocketSessionContext.smethod_10(type_0);
	}

	[SpecialName]
	public ObjectInstanceHandler method_0()
	{
		return objectInstanceHandler_0;
	}
}
