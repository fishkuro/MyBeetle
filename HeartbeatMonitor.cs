using System;
using System.Security.Cryptography;
using Beetle;

internal class HeartbeatMonitor
{
	public bool bool_0;

	public string string_0;

	public string string_1;

	public int int_0;

	public DateTime dateTime_0;

	private static HeartbeatMonitor class29_0 = null;

	private static object object_0 = null;

	internal static string string_2 = "V/r2I2CpRaI=";

	public static byte[] smethod_0(byte[] byte_0)
	{
		return ((RSACryptoServiceProvider)object_0).Decrypt(byte_0, false);
	}

	public static HeartbeatMonitor smethod_1()
	{
		lock (typeof(HeartbeatMonitor))
		{
			if (class29_0 == null)
			{
				class29_0 = ConnectionThrottle.smethod_4();
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
		PacketStreamAdapter @class = new PacketStreamAdapter();
		PacketStreamAdapter.MessageDispatcher class2 = new PacketStreamAdapter.MessageDispatcher();
		class2.method_3(Convert.FromBase64String(TcpServer.string_0));
		class2.method_1(Convert.FromBase64String(ConnectionSessionStore.string_3));
		@class.method_1(class2);
		return @class.method_8(string_3);
	}
}
