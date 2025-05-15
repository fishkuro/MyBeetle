using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

internal class ProtocolEncoder
{
	private static object object_0 = null;

	private static PacketStreamAdapter class19_0 = new PacketStreamAdapter();

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
		FieldInfo[] fields = typeof(CommandAttribute).GetFields(BindingFlags.Static | BindingFlags.Public);
		int num = 0;
		FieldInfo fieldInfo;
		while (true)
		{
			if (num < fields.Length)
			{
				fieldInfo = fields[num];
				if (fieldInfo.GetCustomAttributes(typeof(EncryptAttribute), false).Length > 0)
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
		FieldInfo[] fields = typeof(CommandAttribute).GetFields(BindingFlags.Static | BindingFlags.Public);
		int num = 0;
		FieldInfo fieldInfo;
		while (true)
		{
			if (num < fields.Length)
			{
				fieldInfo = fields[num];
				if (fieldInfo.GetCustomAttributes(typeof(ValidateAttribute), false).Length > 0)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return (string)fieldInfo.GetValue(null) + CryptoProvider.string_0 + ProtocolAttribute.string_0;
	}

	private static void smethod_4()
	{
		PacketStreamAdapter @class = class19_0;
		PacketStreamAdapter.MessageDispatcher class2 = new PacketStreamAdapter.MessageDispatcher();
		class2.method_3(Convert.FromBase64String(SocketTransportAdapter.string_2));
		class2.method_1(Convert.FromBase64String(ConnectionErrorHandler.string_0));
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
