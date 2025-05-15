using System;
using System.Security.Cryptography;
using Beetle;

internal class Class29
{
	public bool bool_0;

	public string string_0;

	public string string_1;

	public int int_0;

	public DateTime dateTime_0;

	private static Class29 class29_0 = null;

	private static object object_0 = null;

	internal static string string_2 = "V/r2I2CpRaI=";

	public static byte[] smethod_0(byte[] byte_0)
	{
		return ((RSACryptoServiceProvider)object_0).Decrypt(byte_0, false);
	}

	public static Class29 smethod_1()
	{
		lock (typeof(Class29))
		{
			if (class29_0 == null)
			{
				class29_0 = Class28.smethod_4();
			}
		}
		return class29_0;
	}

	public bool method_0()
	{
		return bool_0;
	}

	internal static string smethod_2(string string_3)
	{
		Class19 @class = new Class19();
		Class19.Class20 class2 = new Class19.Class20();
		class2.method_3(Convert.FromBase64String(TcpServer.string_0));
		class2.method_1(Convert.FromBase64String(Class40.string_3));
		@class.method_1(class2);
		return @class.method_8(string_3);
	}
}
