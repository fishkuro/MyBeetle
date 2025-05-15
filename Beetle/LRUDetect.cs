using System;
using System.Collections.Generic;
using System.Threading;

namespace Beetle
{
	public class LRUDetect : IDisposable
	{
		public interface IConnecton
		{
			LinkedListNode<Node> Node { get; set; }

			void TimeOut();
		}

		public class Node
		{
			public int LastActiveTime;

			public IConnecton Connection;

			public bool Detect(int cutime, int timeout)
			{
				return Math.Abs(cutime - LastActiveTime) > timeout;
			}
		}

		private int int_0;

		private Timer timer_0;

		private LinkedList<Node> linkedList_0 = new LinkedList<Node>();

		public LRUDetect(int timeout)
		{
			int_0 = timeout;
			timer_0 = new Timer(method_0, null, int_0, int_0);
		}

		public void Update(IConnecton connection)
		{
			lock (this)
			{
				LinkedListNode<Node> node = connection.Node;
				if (node != null)
				{
					node.Value.LastActiveTime = Environment.TickCount;
					linkedList_0.Remove(node);
					linkedList_0.AddFirst(node);
				}
				else
				{
					node = linkedList_0.AddFirst(new Node());
					node.Value.LastActiveTime = Environment.TickCount;
					node.Value.Connection = connection;
					connection.Node = node;
				}
			}
		}

		public void Delete(IConnecton connection)
		{
			lock (this)
			{
				LinkedListNode<Node> node = connection.Node;
				if (node != null)
				{
					node.Value.Connection = null;
					linkedList_0.Remove(node);
				}
			}
		}

		private void method_0(object object_0)
		{
			lock (this)
			{
				int tickCount = Environment.TickCount;
				LinkedListNode<Node> last = linkedList_0.Last;
				while (last != null && last.Value.Detect(tickCount, int_0))
				{
					last.Value.Connection.TimeOut();
					last.Value.Connection = null;
					linkedList_0.RemoveLast();
					last = linkedList_0.Last;
				}
			}
		}

		public void Dispose()
		{
			if (timer_0 != null)
			{
				timer_0.Dispose();
				linkedList_0.Clear();
			}
		}
	}
}
