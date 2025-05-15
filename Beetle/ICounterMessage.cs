namespace Beetle
{
	public interface ICounterMessage : IMessage
	{
		void SetCount(int count);

		void Decrement();
	}
}
