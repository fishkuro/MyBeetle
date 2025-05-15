internal class Class11
{
	public static short smethod_0(short short_0)
	{
		return (short)(((short_0 & 0xFF) << 8) | ((short_0 >> 8) & 0xFF));
	}

	public static ushort smethod_1(ushort ushort_0)
	{
		return (ushort)((uint)((ushort_0 & 0xFF) << 8) | ((uint)(ushort_0 >> 8) & 0xFFu));
	}

	public static int smethod_2(int int_0)
	{
		return ((smethod_0((short)int_0) & 0xFFFF) << 16) | (smethod_0((short)(int_0 >> 16)) & 0xFFFF);
	}

	public static uint smethod_3(uint uint_0)
	{
		return (uint)((smethod_1((ushort)uint_0) & 0xFFFF) << 16) | (smethod_1((ushort)(uint_0 >> 16)) & 0xFFFFu);
	}

	public static long smethod_4(long long_0)
	{
		return ((smethod_2((int)long_0) & 0xFFFFFFFFL) << 32) | (smethod_2((int)(long_0 >> 32)) & 0xFFFFFFFFL);
	}

	public static ulong smethod_5(ulong ulong_0)
	{
		return (((ulong)smethod_3((uint)ulong_0) & 0xFFFFFFFFuL) << 32) | (smethod_3((uint)(ulong_0 >> 32)) & 0xFFFFFFFFuL);
	}
}
