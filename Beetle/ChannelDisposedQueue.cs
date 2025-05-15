using System;
using System.Collections.Generic;

namespace Beetle
{
	public class ChannelDisposedQueue : Task
	{
		private Queue<ChannelDisposedEventArgs> queue_0 = new Queue<ChannelDisposedEventArgs>(1024);

		private static ChannelDisposedQueue channelDisposedQueue_0 = new ChannelDisposedQueue();

		public static ChannelDisposedQueue DisposedQueue
		{
			get
			{
				return channelDisposedQueue_0;
			}
		}

		public void Add(ChannelDisposedEventArgs channel)
		{
			lock (queue_0)
			{
				queue_0.Enqueue(channel);
			}
		}

		private void method_3()
		{
			lock (queue_0)
			{
				if (queue_0.Count > 0)
				{
					queue_0.Dequeue();
				}
			}
		}

		private ChannelDisposedEventArgs method_4()
		{
			lock (queue_0)
			{
				if (queue_0.Count > 0)
				{
					return queue_0.Peek();
				}
				return null;
			}
		}

		protected override void Execute()
		{
			ChannelDisposedEventArgs channelDisposedEventArgs = method_4();
			while (channelDisposedEventArgs != null && Environment.TickCount - channelDisposedEventArgs.int_0 > channelDisposedEventArgs.Delay)
			{
				((Class40)channelDisposedEventArgs.Channel).method_16();
				channelDisposedEventArgs.Channel = null;
				method_3();
				channelDisposedEventArgs = method_4();
			}
		}
	}
}
