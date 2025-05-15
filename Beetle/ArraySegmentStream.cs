using System;
using System.IO;

namespace Beetle
{
	public class ArraySegmentStream : Stream
	{
		private byte[] byte_0;

		private int int_0;

		private int int_1;

		private int int_2;

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
				return true;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return true;
			}
		}

		public override long Length
		{
			get
			{
				return int_2;
			}
		}

		public override long Position
		{
			get
			{
				return int_1;
			}
			set
			{
				int_1 = (int)value;
			}
		}

		public ArraySegmentStream(byte[] data)
		{
			byte_0 = data;
			int_2 = 0;
			int_1 = 0;
			int_0 = 0;
		}

		public override void Flush()
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int num = int_2 - int_1;
			if (num > count)
			{
				num = count;
			}
			if (num <= 0)
			{
				return 0;
			}
			if (num <= 8)
			{
				int num2 = num;
				while (--num2 >= 0)
				{
					buffer[offset + num2] = byte_0[int_1 + num2];
				}
			}
			else
			{
				Buffer.BlockCopy(byte_0, int_1, buffer, offset, num);
			}
			int_1 += num;
			return num;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			switch (origin)
			{
			case SeekOrigin.Begin:
			{
				int num2 = (int_1 = int_0 + (int)offset);
				break;
			}
			case SeekOrigin.Current:
				int_1 += (int)offset;
				break;
			case SeekOrigin.End:
			{
				int num = (int_1 = int_2 + (int)offset);
				break;
			}
			}
			return int_1;
		}

		public override void SetLength(long value)
		{
			int num = (int_2 = int_0 + (int)value);
			if (int_1 > num)
			{
				int_1 = num;
			}
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			int num = int_1 + count;
			if (num > int_2)
			{
				int_2 = num;
			}
			if (count <= 8 && buffer != byte_0)
			{
				int num2 = count;
				while (--num2 >= 0)
				{
					byte_0[int_1 + num2] = buffer[offset + num2];
				}
			}
			else
			{
				Buffer.BlockCopy(buffer, offset, byte_0, int_1, count);
			}
			int_1 = num;
		}
	}
}
