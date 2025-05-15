using System;
using System.Runtime.CompilerServices;

namespace Beetle
{
	public class TcpServerErrorArgs : EventArgs
	{
		[CompilerGenerated]
		private Exception exception_0;

		public Exception Error
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
