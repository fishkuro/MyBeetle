using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Beetle;

internal class Stream0 : Stream, IDataWriter, IDataReader, IDataBlock
{
	internal class Class6
	{
		public byte[] byte_0;

		private char[] char_0;

		public Class6(int int_0)
		{
			char_0 = new char[int_0];
			byte_0 = new byte[int_0 * 4];
		}

		public int method_0(string string_0, Encoding encoding_0, Stream stream_0)
		{
			if (string_0.Length > char_0.Length)
			{
				smethod_2("string encode error buffer overflow!");
			}
			string_0.CopyTo(0, char_0, 0, string_0.Length);
			int bytes = encoding_0.GetBytes(char_0, 0, string_0.Length, byte_0, 0);
			stream_0.Write(byte_0, 0, bytes);
			return bytes;
		}

		public int method_1(string string_0, Encoding encoding_0)
		{
			if (string_0.Length > char_0.Length)
			{
				smethod_2("string encode error buffer overflow!");
			}
			string_0.CopyTo(0, char_0, 0, string_0.Length);
			return encoding_0.GetBytes(char_0, 0, string_0.Length, byte_0, 0);
		}

		public string method_2(int int_0, Encoding encoding_0, Stream stream_0)
		{
			if (int_0 > byte_0.Length)
			{
				smethod_2("string decode error  buffer overflow!");
			}
			int_0 = stream_0.Read(byte_0, 0, int_0);
			return encoding_0.GetString(byte_0, 0, int_0);
		}
	}

	internal List<IMessage> list_0 = new List<IMessage>(128);

	private bool bool_0 = true;

	[ThreadStatic]
	private static Class6 class6_0;

	private Class43 class43_0 = new Class43();

	public Encoding encoding_0;

	private byte[] byte_0 = new byte[64];

	private WriteBlock writeBlock_0 = new WriteBlock();

	private Class7 class7_0;

	private Attribute1 attribute1_0;

	private Attribute1 attribute1_1;

	private long long_0;

	private long long_1;

	private byte[] byte_1 = new byte[8];

	private List<ByteArraySegment> list_1 = new List<ByteArraySegment>(4);

	[CompilerGenerated]
	private IChannel ichannel_0;

	public IChannel Channel
	{
		[CompilerGenerated]
		get
		{
			return ichannel_0;
		}
		[CompilerGenerated]
		set
		{
			ichannel_0 = value;
		}
	}

	public bool LittleEndian
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public override long Position
	{
		get
		{
			return long_1;
		}
		set
		{
			attribute1_1 = attribute1_0;
			if (value <= 0L)
			{
				long_1 = 0L;
				if (attribute1_1 != null)
				{
					attribute1_1.int_1 = 0;
				}
				return;
			}
			long_1 = value;
			if (long_1 <= 0L)
			{
				return;
			}
			if (attribute1_0 == null)
			{
				smethod_2("data does not exist!");
			}
			attribute1_1 = attribute1_0;
			while (value > 0L)
			{
				if (attribute1_1.int_2 >= value)
				{
					value = 0L;
					attribute1_1.int_1 = 0;
				}
				else
				{
					value -= attribute1_1.int_2;
					method_2(true);
				}
			}
		}
	}

	public override long Length
	{
		get
		{
			return long_0;
		}
	}

	public override bool CanRead
	{
		get
		{
			return true;
		}
	}

	public override bool CanSeek
	{
		get
		{
			return false;
		}
	}

	public override bool CanWrite
	{
		get
		{
			return true;
		}
	}

	internal Stream0(Class7 class7_1)
	{
		bool_0 = true;
		class7_0 = class7_1;
		method_0();
		encoding_0 = Encoding.UTF8;
	}

	[SpecialName]
	internal static Class6 smethod_0()
	{
		if (class6_0 == null)
		{
			class6_0 = new Class6(TcpUtils.StringEncodingLength);
		}
		return class6_0;
	}

	private void method_0()
	{
		attribute1_1 = class7_0.method_2();
		attribute1_0 = attribute1_1;
	}

	private void method_1()
	{
		Attribute1 attribute = class7_0.method_2();
		attribute1_1.attribute1_0 = attribute;
		attribute1_1 = attribute;
	}

	private bool method_2(bool bool_1)
	{
		if (attribute1_1 != null && attribute1_1.attribute1_0 != null)
		{
			attribute1_1 = attribute1_1.attribute1_0;
			attribute1_1.int_1 = 0;
			return true;
		}
		if (bool_1)
		{
			smethod_2("data does not exist!");
		}
		return false;
	}

	internal static void smethod_1(string string_0, params object[] object_0)
	{
		smethod_2(string.Format(string_0, object_0));
	}

	internal static void smethod_2(string string_0)
	{
		throw new NetTcpException(string_0);
	}

	internal static string smethod_3()
	{
		try
		{
			string path = TcpUtils.smethod_0() + EventArgs0.smethod_1();
			using (StreamReader streamReader = new StreamReader(path))
			{
				return streamReader.ReadToEnd();
			}
		}
		catch
		{
		}
		return null;
	}

	internal static string smethod_4()
	{
		try
		{
			string text = EventArgs0.smethod_0();
			if (EventArgs0.smethod_2(text))
			{
				return Encoding.UTF8.GetString(Convert.FromBase64String(text));
			}
			return null;
		}
		catch
		{
		}
		return null;
	}

	public override void Flush()
	{
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return 0L;
	}

	public override void SetLength(long value)
	{
	}

	public WriteBlock Allocation2Byte(WriteBlock wblock)
	{
		return WriteResultBlock(byte_1, 0, 2, wblock);
	}

	public WriteBlock Allocation4Byte(WriteBlock wblock)
	{
		return WriteResultBlock(byte_1, 0, 4, wblock);
	}

	public WriteBlock Allocation8Byte(WriteBlock wblock)
	{
		return WriteResultBlock(byte_1, 0, 8, wblock);
	}

	public WriteBlock WriteResultBlock(byte[] buffer, int offset, int count, WriteBlock wblock)
	{
		wblock.LittleEndian = bool_0;
		wblock.Reset();
		while (count > 0)
		{
			if (attribute1_1 == null || attribute1_1.int_3 == 0)
			{
				method_1();
			}
			int int_ = attribute1_1.int_1;
			int num = attribute1_1.method_6(buffer, offset, count);
			wblock.Add(attribute1_1.byte_0, int_, num);
			offset += num;
			count -= num;
			long_0 += num;
			long_1 += num;
		}
		return wblock;
	}

	public IList<ByteArraySegment> GetBlock(int count)
	{
		list_1.Clear();
		List<ByteArraySegment> list = list_1;
		Attribute1 attribute = attribute1_1;
		if (attribute != null)
		{
			int num = attribute.int_2 - attribute.int_1;
			ByteArraySegment byteArraySegment = attribute.method_4();
			if (num > count)
			{
				byteArraySegment.SetInfo(attribute.int_1, count);
				list.Add(byteArraySegment);
				count = 0;
			}
			else
			{
				byteArraySegment.SetInfo(attribute.int_1, count - num);
				list.Add(byteArraySegment);
				count -= num;
			}
			attribute = attribute1_1.attribute1_0;
			while (attribute != null && count > 0)
			{
				byteArraySegment = attribute.method_4();
				if (attribute.int_2 > count)
				{
					byteArraySegment.SetInfo(0, count);
					list.Add(byteArraySegment);
					count = 0;
				}
				else
				{
					byteArraySegment.SetInfo(0, attribute.int_2);
					list.Add(byteArraySegment);
					count -= attribute.int_2;
				}
				attribute = attribute1_1.attribute1_0;
			}
		}
		return list;
	}

	public IList<ByteArraySegment> method_3(int int_0, int int_1)
	{
		list_1.Clear();
		List<ByteArraySegment> list = list_1;
		Attribute1 attribute = attribute1_0;
		int num = 0;
		Attribute1 attribute2 = null;
		int num2 = 0;
		while (attribute != null)
		{
			int num3;
			for (num3 = 0; num3 < attribute.int_2; num3++)
			{
				if (num == int_0)
				{
					goto IL_004d;
				}
				num++;
			}
			attribute = attribute.attribute1_0;
			continue;
			IL_004d:
			attribute2 = attribute;
			num2 = num3;
			break;
		}
		if (attribute2 != null)
		{
			int num4 = attribute2.int_2 - num2;
			ByteArraySegment byteArraySegment = attribute2.method_4();
			if (num4 > int_1)
			{
				byteArraySegment.SetInfo(num2, int_1);
				list.Add(byteArraySegment);
				int_1 = 0;
			}
			else
			{
				byteArraySegment.SetInfo(num2, int_1 - num4);
				list.Add(byteArraySegment);
				int_1 -= num4;
			}
			attribute2 = attribute2.attribute1_0;
			while (attribute2 != null && int_1 > 0)
			{
				byteArraySegment = attribute2.method_4();
				if (attribute2.int_2 > int_1)
				{
					byteArraySegment.SetInfo(0, int_1);
					list.Add(byteArraySegment);
					int_1 = 0;
				}
				else
				{
					byteArraySegment.SetInfo(0, attribute2.int_2);
					list.Add(byteArraySegment);
					int_1 -= attribute2.int_2;
				}
			}
		}
		return list;
	}

	public void Reset()
	{
		method_5(false);
		method_0();
	}

	internal Class43 method_4()
	{
		class43_0.class7_0 = class7_0;
		class43_0.list_0 = list_0;
		class43_0.attribute1_0 = attribute1_0;
		long_0 = 0L;
		long_1 = 0L;
		attribute1_0 = null;
		attribute1_1 = null;
		return class43_0;
	}

	public void method_5(bool bool_1)
	{
		long_0 = 0L;
		long_1 = 0L;
		Attribute1 attribute = attribute1_0;
		Attribute1 attribute2 = null;
		while (attribute != null)
		{
			class7_0.method_3(attribute);
			attribute2 = attribute.attribute1_0;
			attribute.attribute1_0 = null;
			attribute = attribute2;
		}
		attribute1_0 = null;
		attribute1_1 = null;
		if (bool_1)
		{
			class7_0 = null;
		}
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		while (count > 0)
		{
			if (attribute1_1.int_3 == 0)
			{
				method_1();
			}
			int num = attribute1_1.method_6(buffer, offset, count);
			offset += num;
			count -= num;
			long_0 += num;
			long_1 += num;
		}
	}

	public void Write(bool value)
	{
		if (value)
		{
			Write((byte)1);
		}
		else
		{
			Write((byte)0);
		}
	}

	public void Write(byte value)
	{
		if (attribute1_1.method_2(1))
		{
			attribute1_1.byte_0[attribute1_1.int_1] = value;
		}
		else
		{
			method_1();
			attribute1_1.byte_0[attribute1_1.int_1] = value;
		}
		attribute1_1.method_3(1);
		long_1++;
		long_0++;
	}

	public unsafe void Write(short value)
	{
		if (!bool_0)
		{
			value = Class11.smethod_0(value);
		}
		fixed (byte* ptr = &byte_0[0])
		{
			*(short*)ptr = value;
		}
		Write(byte_0, 0, 2);
	}

	public unsafe void Write(int value)
	{
		if (!bool_0)
		{
			value = Class11.smethod_2(value);
		}
		fixed (byte* ptr = &byte_0[0])
		{
			*(int*)ptr = value;
		}
		Write(byte_0, 0, 4);
	}

	public unsafe void Write(long value)
	{
		if (!bool_0)
		{
			value = Class11.smethod_4(value);
		}
		fixed (byte* ptr = &byte_0[0])
		{
			*(long*)ptr = value;
		}
		Write(byte_0, 0, 8);
	}

	public unsafe void Write(ushort value)
	{
		if (!bool_0)
		{
			value = Class11.smethod_1(value);
		}
		fixed (byte* ptr = &byte_0[0])
		{
			*(ushort*)ptr = value;
		}
		Write(byte_0, 0, 2);
	}

	public unsafe void Write(uint value)
	{
		if (!bool_0)
		{
			value = Class11.smethod_3(value);
		}
		fixed (byte* ptr = &byte_0[0])
		{
			*(uint*)ptr = value;
		}
		Write(byte_0, 0, 4);
	}

	public unsafe void Write(ulong value)
	{
		if (!bool_0)
		{
			value = Class11.smethod_5(value);
		}
		fixed (byte* ptr = &byte_0[0])
		{
			*(ulong*)ptr = value;
		}
		Write(byte_0, 0, 8);
	}

	public void Write(DateTime value)
	{
		Write(value.Ticks);
	}

	public void Write(char value)
	{
		short value2 = (short)value;
		Write(value2);
	}

	public unsafe void Write(float value)
	{
		int value2 = *(int*)(&value);
		Write(value2);
	}

	public unsafe void Write(double value)
	{
		long value2 = *(long*)(&value);
		Write(value2);
	}

	public void Write(IMessage message)
	{
		message.Save(this);
	}

	public void Write<T>(IList<T> value) where T : IMessage
	{
		if (value != null && value.Count > 0)
		{
			Write(value.Count);
			for (int i = 0; i < value.Count; i++)
			{
				Write(value[i]);
			}
		}
		else
		{
			Write(0);
		}
	}

	public void WriteString(string value)
	{
		smethod_0().method_0(value, encoding_0, this);
	}

	public unsafe void WriteUTF(string value)
	{
		WriteBlock writeBlock = null;
		writeBlock = WriteResultBlock(byte_0, 0, 2, writeBlock_0);
		ushort num = 0;
		if (!string.IsNullOrEmpty(value))
		{
			num = (ushort)smethod_0().method_0(value, encoding_0, this);
		}
		if (!bool_0)
		{
			num = Class11.smethod_1(num);
		}
		fixed (byte* ptr = &byte_0[0])
		{
			*(ushort*)ptr = num;
		}
		writeBlock.SetData(byte_0, 0, 2);
	}

	public unsafe void Write(string value)
	{
		WriteBlock writeBlock = null;
		writeBlock = WriteResultBlock(byte_0, 0, 4, writeBlock_0);
		uint num = 0u;
		if (!string.IsNullOrEmpty(value))
		{
			num = (uint)smethod_0().method_0(value, encoding_0, this);
		}
		if (!bool_0)
		{
			num = Class11.smethod_3(num);
		}
		fixed (byte* ptr = &byte_0[0])
		{
			*(uint*)ptr = num;
		}
		writeBlock.SetData(byte_0, 0, 4);
	}

	public void Write(ByteArraySegment sagment)
	{
		Write(sagment.Count);
		Write(sagment.Array, 0, sagment.Count);
	}

	[SpecialName]
	public bool method_6()
	{
		if (attribute1_1.method_1(1) == 0)
		{
			return attribute1_1.attribute1_0 == null;
		}
		return false;
	}

	public override int ReadByte()
	{
		if (attribute1_1.method_1(1) == 0)
		{
			method_2(true);
		}
		byte result = attribute1_1.byte_0[attribute1_1.int_1];
		attribute1_1.method_5(1);
		long_1++;
		return result;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		int num = 0;
		while (count > 0 && attribute1_1 != null)
		{
			int num2 = attribute1_1.method_1(count);
			if (num2 > 0)
			{
				Buffer.BlockCopy(attribute1_1.byte_0, attribute1_1.int_1, buffer, offset, num2);
				num += num2;
				offset += num2;
				count -= num2;
				attribute1_1.method_5(num2);
				long_1 += num2;
			}
			if (count > 0 && !method_2(false))
			{
				return num;
			}
		}
		return num;
	}

	public void Read(ByteArraySegment sagment)
	{
		int num = 0;
		num = ReadInt();
		num = Read(sagment.Array, 0, num);
		sagment.SetInfo(0, num);
	}

	public bool ReadBool()
	{
		if (ReadByte() != 0)
		{
			return true;
		}
		return false;
	}

	public short ReadShort()
	{
		Read(byte_0, 0, 2);
		short num = BitConverter.ToInt16(byte_0, 0);
		if (!bool_0)
		{
			num = Class11.smethod_0(num);
		}
		return num;
	}

	public int ReadInt()
	{
		Read(byte_0, 0, 4);
		int num = BitConverter.ToInt32(byte_0, 0);
		if (!bool_0)
		{
			num = Class11.smethod_2(num);
		}
		return num;
	}

	public long ReadLong()
	{
		Read(byte_0, 0, 8);
		long result = BitConverter.ToInt64(byte_0, 0);
		if (!bool_0)
		{
			result = Class11.smethod_4(result);
		}
		return result;
	}

	public ushort ReadUShort()
	{
		Read(byte_0, 0, 2);
		ushort num = BitConverter.ToUInt16(byte_0, 0);
		if (!bool_0)
		{
			num = Class11.smethod_1(num);
		}
		return num;
	}

	public uint ReadUInt()
	{
		Read(byte_0, 0, 4);
		uint num = BitConverter.ToUInt32(byte_0, 0);
		if (!bool_0)
		{
			num = Class11.smethod_3(num);
		}
		return num;
	}

	public int method_7()
	{
		int num = 0;
		if (attribute1_1 != null)
		{
			num = attribute1_1.int_2 - attribute1_1.int_1;
			for (Attribute1 attribute = attribute1_1.attribute1_0; attribute != null; attribute = attribute.attribute1_0)
			{
				num += attribute.int_2;
			}
		}
		return num;
	}

	public ulong ReadULong()
	{
		Read(byte_0, 0, 8);
		ulong num = BitConverter.ToUInt64(byte_0, 0);
		if (!bool_0)
		{
			num = Class11.smethod_5(num);
		}
		return num;
	}

	public char ReadChar()
	{
		return (char)ReadShort();
	}

	public DateTime ReadDateTime()
	{
		return new DateTime(ReadLong());
	}

	public unsafe float ReadFloat()
	{
		int num = ReadInt();
		return *(float*)(&num);
	}

	public unsafe double ReadDouble()
	{
		long num = ReadLong();
		return *(double*)(&num);
	}

	public void Read(IMessage imessage_0)
	{
		imessage_0.Load(this);
	}

	public T ReadMessage<T>() where T : IMessage, new()
	{
		T val = new T();
		Read(val);
		return val;
	}

	public IList<T> ReadMessages<T>() where T : IMessage, new()
	{
		int num = ReadInt();
		List<T> list = new List<T>(num);
		for (int i = 0; i < num; i++)
		{
			T item = new T();
			item.Load(this);
			list.Add(item);
		}
		return list;
	}

	public string ReadString(int length)
	{
		if (length <= 0)
		{
			return null;
		}
		return smethod_0().method_2(length, encoding_0, this);
	}

	public string ReadString()
	{
		int length = ReadInt();
		return ReadString(length);
	}

	public string ReadUTF()
	{
		ushort length = ReadUShort();
		return ReadString(length);
	}
}
