using System;
using System.Reflection;
using System.Text;

internal class Class27
{
	private const string string_0 = "+v44PgM6AW4P1g4Q9Fs3e5Eer6O9WW1VeBO9XxxhIpvj6ardz8oC6rr5HNii7ip/k9WkSr3FT9sCkrtF4KnD7tnlkFluByl9Yk0IObLEiaZX9ZxYeXjd5jqITrieIJBe9IoCJc+zakXnuDoVWG0Wrxg1/d4QIJAHqo+6lwjPJAW9j7zyzbCSoL/k5YBrEWn92HYhZjW1aFh3SGVJ8wNgnmLj7BsNiozlP2mA2GpGyXLf7D1oSSl6Ycf/ynPDeUCBf+3ZcuF/czpArdNKjPeo24AoEYSDP+ZGvTHIw=";

	internal static string string_1;

	private static Class19 class19_0;

	internal static DateTime dateTime_0;

	static Class27()
	{
		string_1 = "73HWrM6iCrk=";
		class19_0 = new Class19();
		dateTime_0 = DateTime.Now;
		Class19 @class = class19_0;
		Class19.Class20 class2 = new Class19.Class20();
		class2.method_3(Convert.FromBase64String(string_1));
		class2.method_1(Convert.FromBase64String(Class29.string_2));
		@class.method_1(class2);
	}

	internal static void smethod_0(out string string_2)
	{
		string_2 = null;
		FieldInfo[] fields = typeof(Class34).GetFields(BindingFlags.Static | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (fieldInfo.GetCustomAttributes(typeof(Attribute10), false).Length > 0)
			{
				string_2 = (string)fieldInfo.GetValue(null);
			}
		}
		string_2 = smethod_2(string_2);
	}

	internal static void smethod_1(out string string_2)
	{
		string_2 = null;
		FieldInfo[] fields = typeof(Class34).GetFields(BindingFlags.Static | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (fieldInfo.GetCustomAttributes(typeof(Attribute8), false).Length > 0)
			{
				string_2 = (string)fieldInfo.GetValue(null);
			}
		}
		string_2 = smethod_2(string_2 + "+v44PgM6AW4P1g4Q9Fs3e5Eer6O9WW1VeBO9XxxhIpvj6ardz8oC6rr5HNii7ip/k9WkSr3FT9sCkrtF4KnD7tnlkFluByl9Yk0IObLEiaZX9ZxYeXjd5jqITrieIJBe9IoCJc+zakXnuDoVWG0Wrxg1/d4QIJAHqo+6lwjPJAW9j7zyzbCSoL/k5YBrEWn92HYhZjW1aFh3SGVJ8wNgnmLj7BsNiozlP2mA2GpGyXLf7D1oSSl6Ycf/ynPDeUCBf+3ZcuF/czpArdNKjPeo24AoEYSDP+ZGvTHIw=");
		Class28.rsacryptoServiceProvider_0.FromXmlString(string_2);
	}

	internal static string smethod_2(string string_2)
	{
		return class19_0.method_8(string_2);
	}

	internal static DateTime smethod_3(long long_0)
	{
		return new DateTime(long_0);
	}

	internal static string[] smethod_4(string string_2)
	{
		return Encoding.UTF8.GetString(Convert.FromBase64String(string_2)).Split(';');
	}

	internal static void smethod_5(Class29 class29_0, string[] string_2)
	{
		class29_0.string_0 = string_2[0];
		class29_0.string_1 = string_2[1];
	}

	internal static void smethod_6(Class29 class29_0, string string_2)
	{
		string[] array = string_2.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
		if (Class28.smethod_0(array[0], array[1]))
		{
			string[] array2 = smethod_4(array[0]);
			smethod_5(class29_0, array2);
			class29_0.int_0 = int.Parse(array2[2]);
			class29_0.dateTime_0 = smethod_3(long.Parse(array2[3]));
			class29_0.bool_0 = class29_0.dateTime_0 > dateTime_0;
		}
	}
}
