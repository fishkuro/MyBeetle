using System;
using System.Runtime.CompilerServices;

namespace Beetle
{
	public class EventCallBackHandlerArgs<T> : EventArgs
	{
		[CompilerGenerated]
		private IChannel ichannel_0;

		[CompilerGenerated]
		private T gparam_0;

		[CompilerGenerated]
		private object object_0;

		public IChannel Channel
		{
			[CompilerGenerated]
			get
			{
				return ichannel_0;
			}
			[CompilerGenerated]
			private set
			{
				ichannel_0 = value;
			}
		}

		public T Message
		{
			[CompilerGenerated]
			get
			{
				return gparam_0;
			}
			[CompilerGenerated]
			private set
			{
				gparam_0 = value;
			}
		}

		public object UserToken
		{
			[CompilerGenerated]
			get
			{
				return object_0;
			}
			[CompilerGenerated]
			private set
			{
				object_0 = value;
			}
		}

		public EventCallBackHandlerArgs(IChannel channel, object message, object userToken)
		{
			Channel = channel;
			Message = (T)message;
			UserToken = userToken;
		}
	}
}
