using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Beetle;

internal class BufferedPacketStream
{
	public bool bool_0;

	public string string_0;

	public string string_1;

	public int int_0;

	public DateTime dateTime_0;

	private static SocketReceiveEventArgs class25_0 = null;

	private static object object_0 = null;

	private static string string_2;

	private static string string_3;

	private static char[] char_0 = new char[2] { '\r', '\n' };

	public static bool smethod_0(string string_4, string string_5)
	{
		return smethod_1(Encoding.UTF8.GetBytes(string_4), Convert.FromBase64String(string_5));
	}

	public static bool smethod_1(byte[] byte_0, byte[] byte_1)
	{
		return ((RSACryptoServiceProvider)object_0).VerifyData(byte_0, "MD5", byte_1);
	}

	public static string smethod_2(string string_4)
	{
		return Encoding.UTF8.GetString(smethod_3(Convert.FromBase64String(string_4)));
	}

	public static byte[] smethod_3(byte[] byte_0)
	{
		return ((RSACryptoServiceProvider)object_0).Decrypt(byte_0, false);
	}

	public static SocketReceiveEventArgs smethod_4()
	{
		lock (typeof(SocketReceiveEventArgs))
		{
			if (class25_0 == null)
			{
				class25_0 = new SocketReceiveEventArgs();
				try
				{
					MethodInfo[] methods = typeof(CryptoProvider).GetMethods(BindingFlags.Static | BindingFlags.Public);
					foreach (MethodInfo methodInfo in methods)
					{
						if (methodInfo.GetCustomAttributes(typeof(ProtocolAttribute), false).Length > 0)
						{
							object_0 = methodInfo.Invoke(null, null);
						}
					}
					FieldInfo[] fields = typeof(SocketAsyncControl).GetFields(BindingFlags.Static | BindingFlags.Public);
					foreach (FieldInfo fieldInfo in fields)
					{
						if (fieldInfo.GetCustomAttributes(typeof(EventAttribute), false).Length > 0)
						{
							string_2 = (string)fieldInfo.GetValue(null);
						}
					}
					FieldInfo[] fields2 = typeof(SocketAsyncControl).GetFields(BindingFlags.Static | BindingFlags.Public);
					foreach (FieldInfo fieldInfo2 in fields2)
					{
						if (fieldInfo2.GetCustomAttributes(typeof(CommandAttribute), false).Length > 0)
						{
							string_3 = (string)fieldInfo2.GetValue(null);
						}
					}
					((RSACryptoServiceProvider)object_0).FromXmlString(smethod_5(string_3));
					string path = TcpUtils.smethod_0() + smethod_5(string_2);
					using (StreamReader streamReader = new StreamReader(path))
					{
						string[] array = streamReader.ReadToEnd().Split(char_0, StringSplitOptions.RemoveEmptyEntries);
						if (smethod_0(array[0], array[1]))
						{
							string[] array2 = Encoding.UTF8.GetString(Convert.FromBase64String(array[0])).Split(';');
							class25_0.string_0 = array2[0];
							class25_0.string_1 = array2[1];
							class25_0.int_0 = int.Parse(array2[2]);
							class25_0.dateTime_0 = new DateTime(long.Parse(array2[3]));
							class25_0.bool_0 = class25_0.dateTime_0 > DateTime.Now;
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}
		return class25_0;
	}

	internal static string smethod_5(string string_4)
	{
		PacketStreamAdapter @class = new PacketStreamAdapter();
		PacketStreamAdapter.MessageDispatcher class2 = new PacketStreamAdapter.MessageDispatcher();
		class2.method_3(Convert.FromBase64String(TcpServer.string_0));
		class2.method_1(Convert.FromBase64String(ConnectionSessionStore.string_3));
		@class.method_1(class2);
		return @class.method_8(string_4);
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
