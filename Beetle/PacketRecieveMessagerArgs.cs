namespace Beetle
{
	public class PacketRecieveMessagerArgs
	{
		public object TypeTag;

		public IChannel Channel;

		public object Message;

		public PacketRecieveMessagerArgs(IChannel channel, IMessage imessage_0)
		{
			Channel = channel;
			Message = imessage_0;
		}
	}
}
