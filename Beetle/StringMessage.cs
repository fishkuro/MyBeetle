namespace Beetle
{
	public class StringMessage : IMessage
	{
		public string Value;

		public void Save(IDataWriter writer)
		{
			long length = writer.Length;
			writer.WriteString(Value);
		}

		public void Load(IDataReader reader)
		{
			Value = reader.ReadString((int)reader.Length);
		}
	}
}
