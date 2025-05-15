using System;
using System.Collections.Generic;

namespace Beetle
{
	public interface IDataReader
	{
		IChannel Channel { get; set; }

		bool LittleEndian { get; set; }

		long Position { get; set; }

		long Length { get; }

		int ReadByte();

		void Read(ByteArraySegment sagment);

		bool ReadBool();

		short ReadShort();

		int ReadInt();

		long ReadLong();

		ushort ReadUShort();

		uint ReadUInt();

		ulong ReadULong();

		char ReadChar();

		DateTime ReadDateTime();

		float ReadFloat();

		double ReadDouble();

		void Read(IMessage imessage_0);

		T ReadMessage<T>() where T : IMessage, new();

		IList<T> ReadMessages<T>() where T : IMessage, new();

		string ReadString(int length);

		string ReadString();

		string ReadUTF();

		int Read(byte[] buffer, int offset, int count);

		void Reset();
	}
}
