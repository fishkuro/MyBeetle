using System.Reflection;
using System.Runtime.CompilerServices;
using Beetle.Controller;

internal class Class14
{
	private MethodInfo methodInfo_0;

	private FastMethodHandler fastMethodHandler_0;

	public Class14(MethodInfo methodInfo_1)
	{
		fastMethodHandler_0 = Class16.smethod_8(methodInfo_1);
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
