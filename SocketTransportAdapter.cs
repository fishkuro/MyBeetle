using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Beetle;

internal class SocketTransportAdapter
{
	public static DateTime dateTime_0;

	public bool bool_0;

	public string string_0;

	public string string_1;

	public int int_0;

	public DateTime dateTime_1;

	private static SocketTransportAdapter class23_0;

	private static object object_0;

	internal static string string_2;

	private static string[] string_3;

	private static string[] string_4;

	private static string string_5;

	private static string string_6;

	private static StreamReader streamReader_0;

	private static string string_7;

	static SocketTransportAdapter()
	{
		dateTime_0 = DateTime.Now;
		class23_0 = null;
		object_0 = null;
		string_2 = "73HWrM6iCrk=";
		object_0 = new RSACryptoServiceProvider(2048);
	}

	public static byte[] smethod_0(byte[] byte_0)
	{
		return ((RSACryptoServiceProvider)object_0).Encrypt(byte_0, false);
	}

	public static byte[] smethod_1(byte[] byte_0)
	{
		return ((RSACryptoServiceProvider)object_0).Decrypt(byte_0, false);
	}

	public static bool smethod_2(string string_8, string string_9)
	{
		return smethod_3(Encoding.UTF8.GetBytes(string_8), Convert.FromBase64String(string_9));
	}

	public static bool smethod_3(byte[] byte_0, byte[] byte_1)
	{
		return ((RSACryptoServiceProvider)object_0).VerifyData(byte_0, "MD5", byte_1);
	}

	private static void smethod_4(string string_8)
	{
		string_3 = string_8.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
	}

	private static void smethod_5(string string_8)
	{
		string_4 = Encoding.UTF8.GetString(Convert.FromBase64String(string_8)).Split(';');
	}

	private static void smethod_6()
	{
		class23_0.string_0 = string_4[0];
		class23_0.string_1 = string_4[1];
	}

	private static void smethod_7()
	{
		class23_0.int_0 = int.Parse(string_4[2]);
		ClientTokenSession.int_0 = int.Parse(string_4[2]);
		class23_0.dateTime_1 = new DateTime(long.Parse(string_4[3]));
		CommandAttribute.bool_1 = class23_0.dateTime_1 > dateTime_0;
	}

	private static void smethod_8(string string_8, SocketTransportAdapter class23_1)
	{
		smethod_4(string_8);
		if (smethod_2(string_3[0], string_3[1]))
		{
			smethod_5(string_3[0]);
			smethod_6();
			smethod_7();
			class23_1.bool_0 = class23_1.dateTime_1 > dateTime_0;
		}
	}

	private static void smethod_9()
	{
		streamReader_0 = new StreamReader(string_7);
	}

	private static void smethod_10(string string_8)
	{
		string_7 = TcpUtils.smethod_0() + string_5;
	}

	private static void smethod_11(string string_8)
	{
		((RSACryptoServiceProvider)object_0).FromXmlString(string_6);
	}

	public static SocketTransportAdapter smethod_12()
	{
		lock (typeof(SocketTransportAdapter))
		{
			if (class23_0 == null)
			{
				class23_0 = new SocketTransportAdapter();
				try
				{
					ProtocolEncoder.smethod_5(out string_6, out string_5);
					smethod_11(null);
					smethod_10(string_6);
					smethod_9();
					using (streamReader_0)
					{
						smethod_8(streamReader_0.ReadToEnd(), class23_0);
					}
				}
				catch (Exception)
				{
				}
			}
		}
		CommandAttribute.bool_0 = class23_0.bool_0;
		return class23_0;
	}

	private int method_0()
	{
		return int_0;
	}

	public bool method_1(Action<ConnectionErrorHandler> action_0, ConnectionErrorHandler class45_0, int int_1, out int int_2)
	{
		int_2 = method_0();
		if (bool_0)
		{
			return int_1 <= int_0;
		}
		return false;
	}
}
