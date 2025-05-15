using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

internal class Class22
{
	private static object object_0 = null;

	private static Class19 class19_0 = new Class19();

	public static bool smethod_0(string string_0, string string_1)
	{
		return smethod_1(Encoding.UTF8.GetBytes(string_0), Convert.FromBase64String(string_1));
	}

	public static bool smethod_1(byte[] byte_0, byte[] byte_1)
	{
		return ((RSACryptoServiceProvider)object_0).VerifyData(byte_0, "MD5", byte_1);
	}

	public static string smethod_2()
	{
		FieldInfo[] fields = typeof(Attribute1).GetFields(BindingFlags.Static | BindingFlags.Public);
		int num = 0;
		FieldInfo fieldInfo;
		while (true)
		{
			if (num < fields.Length)
			{
				fieldInfo = fields[num];
				if (fieldInfo.GetCustomAttributes(typeof(Attribute5), false).Length > 0)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return (string)fieldInfo.GetValue(null);
	}

	public static string smethod_3()
	{
		smethod_4();
		FieldInfo[] fields = typeof(Attribute1).GetFields(BindingFlags.Static | BindingFlags.Public);
		int num = 0;
		FieldInfo fieldInfo;
		while (true)
		{
			if (num < fields.Length)
			{
				fieldInfo = fields[num];
				if (fieldInfo.GetCustomAttributes(typeof(Attribute6), false).Length > 0)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return (string)fieldInfo.GetValue(null) + Class21.string_0 + Attribute4.string_0;
	}

	private static void smethod_4()
	{
		Class19 @class = class19_0;
		Class19.Class20 class2 = new Class19.Class20();
		class2.method_3(Convert.FromBase64String(Class23.string_2));
		class2.method_1(Convert.FromBase64String(Class45.string_0));
		@class.method_1(class2);
	}

	public static void smethod_5(out string string_0, out string string_1)
	{
		string_0 = smethod_3();
		string_1 = smethod_2();
		string_0 = class19_0.method_8(string_0);
		string_1 = class19_0.method_8(string_1);
	}
}
