using System.Collections.Generic;

namespace Beetle
{
	public class SendMessageCompletedArgs : ChannelEventArgs
	{
		public bool Success;

		public IList<IMessage> Messages = new List<IMessage>();
	}
}
