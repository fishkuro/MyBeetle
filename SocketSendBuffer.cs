using System.Reflection;
using System.Runtime.CompilerServices;
using Beetle.Controller;

internal class SocketSendBuffer
{
	private FieldInfo fieldInfo_0;

	private GetValueHandler getValueHandler_0;

	private SetValueHandler setValueHandler_0;

	public SocketSendBuffer(FieldInfo fieldInfo_1)
	{
		getValueHandler_0 = SocketSessionContext.smethod_0(fieldInfo_1);
		setValueHandler_0 = SocketSessionContext.smethod_2(fieldInfo_1);
		method_1(fieldInfo_1);
	}

	[SpecialName]
	public FieldInfo method_0()
	{
		return fieldInfo_0;
	}

	[SpecialName]
	private void method_1(FieldInfo fieldInfo_1)
	{
		fieldInfo_0 = fieldInfo_1;
	}

	[SpecialName]
	public GetValueHandler method_2()
	{
		return getValueHandler_0;
	}

	[SpecialName]
	public SetValueHandler method_3()
	{
		return setValueHandler_0;
	}
}
