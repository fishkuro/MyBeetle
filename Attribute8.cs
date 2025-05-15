using System;
using System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
internal class Attribute8 : Attribute
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private int int_0;

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

	[SpecialName]
	[CompilerGenerated]
	public int method_2()
	{
		return int_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public void method_3(int int_1)
	{
		int_0 = int_1;
	}
}
