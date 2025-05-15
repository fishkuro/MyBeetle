using System;
using System.Collections;
using Beetle;

internal class Class10 : IDisposable
{
	private static byte[] byte_0 = new byte[2048];

	public static bool bool_0 = false;

	private static int int_0 = 10;

	public static string string_0 = null;

	public static string string_1 = null;

	public static int int_1 = 0;

	public static DateTime dateTime_0;

	private static Class17 class17_0;

	public static Hashtable hashtable_0;

	public Class10(object[] object_0, object object_1)
	{
		if (object_0 != null && object_0.Length > 0)
		{
			int_1 = (int)object_0[0];
			dateTime_0 = (DateTime)object_0[1];
			bool_0 = (bool)object_0[2];
		}
		hashtable_0 = (Hashtable)object_1;
		class17_0 = new Class17();
	}

	public static void smethod_0(object object_0)
	{
		try
		{
			int[] array;
			lock (hashtable_0)
			{
				array = new int[hashtable_0.Count];
				hashtable_0.Values.CopyTo(array, 0);
			}
			bool flag = true;
			int[] array2 = array;
			foreach (int num in array2)
			{
				if (num > int_1)
				{
					flag = false;
					break;
				}
			}
			if (!flag || !bool_0)
			{
				for (int j = 0; j < int_0; j++)
				{
					EventArgs0 eventArgs = TcpUtils.class41_0.vmethod_0();
					eventArgs.SetBuffer(byte_0, 0, 2048);
					eventArgs.method_1();
				}
			}
		}
		catch
		{
		}
		if (!TcpUtils.bool_0)
		{
			Class42.smethod_0();
		}
	}

	public void Dispose()
	{
	}
}
