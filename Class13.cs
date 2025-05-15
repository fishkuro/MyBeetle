using System.Reflection;
using System.Runtime.CompilerServices;
using Beetle.Controller;

internal class Class13
{
	private bool bool_0;

	private PropertyInfo propertyInfo_0;

	private GetValueHandler getValueHandler_0;

	private SetValueHandler setValueHandler_0;

	public Class13(PropertyInfo propertyInfo_1)
	{
		if (propertyInfo_1.CanWrite)
		{
			setValueHandler_0 = Class16.smethod_4(propertyInfo_1);
		}
		if (propertyInfo_1.CanRead)
		{
			getValueHandler_0 = Class16.smethod_6(propertyInfo_1);
		}
		propertyInfo_0 = propertyInfo_1;
		method_1(propertyInfo_0.GetGetMethod().GetParameters().Length > 0);
	}

	[SpecialName]
	public bool method_0()
	{
		return bool_0;
	}

	[SpecialName]
	public void method_1(bool bool_1)
	{
		bool_0 = bool_1;
	}

	[SpecialName]
	public PropertyInfo method_2()
	{
		return propertyInfo_0;
	}

	[SpecialName]
	public void method_3(PropertyInfo propertyInfo_1)
	{
		propertyInfo_0 = propertyInfo_1;
	}

	[SpecialName]
	public GetValueHandler method_4()
	{
		return getValueHandler_0;
	}

	[SpecialName]
	public SetValueHandler method_5()
	{
		return setValueHandler_0;
	}
}
