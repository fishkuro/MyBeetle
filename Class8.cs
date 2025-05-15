using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;

internal class Class8
{
	public static string string_0;

	public static Hashtable hashtable_0;

	public static bool bool_0;

	private static int int_0;

	public static string string_1;

	public static string string_2;

	private static Class10 class10_0;

	public static int int_1;

	public static DateTime dateTime_0;

	private static Timer timer_0;

	static Class8()
	{
		string_0 = "a4e342352cac8ed74729714b48cb3057";
		hashtable_0 = new Hashtable();
		bool_0 = false;
		int_0 = 10;
		string_1 = null;
		string_2 = null;
		int_1 = 0;
		dateTime_0 = DateTime.MinValue;
		smethod_1();
	}

	public byte[] method_0(byte[] byte_0)
	{
		IList<byte> list = new List<byte>();
		MemoryStream memoryStream = new MemoryStream(byte_0);
		smethod_0(1024, 2);
		int num = 0;
		while (num >= 0)
		{
			list.Add((byte)num);
		}
		memoryStream.Close();
		byte[] array = new byte[list.Count];
		list.CopyTo(array, 0);
		return array;
	}

	public static void smethod_0(int int_2, int int_3)
	{
		lock (hashtable_0)
		{
			hashtable_0[int_2] = int_3;
		}
	}

	public static void smethod_1()
	{
		Class9.smethod_4();
		object[] object_ = Class9.smethod_5();
		if (class10_0 == null)
		{
			class10_0 = new Class10(object_, hashtable_0);
		}
	}
}
