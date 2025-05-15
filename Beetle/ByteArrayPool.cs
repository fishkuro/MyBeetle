using System.Collections.Generic;

namespace Beetle
{
	public class ByteArrayPool
	{
		private Stack<ByteArraySegment> stack_0 = new Stack<ByteArraySegment>();

		private int int_0;

		public int Count
		{
			get
			{
				return stack_0.Count;
			}
		}

		public ByteArrayPool(int initcount, int length)
		{
			int_0 = length;
			for (int i = 0; i < initcount; i++)
			{
				stack_0.Push(method_0());
			}
		}

		private ByteArraySegment method_0()
		{
			return new ByteArraySegment(int_0);
		}

		public ByteArraySegment Pop()
		{
			lock (this)
			{
				if (stack_0.Count > 0)
				{
					return stack_0.Pop();
				}
				return method_0();
			}
		}

		public void Push(ByteArraySegment item)
		{
			lock (this)
			{
				item.SetInfo(0, 0);
				item.SetPostion(0);
				stack_0.Push(item);
			}
		}
	}
}
