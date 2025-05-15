namespace Beetle
{
	public interface IMessage
	{
		void Save(IDataWriter writer);

		void Load(IDataReader reader);
	}
}
