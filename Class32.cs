using Beetle;

internal abstract class Class32 : IMessage, IObjectReset
{
	public abstract void Reset();

	public abstract void Save(IDataWriter writer);

	public abstract void Load(IDataReader reader);
}
