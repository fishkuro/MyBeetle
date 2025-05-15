using System.Runtime.CompilerServices;

namespace Beetle
{
	public class ObjectArraySegment<T>
	{
		[CompilerGenerated]
		private T[] gparam_0;

		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private int int_1;

		public T[] Array
		{
			[CompilerGenerated]
			get
			{
				return gparam_0;
			}
			[CompilerGenerated]
			internal set
			{
				gparam_0 = value;
			}
		}

		public int Offset
		{
			[CompilerGenerated]
			get
			{
				return int_0;
			}
			[CompilerGenerated]
			internal set
			{
				int_0 = value;
			}
		}

		public int Count
		{
			[CompilerGenerated]
			get
			{
				return int_1;
			}
			[CompilerGenerated]
			internal set
			{
				int_1 = value;
			}
		}

		public ObjectArraySegment()
		{
		}

		public ObjectArraySegment(int count)
		{
			Array = new T[count];
		}

		public void SetArray(T[] data, int offset, int count)
		{
			Array = data;
			Offset = offset;
			Count = count;
		}

		public void SetArray(int offset, int count)
		{
			Offset = offset;
			Count = count;
		}
	}
}
