using System;
using System.Runtime.CompilerServices;
using Beetle;

internal abstract class BeetleMessageBase : Package
{
	private ReadObjectInfo readObjectInfo_0 = new ReadObjectInfo();

	private int int_0;

	private bool bool_3 = true;

	public BeetleMessageBase()
	{
	}

	public BeetleMessageBase(ConnectionSessionStore class40_0)
		: base(class40_0)
	{
	}

	protected abstract IMessage vmethod_0(IDataReader idataReader_0, ReadObjectInfo readObjectInfo_1);

	protected abstract void vmethod_1(IMessage imessage_0, IDataWriter idataWriter_1);

	[SpecialName]
	protected abstract byte[] vmethod_2();

	public override void MessageWrite(IMessage imessage_0, IDataWriter writer)
	{
		vmethod_1(imessage_0, writer);
		imessage_0.Save(writer);
		writer.Write(vmethod_2(), 0, vmethod_2().Length);
	}

	public override IMessage MessageRead(IDataReader reader)
	{
		IMessage message = vmethod_0(reader, readObjectInfo_0);
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

	public override void Import(byte[] data, int start, int count)
	{
		int num = start + count;
		while (true)
		{
			if (count <= 0)
			{
				return;
			}
			if (bool_3)
			{
				((MessageStream)Writer).Reset();
				bool_3 = false;
			}
			if (int_0 == 0)
			{
				int num2 = 0;
				if (Writer.Length + count > TcpUtils.DataPacketMaxLength)
				{
					break;
				}
				Writer.Write(data, start, count);
				start = num2 + 1;
				count = num - start;
				OnMessageDataReader(Writer);
				int_0 = 0;
				bool_3 = true;
				continue;
			}
			bool flag = true;
			int num3 = vmethod_2().Length - int_0;
			for (int i = int_0; i < vmethod_2().Length; i++)
			{
				if (data[i - int_0] != vmethod_2()[i])
				{
					flag = false;
				}
			}
			if (flag)
			{
				Writer.Write(data, start, num3);
				start += num3;
				count = num - start;
				OnMessageDataReader(Writer);
				bool_3 = true;
			}
			int_0 = 0;
		}
		throw NetTcpException.DataOverflow();
	}
}
