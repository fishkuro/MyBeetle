using System;
using System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
internal class Attribute7 : Attribute
{
	[CompilerGenerated]
	private string string_0;

	[SpecialName]
	[CompilerGenerated]
	public string method_0()
	{
		return string_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public void method_1(string string_1)
	{
		string_0 = string_1;
	}
}
