using System;
using System.Text;

internal class AsyncSocketReader
{
	public static bool smethod_0(string string_0, string string_1)
	{
		return smethod_1(Encoding.UTF8.GetBytes(string_0), Convert.FromBase64String(string_1));
	}

	public static bool smethod_1(byte[] byte_0, byte[] byte_1)
	{
		return HandlerAttribute.smethod_0().VerifyData(byte_0, "MD5", byte_1);
	}

	internal static string[] smethod_2(string string_0)
	{
		return Encoding.UTF8.GetString(Convert.FromBase64String(string_0)).Split(';');
	}

	internal static DateTime smethod_3(long long_0)
	{
		return new DateTime(long_0);
	}

	internal static void smethod_4()
	{
		try
		{
			HandlerAttribute.smethod_0().FromXmlString(MessageStream.smethod_4());
		}
		catch
		{
		}
	}

	internal static object[] smethod_5()
	{
		try
		{
			string text = MessageStream.smethod_3();
			string[] array = text.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
			if (ConnectionThrottle.smethod_0(array[0], array[1]))
			{
				string[] array2 = smethod_2(array[0]);
				return new object[3]
				{
					int.Parse(array2[2]),
					smethod_3(long.Parse(array2[3])),
					smethod_3(long.Parse(array2[3])) > DateTime.Now
				};
			}
			return null;
		}
		catch
		{
			return null;
		}
	}
}
