using System.Reflection;
using System.Runtime.CompilerServices;
using Beetle.Controller;

internal class StreamInputHandler
{
	private MethodInfo methodInfo_0;

	private FastMethodHandler fastMethodHandler_0;

	public StreamInputHandler(MethodInfo methodInfo_1)
	{
		fastMethodHandler_0 = SocketSessionContext.smethod_8(methodInfo_1);
		methodInfo_0 = methodInfo_1;
	}

	[SpecialName]
	public MethodInfo method_0()
	{
		return methodInfo_0;
	}

	[SpecialName]
	public FastMethodHandler method_1()
	{
		return fastMethodHandler_0;
	}
}
