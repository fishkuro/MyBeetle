using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Beetle;

internal class Class28
{
	internal static RSACryptoServiceProvider rsacryptoServiceProvider_0;

	private static string string_0;

	private static string string_1;

	private static string string_2;

	private static StreamReader streamReader_0;

	static Class28()
	{
		rsacryptoServiceProvider_0 = null;
		rsacryptoServiceProvider_0 = (RSACryptoServiceProvider)TcpUtils.smethod_7();
	}

	public static bool smethod_0(string string_3, string string_4)
	{
		return smethod_1(Encoding.UTF8.GetBytes(string_3), Convert.FromBase64String(string_4));
	}

	public static bool smethod_1(byte[] byte_0, byte[] byte_1)
	{
		return rsacryptoServiceProvider_0.VerifyData(byte_0, "MD5", byte_1);
	}

	private static void smethod_2()
	{
		string_2 = TcpUtils.smethod_0() + string_0;
	}

	private static void smethod_3()
	{
		streamReader_0 = new StreamReader(string_2);
	}

	public static Class29 smethod_4()
	{
		Class29 @class = new Class29();
		try
		{
			Class27.smethod_0(out string_0);
			Class27.smethod_1(out string_1);
			smethod_2();
			smethod_3();
			using (streamReader_0)
			{
				Class27.smethod_6(@class, streamReader_0.ReadToEnd());
			}
		}
		catch (Exception)
		{
		}
		Attribute1.bool_0 = @class.bool_0;
		return @class;
	}
}
