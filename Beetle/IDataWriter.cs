using System;
using System.Collections.Generic;

namespace Beetle
{
	public interface IDataWriter
	{
		IChannel Channel { get; set; }

		bool LittleEndian { get; set; }

		long Position { get; set; }

		long Length { get; }

		void Write(bool value);

		void Write(byte value);

		void Write(short value);

		void Write(int value);

		void Write(long value);

		void Write(ushort value);

		void Write(uint value);

		void Write(ulong value);

		void Write(DateTime value);

		void Write(char value);

		void Write(float value);

		void Write(double value);

		void Write(IMessage message);

		void Write<T>(IList<T> value) where T : IMessage;

		void WriteString(string value);

		void WriteUTF(string value);

		void Write(string value);

		void Write(ByteArraySegment sagment);

		void Write(byte[] buffer, int offset, int count);

		void Reset();
	}
}
