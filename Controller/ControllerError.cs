using System.Runtime.CompilerServices;

namespace Beetle.Controller
{
	public class ControllerError : ChannelErrorEventArgs
	{
		[CompilerGenerated]
		private object object_0;

		public object Message
		{
			[CompilerGenerated]
			get
			{
				return object_0;
			}
			[CompilerGenerated]
			set
			{
				object_0 = value;
			}
		}
	}
}
