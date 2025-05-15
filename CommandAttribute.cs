using System;
using Beetle;

[AttributeUsage(AttributeTargets.All)]
internal class CommandAttribute : Attribute
{
	[ValidateAttribute]
	public static string string_0 = "KntezZn3/HTLy0OE4rsKQJAtd7Q9rU8f";

	[EncryptAttribute]
	public static string string_1 = "baxxfKKgHV9XwOpsrn1uYA==";

	public static bool bool_0 = false;

	internal int int_0;

	public static bool bool_1 = false;

	internal MessageReceivedEventArgs eventArgs0_0;

	public byte[] byte_0;

	public int int_1;

	public int int_2;

	public int int_3;

	public int int_4;

	private ByteArraySegment byteArraySegment_0;

	public CommandAttribute attribute1_0;

	public CommandAttribute(string string_2)
	{
	}

	public CommandAttribute(int int_5)
	{
		byte_0 = new byte[int_5];
		int_4 = int_5;
		int_3 = int_5;
		byteArraySegment_0 = new ByteArraySegment();
		byteArraySegment_0.SetInfo(byte_0, 0, int_5);
	}

	public MessageReceivedEventArgs method_0()
	{
		if (eventArgs0_0 == null)
		{
			eventArgs0_0 = new MessageReceivedEventArgs();
			eventArgs0_0.SetBuffer(byte_0, 0, int_4);
		}
		eventArgs0_0.SetBuffer(0, int_2);
		return eventArgs0_0;
	}

	public int method_1(int int_5)
	{
		int num = int_2 - int_1;
		if (num >= int_5)
		{
			return int_5;
		}
		return num;
	}

	public bool method_2(int int_5)
	{
		return int_3 >= int_5;
	}

	public void method_3(int int_5)
	{
		if (int_1 == int_2)
		{
			int_2 += int_5;
		}
		else
		{
			int num = int_2 - int_1;
			if (num < int_5)
			{
				int_2 += int_5 - num;
			}
		}
		int_3 = int_4 - int_2;
		int_1 += int_5;
	}

	public ByteArraySegment method_4()
	{
		byteArraySegment_0.SetInfo(int_1, int_2 - int_1);
		return byteArraySegment_0;
	}

	public void method_5(int int_5)
	{
		int_1 += int_5;
	}

	public int method_6(byte[] byte_1, int int_5, int int_6)
	{
		int result;
		if (int_3 >= int_6)
		{
			Buffer.BlockCopy(byte_1, int_5, byte_0, int_1, int_6);
			method_3(int_6);
			result = int_6;
		}
		else
		{
			Buffer.BlockCopy(byte_1, int_5, byte_0, int_1, int_3);
			result = int_3;
			method_3(int_3);
		}
		return result;
	}

	public void method_7()
	{
		int_1 = 0;
		int_2 = 0;
		int_3 = int_4;
	}
}
