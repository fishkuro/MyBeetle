using System;
using System.Collections.Generic;
using System.Configuration;

namespace Beetle.Clients
{
	public class AsnyPool<T> where T : Package
	{
		private class NodeIndex
		{
			public int int_0;
		}

		private EventPacketRecievMessage eventPacketRecievMessage_0;

		private EventChannelError eventChannelError_0;

		private Action<IChannel> action_0;

		private List<AsynNode<T>> list_0 = new List<AsynNode<T>>();

		[ThreadStatic]
		private static NodeIndex nodeIndex_0;

		[ThreadStatic]
		private static int int_0 = 0;

		public IList<AsynNode<T>> Nodes
		{
			get
			{
				return list_0;
			}
		}

		public AsnyPool(EventPacketRecievMessage receive, EventChannelError error, Action<IChannel> channelCreated)
		{
			eventPacketRecievMessage_0 = receive;
			eventChannelError_0 = error;
			action_0 = channelCreated;
		}

		public AsnyPool(string section, EventPacketRecievMessage receive, EventChannelError error, Action<IChannel> channelCreated)
		{
			eventPacketRecievMessage_0 = receive;
			eventChannelError_0 = error;
			PoolSection poolSection = (PoolSection)ConfigurationManager.GetSection(section);
			if (poolSection == null)
			{
				throw NetTcpException.ClientPoolSectionNotFound(section);
			}
			if (section == null)
			{
				return;
			}
			foreach (ServerNode server in poolSection.Servers)
			{
				AddNode(server.Name, server.Host, server.Port, server.MaxConnections, server.DetectTime, server.Group);
			}
		}

		public void Connect()
		{
			List<string> list = new List<string>();
			foreach (AsynNode<T> node in Nodes)
			{
				list.Clear();
				foreach (AsynNode<T> node2 in Nodes)
				{
					if (node != node2 && node.GroupName == node2.GroupName)
					{
						list.Add(node2.GroupName);
					}
				}
				node.GroupNodes = list.ToArray();
				node.Connect();
			}
		}

		public void AddNode(string name, string host, int port, int maxconnections)
		{
			AddNode(name, host, port, maxconnections, 30, null);
		}

		public void AddNode(string name, string host, int port, int maxconnections, int detectTime, string groupName)
		{
			AsynNode<T> asynNode = new AsynNode<T>(host, port, maxconnections, eventPacketRecievMessage_0, eventChannelError_0, action_0);
			asynNode.Name = name;
			asynNode.DetectTime = detectTime;
			asynNode.GroupName = groupName;
			Nodes.Add(asynNode);
		}

		public bool Send(object message)
		{
			AsynNode<T> node = GetNode();
			if (node == null || !node.Available)
			{
				throw NetTcpException.ConnectionIsNotAvailable();
			}
			return node.Send(message);
		}

		public bool Send(object message, params string[] nodes)
		{
			AsynNode<T> node = GetNode(nodes);
			if (node == null || !node.Available)
			{
				throw NetTcpException.ConnectionIsNotAvailable();
			}
			return node.Send(message);
		}

		public virtual AsynNode<T> GetNode(params string[] nodes)
		{
			AsynNode<T> asynNode = null;
			int num = 0;
			while (num < nodes.Length)
			{
				int_0++;
				if (int_0 >= nodes.Length)
				{
					int_0 = 0;
				}
				for (int i = 0; i < Nodes.Count; i++)
				{
					asynNode = Nodes[i];
					if (nodes[int_0] == asynNode.Name && asynNode.Available)
					{
						return asynNode;
					}
				}
			}
			return null;
		}

		public virtual AsynNode<T> GetNode()
		{
			if (nodeIndex_0 == null)
			{
				nodeIndex_0 = new NodeIndex();
			}
			if (list_0.Count == 0)
			{
				return null;
			}
			int num = 0;
			AsynNode<T> asynNode = null;
			while (true)
			{
				if (num <= list_0.Count)
				{
					nodeIndex_0.int_0++;
					if (nodeIndex_0.int_0 >= list_0.Count)
					{
						nodeIndex_0.int_0 = 0;
					}
					asynNode = list_0[nodeIndex_0.int_0];
					if (asynNode.Available)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return asynNode;
		}
	}
}
