using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;

namespace Beetle.Clients
{
	public class SyncPool
	{
		private class Class4
		{
			public int int_0;
		}

		[ThreadStatic]
		private static Class4 class4_0;

		private List<SyncNode> list_0 = new List<SyncNode>();

		[ThreadStatic]
		private static int int_0 = 0;

		public IList<SyncNode> Nodes
		{
			get
			{
				return list_0;
			}
		}

		public SyncPool()
		{
		}

		public SyncPool(string section)
		{
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
				AddNode(server.Name, server.Host, server.Port, server.MaxConnections, server.DetectTime, server.Group, server.TimeOut);
			}
		}

		public void AddNode(string name, string host, int port, int maxconnections)
		{
			AddNode(name, host, port, maxconnections, 5, null);
		}

		public void AddNode(string name, string host, int port, int maxconnections, int detectTime, string groupname, int timeout = 0)
		{
			SyncNode syncNode = new SyncNode(host, port, maxconnections);
			syncNode.Name = name;
			syncNode.DetectTime = detectTime;
			syncNode.GroupName = groupname;
			syncNode.TimeOut = timeout;
			Nodes.Add(syncNode);
		}

		public void Connect<T>() where T : ISyncChannel, new()
		{
			List<string> list = new List<string>();
			foreach (SyncNode node in Nodes)
			{
				list.Clear();
				foreach (SyncNode node2 in Nodes)
				{
					if (node != node2 && node.GroupName == node2.GroupName)
					{
						list.Add(node2.GroupName);
					}
				}
				node.GroupNodes = list.ToArray();
				node.Connect<T>();
			}
			Thread.Sleep(500);
		}

		public virtual SyncNode GetNode(params string[] nodes)
		{
			SyncNode syncNode = null;
			for (int i = 0; i < nodes.Length; i++)
			{
				int_0++;
				if (int_0 >= nodes.Length)
				{
					int_0 = 0;
				}
				for (int j = 0; j < Nodes.Count; j++)
				{
					syncNode = Nodes[j];
					if (nodes[int_0] == syncNode.Name && syncNode.Available)
					{
						return syncNode;
					}
				}
			}
			return null;
		}

		public virtual SyncNode GetNode()
		{
			if (class4_0 == null)
			{
				class4_0 = new Class4();
			}
			if (list_0.Count == 0)
			{
				return null;
			}
			int num = 0;
			SyncNode syncNode;
			while (true)
			{
				if (num <= list_0.Count)
				{
					class4_0.int_0++;
					if (class4_0.int_0 >= list_0.Count)
					{
						class4_0.int_0 = 0;
					}
					syncNode = list_0[class4_0.int_0];
					if (syncNode.Available)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return syncNode;
		}

		public object Send(object message, params string[] nodes)
		{
			return OnSend(message, nodes);
		}

		public RESULT Send<RESULT>(object message, params string[] nodes)
		{
			return (RESULT)OnSend(message, nodes);
		}

		public object Send(object message)
		{
			return OnSend(message);
		}

		public RESULT Send<RESULT>(object message)
		{
			return (RESULT)OnSend(message);
		}

		protected virtual object OnSend(object message, params string[] nodes)
		{
			SyncNode node = GetNode(nodes);
			if (node == null || !node.Available)
			{
				throw NetTcpException.ConnectionIsNotAvailable();
			}
			return node.Send(message);
		}

		protected virtual object OnSend(object message)
		{
			SyncNode node = GetNode();
			if (node == null || !node.Available)
			{
				throw NetTcpException.ConnectionIsNotAvailable();
			}
			return node.Send(message);
		}
	}
}
