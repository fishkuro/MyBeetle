namespace Beetle
{
	public class WriteBlock
	{
		public bool LittleEndian = true;

		public ByteArraySegment[] ArraySegments;

		private byte[] byte_0 = new byte[8];

		public int Count;

		public WriteBlock()
		{
			ArraySegments = new ByteArraySegment[8];
			for (int i = 0; i < 8; i++)
			{
				ArraySegments[i] = new ByteArraySegment();
			}
		}

		public void Add(byte[] data, int offset, int count)
		{
			ArraySegments[Count].SetInfo(data, offset, count);
			count++;
		}

		public unsafe void SetData(short value)
		{
			if (!LittleEndian)
			{
				value = Class11.smethod_0(value);
			}
			fixed (byte* ptr = &byte_0[0])
			{
				*(short*)ptr = value;
			}
			SetData(byte_0, 0, 2);
		}

		public unsafe void SetData(int value)
		{
			if (!LittleEndian)
			{
				value = Class11.smethod_2(value);
			}
			fixed (byte* ptr = &byte_0[0])
			{
				*(int*)ptr = value;
			}
			SetData(byte_0, 0, 4);
		}

		public unsafe void SetData(long value)
		{
			if (!LittleEndian)
			{
				value = Class11.smethod_4(value);
			}
			fixed (byte* ptr = &byte_0[0])
			{
				*(long*)ptr = value;
			}
			SetData(byte_0, 0, 8);
		}

		public void SetData(byte[] data, int offset, int count)
		{
			int num = offset;
			for (int i = 0; i < count; i++)
			{
				ByteArraySegment byteArraySegment = ArraySegments[i];
				byte[] array = byteArraySegment.Array;
				int offset2 = byteArraySegment.Offset;
				int num2 = byteArraySegment.Offset + byteArraySegment.Count;
				for (int j = offset2; j < num2; j++)
				{
					array[j] = data[num];
					num++;
					count--;
					if (count == 0)
					{
						return;
					}
				}
			}
		}

		public void Reset()
		{
			Count = 0;
		}
	}
}
