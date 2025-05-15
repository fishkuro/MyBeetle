using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Beetle
{
	public class DataWriter : IDataWriter
	{
		private bool bool_0 = true;

		public Encoding Coding = Encoding.UTF8;

		private Stream stream_0;

		private byte[] byte_0 = new byte[8];

		[CompilerGenerated]
		private IChannel ichannel_0;

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

		public long Position
		{
			get
			{
				return stream_0.Position;
			}
			set
			{
				stream_0.Position = value;
			}
		}

		public long Length
		{
			get
			{
				return stream_0.Length;
			}
		}

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

		public DataWriter(Stream stream, bool littleEndian)
		{
			stream_0 = stream;
			bool_0 = littleEndian;
		}

		public void Reset()
		{
		}

		public void SetStream(Stream stream)
		{
			stream_0 = stream;
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
			stream_0.WriteByte(value);
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
			stream_0.Write(byte_0, 0, 2);
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
			stream_0.Write(byte_0, 0, 4);
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
			stream_0.Write(byte_0, 0, 8);
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
			stream_0.Write(byte_0, 0, 2);
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
			stream_0.Write(byte_0, 0, 4);
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
			stream_0.Write(byte_0, 0, 8);
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
			Stream0.smethod_0().method_0(value, Coding, stream_0);
		}

		public unsafe void WriteUTF(string value)
		{
			ushort num = 0;
			if (!string.IsNullOrEmpty(value))
			{
				num = (ushort)Stream0.smethod_0().method_1(value, Coding);
			}
			ushort num2 = (bool_0 ? num : Class11.smethod_1(num));
			fixed (byte* ptr = &byte_0[0])
			{
				*(ushort*)ptr = num2;
			}
			stream_0.Write(byte_0, 0, 2);
			stream_0.Write(Stream0.smethod_0().byte_0, 0, num);
		}

		public unsafe void Write(string value)
		{
			int num = 0;
			if (!string.IsNullOrEmpty(value))
			{
				num = Stream0.smethod_0().method_1(value, Coding);
			}
			if (!bool_0)
			{
				Class11.smethod_2(num);
			}
			fixed (byte* ptr = &byte_0[0])
			{
				*(int*)ptr = num;
			}
			stream_0.Write(byte_0, 0, 4);
			stream_0.Write(Stream0.smethod_0().byte_0, 0, num);
		}

		public void Write(ByteArraySegment sagment)
		{
			Write(sagment.Count);
			stream_0.Write(sagment.Array, 0, sagment.Count);
		}

		public void Write(byte[] buffer, int offset, int count)
		{
			stream_0.Write(buffer, offset, count);
		}
	}
}
