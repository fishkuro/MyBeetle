using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Beetle
{
	public class ChannelDisposedEventArgs : ChannelEventArgs
	{
		internal int int_0;

		[CompilerGenerated]
		private int int_1;

		[CompilerGenerated]
		private Queue<IMessage> queue_0;

		[CompilerGenerated]
		private bool bool_0;

		public int Delay
		{
			[CompilerGenerated]
			get
			{
				return int_1;
			}
			[CompilerGenerated]
			set
			{
				int_1 = value;
			}
		}

		public Queue<IMessage> Message
		{
			[CompilerGenerated]
			get
			{
				return queue_0;
			}
			[CompilerGenerated]
			internal set
			{
				queue_0 = value;
			}
		}

		public bool Clean
		{
			[CompilerGenerated]
			get
			{
				return bool_0;
			}
			[CompilerGenerated]
			set
			{
				bool_0 = value;
			}
		}

		public ChannelDisposedEventArgs()
		{
			Clean = true;
			Delay = 50;
		}
	}
}
