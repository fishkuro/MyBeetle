using System.Threading;

namespace Beetle
{
	public abstract class CounterMessage : ICounterMessage
	{
		private int int_0;

		public void SetCount(int count)
		{
			int_0 = count;
		}

		public void Decrement()
		{
			if (Interlocked.Decrement(ref int_0) == 0)
			{
				Recover();
			}
		}

		protected abstract void Recover();

		public abstract void Save(IDataWriter writer);

		public abstract void Load(IDataReader reader);
	}
}
