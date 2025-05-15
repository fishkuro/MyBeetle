using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Beetle;

internal class SocketReceiveEventArgs
{
	private class SocketMetadata
	{
		public string string_0;

		public string string_1;

		public SocketMetadata()
		{
			string_0 = EventDrivenSocket.smethod_2();
			string_1 = EventDrivenSocket.smethod_1();
		}

		[SpecialName]
		public string method_0()
		{
			return smethod_7(string_0);
		}

		[SpecialName]
		public string method_1()
		{
			return smethod_7(string_1);
		}
	}

	public bool bool_0;

	public string string_0;

	public string string_1;

	public int int_0;

	public DateTime dateTime_0;

	private static SocketReceiveEventArgs class25_0;

	private static RSACryptoServiceProvider rsacryptoServiceProvider_0;

	private static string string_2;

	private static string string_3;

	private static SocketMetadata class26_0;

	private static string[] string_4;

	private static string[] string_5;

	private static DateTime dateTime_1;

	private static char[] char_0;

	static SocketReceiveEventArgs()
	{
		class25_0 = null;
		rsacryptoServiceProvider_0 = null;
		class26_0 = new SocketMetadata();
		dateTime_1 = DateTime.Now;
		char_0 = new char[2] { '\r', '\n' };
		rsacryptoServiceProvider_0 = (RSACryptoServiceProvider)EventDrivenSocket.smethod_0();
	}

	public static bool smethod_0(string string_6, string string_7)
	{
		return smethod_1(Encoding.UTF8.GetBytes(string_6), Convert.FromBase64String(string_7));
	}

	public static bool smethod_1(byte[] byte_0, byte[] byte_1)
	{
		return rsacryptoServiceProvider_0.VerifyData(byte_0, "MD5", byte_1);
	}

	public static string smethod_2(string string_6)
	{
		return Encoding.UTF8.GetString(smethod_3(Convert.FromBase64String(string_6)));
	}

	public static byte[] smethod_3(byte[] byte_0)
	{
		return rsacryptoServiceProvider_0.Decrypt(byte_0, false);
	}

	private static void smethod_4(string string_6)
	{
		string_4 = string_6.Split(char_0, StringSplitOptions.RemoveEmptyEntries);
		if (smethod_0(string_4[0], string_4[1]))
		{
			string_5 = Encoding.UTF8.GetString(Convert.FromBase64String(string_4[0])).Split(';');
			smethod_5();
			class25_0.dateTime_0 = new DateTime(long.Parse(string_5[3]));
			class25_0.bool_0 = class25_0.dateTime_0 > dateTime_1;
		}
	}

	private static void smethod_5()
	{
		class25_0.string_0 = string_5[0];
		class25_0.string_1 = string_5[1];
		class25_0.int_0 = int.Parse(string_5[2]);
	}

	public static SocketReceiveEventArgs smethod_6()
	{
		lock (typeof(SocketReceiveEventArgs))
		{
			if (class25_0 == null)
			{
				class25_0 = new SocketReceiveEventArgs();
				try
				{
					rsacryptoServiceProvider_0.FromXmlString(class26_0.method_0());
					string path = TcpUtils.smethod_0() + class26_0.method_1();
					using (StreamReader streamReader = new StreamReader(path))
					{
						smethod_4(streamReader.ReadToEnd());
					}
				}
				catch (Exception)
				{
				}
			}
		}
		CommandAttribute.bool_0 = class25_0.bool_0;
		return class25_0;
	}

	internal static string smethod_7(string string_6)
	{
		PacketStreamAdapter @class = new PacketStreamAdapter();
		PacketStreamAdapter.MessageDispatcher class2 = new PacketStreamAdapter.MessageDispatcher();
		class2.method_3(Convert.FromBase64String(TcpServer.string_0));
		class2.method_1(Convert.FromBase64String(ConnectionSessionStore.string_3));
		@class.method_1(class2);
		return @class.method_8(string_6);
	}

	public bool method_0(int int_1)
	{
		if (bool_0)
		{
			return int_1 <= int_0;
		}
		return false;
	}
}
