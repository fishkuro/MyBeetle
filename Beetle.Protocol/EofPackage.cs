using System;

namespace Beetle.Protocol
{
	public abstract class EofPackage : Package
	{
		private class Class3
		{
			private int int_0;

			private byte[] byte_0;

			private int int_1;

			public Class3(byte[] byte_1)
			{
				byte_0 = byte_1;
				int_0 = byte_1.Length - 1;
			}

			public bool method_0(byte byte_1)
			{
				if (byte_1 == byte_0[int_1])
				{
					if (int_1 == int_0)
					{
						return true;
					}
					int_1++;
				}
				return false;
			}

			public void method_1()
			{
				int_1 = 0;
			}
		}

		public static byte[] DEFAULT_EOF = new byte[5] { 0, 13, 10, 13, 10 };

		private bool bool_3;

		private ReadObjectInfo readObjectInfo_0 = new ReadObjectInfo();

		private Class3 class3_0;

		public virtual byte[] EofData
		{
			get
			{
				return DEFAULT_EOF;
			}
		}

		public EofPackage()
		{
			class3_0 = new Class3(EofData);
		}

		public EofPackage(IChannel channel)
			: base(channel)
		{
			class3_0 = new Class3(EofData);
		}

		public override void Import(byte[] data, int start, int count)
		{
			while (true)
			{
				if (count <= 0)
				{
					return;
				}
				if (!bool_3)
				{
					((Stream0)Writer).Reset();
					class3_0.method_1();
					bool_3 = true;
				}
				if (Writer.Length > TcpUtils.DataPacketMaxLength)
				{
					break;
				}
				if (method_3(data, ref start, ref count))
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
			bool flag = false;
			int num = int_1;
			int offset = int_0;
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				flag = class3_0.method_0(byte_0[int_0]);
				num2++;
				int_0++;
				int_1--;
				if (flag)
				{
					break;
				}
			}
			Writer.Write(byte_0, offset, num2);
			return flag;
		}

		protected override void OnDisposed()
		{
			readObjectInfo_0 = null;
			class3_0 = null;
			base.OnDisposed();
		}

		public override IMessage MessageRead(IDataReader reader)
		{
			IMessage message = ReadMessageByType(reader, readObjectInfo_0);
			if (message == null)
			{
				throw NetTcpException.TypeNotFound(readObjectInfo_0.ToString());
			}
			try
			{
				message.Load(reader);
				return message;
			}
			catch (Exception innerexception)
			{
				NetTcpException ex = NetTcpException.ObjectLoadError(readObjectInfo_0.ToString(), innerexception);
				throw ex;
			}
		}

		protected abstract IMessage ReadMessageByType(IDataReader reader, ReadObjectInfo typeTag);

		protected abstract void WriteMessageType(IMessage imessage_0, IDataWriter writer);

		public override void MessageWrite(IMessage imessage_0, IDataWriter writer)
		{
			WriteMessageType(imessage_0, writer);
			imessage_0.Save(writer);
			writer.Write(EofData, 0, EofData.Length);
		}
	}
}
