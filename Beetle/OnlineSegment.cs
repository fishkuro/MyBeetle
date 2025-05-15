using System.Runtime.CompilerServices;

namespace Beetle
{
	public class OnlineSegment
	{
		[CompilerGenerated]
		private IChannel[] ichannel_0;

		[CompilerGenerated]
		private long long_0;

		[CompilerGenerated]
		private int int_0;

		public IChannel[] Channels
		{
			[CompilerGenerated]
			get
			{
				return ichannel_0;
			}
			[CompilerGenerated]
			internal set
			{
				ichannel_0 = value;
			}
		}

		public long OnlineVersion
		{
			[CompilerGenerated]
			get
			{
				return long_0;
			}
			[CompilerGenerated]
			internal set
			{
				long_0 = value;
			}
		}

		public int Count
		{
			[CompilerGenerated]
			get
			{
				return int_0;
			}
			[CompilerGenerated]
			internal set
			{
				int_0 = value;
			}
		}

		public OnlineSegment(int count)
		{
			Channels = new IChannel[count];
		}
	}
}
