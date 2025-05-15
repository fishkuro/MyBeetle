using System;
using System.Runtime.CompilerServices;

namespace Beetle
{
	public class ChannelErrorEventArgs : ChannelEventArgs
	{
		[CompilerGenerated]
		private Exception exception_0;

		public Exception Exception
		{
			[CompilerGenerated]
			get
			{
				return exception_0;
			}
			[CompilerGenerated]
			set
			{
				exception_0 = value;
			}
		}
	}
}
