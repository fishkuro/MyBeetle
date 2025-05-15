using System.Reflection;
using System.Runtime.CompilerServices;
using Beetle.Controller;

internal class Class12
{
	private FieldInfo fieldInfo_0;

	private GetValueHandler getValueHandler_0;

	private SetValueHandler setValueHandler_0;

	public Class12(FieldInfo fieldInfo_1)
	{
		getValueHandler_0 = Class16.smethod_0(fieldInfo_1);
		setValueHandler_0 = Class16.smethod_2(fieldInfo_1);
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
