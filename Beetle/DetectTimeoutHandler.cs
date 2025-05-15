using System;
using System.Runtime.CompilerServices;

namespace Beetle
{
	public class DetectTimeoutHandler : Task
	{
		private OnlineSegment onlineSegment_0 = new OnlineSegment(TcpUtils.Connections * 2);

		[CompilerGenerated]
		private TcpServer tcpServer_0;

		public TcpServer Server
		{
			[CompilerGenerated]
			get
			{
				return tcpServer_0;
			}
			[CompilerGenerated]
			internal set
			{
				tcpServer_0 = value;
			}
		}

		protected override void Execute()
		{
			if (Server != null && Server.IsRunning)
			{
				int tickCount = Environment.TickCount;
				Server.GetOnlines(onlineSegment_0);
				for (int i = 0; i < onlineSegment_0.Count; i++)
				{
					if (tickCount - onlineSegment_0.Channels[i].TickCount >= TcpUtils.TimeOutms)
					{
						((Class40)onlineSegment_0.Channels[i]).string_2 = "Request Timeout!";
						onlineSegment_0.Channels[i].Dispose();
					}
				}
			}
			else
			{
				Dispose();
			}
		}
	}
}
