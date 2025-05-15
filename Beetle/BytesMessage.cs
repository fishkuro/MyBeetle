namespace Beetle
{
	public class BytesMessage : IMessage
	{
		public byte[] Value;

		public void Save(IDataWriter writer)
		{
			writer.Write(Value, 0, Value.Length);
		}

		public void Load(IDataReader reader)
		{
			Value = new byte[reader.Length - reader.Position];
			reader.Read(Value, 0, Value.Length);
		}
	}
}
