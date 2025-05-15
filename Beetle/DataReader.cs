using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Beetle
{
	public class DataReader : IDataReader
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

		public void Reset()
		{
		}

		public DataReader(Stream stream, bool littleEndian)
		{
			stream_0 = stream;
			bool_0 = littleEndian;
		}

		public void SetStream(Stream stream)
		{
			stream_0 = stream;
		}

		public int ReadByte()
		{
			return stream_0.ReadByte();
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			return stream_0.Read(buffer, offset, count);
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
				num = DataSegmentPool.smethod_0(num);
			}
			return num;
		}

		public int ReadInt()
		{
			Read(byte_0, 0, 4);
			int num = BitConverter.ToInt32(byte_0, 0);
			if (!bool_0)
			{
				num = DataSegmentPool.smethod_2(num);
			}
			return num;
		}

		public long ReadLong()
		{
			Read(byte_0, 0, 8);
			long num = BitConverter.ToInt64(byte_0, 0);
			if (!bool_0)
			{
				num = DataSegmentPool.smethod_4(num);
			}
			return num;
		}

		public ushort ReadUShort()
		{
			Read(byte_0, 0, 2);
			ushort num = BitConverter.ToUInt16(byte_0, 0);
			if (!bool_0)
			{
				num = DataSegmentPool.smethod_1(num);
			}
			return num;
		}

		public uint ReadUInt()
		{
			Read(byte_0, 0, 4);
			uint num = BitConverter.ToUInt32(byte_0, 0);
			if (!bool_0)
			{
				num = DataSegmentPool.smethod_3(num);
			}
			return num;
		}

		public ulong ReadULong()
		{
			Read(byte_0, 0, 8);
			ulong num = BitConverter.ToUInt64(byte_0, 0);
			if (!bool_0)
			{
				num = DataSegmentPool.smethod_5(num);
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
			return MessageStream.smethod_0().method_2(length, Coding, stream_0);
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
}
