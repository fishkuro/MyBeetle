using System;

namespace Beetle.Protocol
{
	public abstract class SizePackage : Package
	{
		private class Class0
		{
			public bool bool_0 = true;

			public int int_0 = -1;

			private int int_1;

			public byte[] byte_0 = new byte[4];

			public void method_0(byte byte_1)
			{
				byte_0[int_1] = byte_1;
				if (int_1 == 3)
				{
					int_0 = BitConverter.ToInt32(byte_0, 0);
					if (!bool_0)
					{
						int_0 = Class11.smethod_2(int_0);
					}
				}
				else
				{
					int_1++;
				}
			}

			public void method_1()
			{
				int_0 = -1;
				int_1 = 0;
			}
		}

		private bool bool_3;

		private Class0 class0_0;

		private ReadObjectInfo readObjectInfo_0 = new ReadObjectInfo();

		protected WriteBlock mWriteBlock = new WriteBlock();

		public SizePackage()
		{
		}

		public SizePackage(IChannel channel)
			: base(channel)
		{
		}

		public override void Import(byte[] data, int start, int count)
		{
			if (class0_0 == null)
			{
				class0_0 = new Class0();
				class0_0.bool_0 = base.LittleEndian;
			}
			while (true)
			{
				if (count <= 0)
				{
					return;
				}
				if (!bool_3)
				{
					class0_0.method_1();
					((Stream0)Writer).Reset();
					bool_3 = true;
				}
				if (class0_0.int_0 == -1)
				{
					while (count > 0 && class0_0.int_0 == -1)
					{
						class0_0.method_0(data[start]);
						start++;
						count--;
					}
					if (class0_0.int_0 > TcpUtils.DataPacketMaxLength)
					{
						break;
					}
					if (class0_0.int_0 > 0)
					{
						Writer.Write(class0_0.byte_0, 0, 4);
					}
				}
				else if (method_3(data, ref start, ref count))
				{
					if (count > 0)
					{
						BufferOffset = start;
						BufferCount = count;
					}
					else
					{
						BufferOffset = 0;
						BufferCount = 0;
					}
					bool_3 = false;
					Writer.Position = 0L;
					OnMessageDataReader(Writer);
				}
			}
			throw NetTcpException.DataOverflow();
		}

		private bool method_3(byte[] byte_0, ref int int_0, ref int int_1)
		{
			if (int_1 >= class0_0.int_0)
			{
				Writer.Write(byte_0, int_0, class0_0.int_0);
				int_0 += class0_0.int_0;
				int_1 -= class0_0.int_0;
				return true;
			}
			Writer.Write(byte_0, int_0, int_1);
			int_0 += int_1;
			class0_0.int_0 -= int_1;
			int_1 = 0;
			return false;
		}

		protected virtual void OnReadHeader(IDataReader reader)
		{
			reader.ReadInt();
		}

		protected virtual void ReadBody(IDataReader reader, IMessage message)
		{
			message.Load(reader);
		}

		public override IMessage MessageRead(IDataReader reader)
		{
			OnReadHeader(reader);
			IMessage message = null;
			message = ReadMessageByType(reader, readObjectInfo_0);
			if (message == null)
			{
				throw NetTcpException.TypeNotFound(readObjectInfo_0.ToString());
			}
			try
			{
				ReadBody(reader, message);
				return message;
			}
			catch (Exception innerexception)
			{
				NetTcpException ex = NetTcpException.ObjectLoadError(readObjectInfo_0.ToString(), innerexception);
				throw ex;
			}
		}

		protected virtual void WriteBody(IDataWriter writer, IMessage imessage_0)
		{
			imessage_0.Save(writer);
		}

		public override void MessageWrite(IMessage imessage_0, IDataWriter writer)
		{
			int num = (int)writer.Length;
			WriteBlock writeBlock = ((Stream0)writer).Allocation4Byte(mWriteBlock);
			writeBlock.LittleEndian = base.LittleEndian;
			WriteMessageType(imessage_0, writer);
			WriteBody(writer, imessage_0);
			int data = (int)writer.Length - num - 4;
			writeBlock.SetData(data);
		}

		protected abstract IMessage ReadMessageByType(IDataReader reader, ReadObjectInfo typeTag);

		protected abstract void WriteMessageType(IMessage imessage_0, IDataWriter writer);

		protected override void OnDisposed()
		{
			base.OnDisposed();
		}
	}
}
