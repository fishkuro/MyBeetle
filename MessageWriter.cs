using System;
using Beetle;

internal abstract class MessageWriter : Package
{
	private ReadObjectInfo readObjectInfo_0 = new ReadObjectInfo();

	private int int_0;

	private byte[] byte_0 = new byte[4];

	private int int_1;

	private int int_2;

	protected WriteBlock writeBlock_0 = new WriteBlock();

	public MessageWriter()
	{
	}

	public MessageWriter(ConnectionSessionStore class40_0)
		: base(class40_0)
	{
	}

	protected abstract IMessage vmethod_0(IDataReader idataReader_0, ReadObjectInfo readObjectInfo_1);

	protected abstract void vmethod_1(IMessage imessage_0, IDataWriter idataWriter_1);

	public override void Import(byte[] data, int start, int count)
	{
		int_2 = count;
		while (true)
		{
			if (int_2 <= 0)
			{
				return;
			}
			if (int_0 == 0)
			{
				if (int_2 < 4)
				{
					break;
				}
				Writer.Reset();
				if (int_1 == 0)
				{
					int_0 = BitConverter.ToInt32(data, start);
					if (int_0 > TcpUtils.DataPacketMaxLength || int_0 <= 0)
					{
						throw NetTcpException.DataOverflow();
					}
					Writer.Write(data, start, 4);
					start += 4;
					int_0 -= 4;
					int_2 -= 4;
				}
				else
				{
					int num = 4 - int_1;
					Buffer.BlockCopy(data, start, byte_0, int_1, num);
					int_1 = 0;
					int_0 = BitConverter.ToInt32(byte_0, 0);
					if (int_0 > TcpUtils.DataPacketMaxLength || int_0 <= 0)
					{
						throw NetTcpException.DataOverflow();
					}
					Writer.Write(byte_0, 0, 4);
					start += num;
					int_0 -= 4;
					int_2 -= num;
				}
			}
			if (int_2 >= int_0)
			{
				Writer.Write(data, start, int_0);
				OnMessageDataReader(Writer);
				start += int_0;
				int_2 -= int_0;
				int_0 = 0;
			}
			else
			{
				Writer.Write(data, start, int_2);
				int_0 -= int_2;
				int_2 = 0;
			}
		}
		int_1 = int_2;
		Buffer.BlockCopy(data, start, byte_0, 0, int_2);
		int_2 = 0;
	}

	public override void MessageWrite(IMessage imessage_0, IDataWriter writer)
	{
		long length = writer.Length;
		WriteBlock writeBlock = ((MessageStream)writer).WriteResultBlock(new byte[4], 0, 4, writeBlock_0);
		vmethod_1(imessage_0, writer);
		imessage_0.Save(writer);
		writeBlock.SetData(new byte[4], 0, 4);
	}

	public override IMessage MessageRead(IDataReader reader)
	{
		IMessage message = null;
		message = vmethod_0(reader, readObjectInfo_0);
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

	protected override void OnDisposed()
	{
		base.OnDisposed();
	}
}
