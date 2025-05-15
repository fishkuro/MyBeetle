using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography;
using System.Threading;

namespace Beetle
{
	public class TcpUtils
	{
		internal static bool bool_0;

		private static SocketBufferSegment class8_0;

		internal static object object_0;

		internal static object object_1;

		internal static ProtocolHeaderParser class41_0;

		internal static ClientTokenSession class7_0;

		internal static ClientTokenSession class7_1;

		private static IList<SocketAsyncControl> ilist_0;

		private static IList<SocketAsyncControl> ilist_1;

		private static IList<SocketAsyncControl> ilist_2;

		public static int SocketDespatchSleepTime;

		public static int WorkDespatchSleepTime;

		public static bool Statistics;

		public static long SendBytes;

		public static long ReceiveBytes;

		public static long SendDataIO;

		public static long ReceiveDataIO;

		public static bool EnabledReceiveQueue;

		public static bool EnabledSendQueue;

		public static bool EnabledWorkQueue;

		public static int ChannelMaxQueueData;

		public static int DataPacketMaxLength;

		public static int SendPacketSpacing;

		public static int SendMessageSpacing;

		public static int SendBufferLength;

		public static int ReceiveBufferLength;

		public static int Connections;

		public static int StringEncodingLength;

		public static bool UseStringEncoding;

		public static int TimeOutms;

		public static bool ExecutionContext;

		public static int BufferPoolSize;

		public static long ReceiveMessages;

		public static long SendMessages;

		internal static int int_0;

		private static int int_1;

		private static int int_2;

		private static int int_3;

		[ThreadStatic]
		private static bool bool_1;

		internal static string smethod_0()
		{
			return AppDomain.CurrentDomain.BaseDirectory;
		}

		static TcpUtils()
		{
			bool_0 = false;
			class8_0 = new SocketBufferSegment();
			object_0 = new object();
			object_1 = new object();
			ilist_0 = new List<SocketAsyncControl>();
			ilist_1 = new List<SocketAsyncControl>();
			ilist_2 = new List<SocketAsyncControl>();
			SocketDespatchSleepTime = 10;
			WorkDespatchSleepTime = 10;
			EnabledReceiveQueue = true;
			EnabledSendQueue = true;
			EnabledWorkQueue = true;
			ChannelMaxQueueData = 0;
			int_1 = 0;
			int_2 = 0;
			int_3 = 0;
			bool_1 = false;
			DataPacketMaxLength = 8204;
			SendBufferLength = 2048;
			ReceiveBufferLength = 2048;
			int_0 = 1;
			Connections = 1000;
			EnabledReceiveQueue = true;
			Statistics = false;
			SendPacketSpacing = 0;
			SendMessageSpacing = 0;
			StringEncodingLength = 512;
			UseStringEncoding = true;
			BufferPoolSize = 1000;
			ExecutionContext = false;
			TimeOutms = 30000;
			smethod_1();
		}

		private static void smethod_1()
		{
		}

		public static void Setup(string configname)
		{
			ConfigSection configSection = (ConfigSection)ConfigurationManager.GetSection(configname);
			if (configSection == null)
			{
				throw NetTcpException.ConfigSelectionNotFound(configname);
			}
			Statistics = configSection.Statistics;
			SocketDespatchSleepTime = configSection.SocketThreadSleep;
			WorkDespatchSleepTime = configSection.WorkThreadSleep;
			StringEncodingLength = configSection.StringEncodingSize;
			ReceiveBufferLength = configSection.ReceiveBufferSize;
			SendBufferLength = configSection.SendBufferSize;
			DataPacketMaxLength = configSection.PackageMaxSize;
			TimeOutms = configSection.TimeOut;
			ChannelMaxQueueData = configSection.ChannelMaxQueueData;
			ExecutionContext = configSection.ExecutionContext;
			EnabledReceiveQueue = configSection.EnabledReceiveQueue;
			EnabledSendQueue = configSection.EnabledSendQueue;
			EnabledWorkQueue = configSection.EnabledWorkQueue;
			Setup(configSection.Connections, configSection.Pools, configSection.SocketSendThreads, configSection.SocketReceiveThreads, configSection.WorkThreads);
		}

		public static void Setup(int maxconnections, int bufferpools, int senddespatchs, int receivedespatch, int workdespatchs)
		{
			Clean();
			Connections = maxconnections;
			class41_0 = new ProtocolHeaderParser(Connections, ReceiveBufferLength);
			smethod_2(Connections);
			for (int i = 0; i < senddespatchs; i++)
			{
				SocketAsyncControl @class = new SocketAsyncControl();
				@class.int_0 = SocketDespatchSleepTime;
				ilist_0.Add(@class);
			}
			for (int j = 0; j < receivedespatch; j++)
			{
				SocketAsyncControl @class = new SocketAsyncControl();
				@class.int_0 = SocketDespatchSleepTime;
				ilist_1.Add(@class);
			}
			for (int k = 0; k < workdespatchs; k++)
			{
				SocketAsyncControl @class = new SocketAsyncControl();
				@class.int_0 = WorkDespatchSleepTime;
				ilist_2.Add(@class);
			}
			bool_0 = true;
		}

		private static void smethod_2(int int_4)
		{
			if (class7_1 != null)
			{
				class7_1.method_4();
			}
			if (class7_0 != null)
			{
				class7_0.method_4();
			}
			class7_1 = new ClientTokenSession(int_4, SendBufferLength);
			class7_0 = new ClientTokenSession(int_4, ReceiveBufferLength);
		}

		public static void Setup(int maxconnections, int bufferpools, int despatchs)
		{
			Setup(maxconnections, bufferpools, despatchs, despatchs, despatchs);
		}

		public static void Clean()
		{
			if (class41_0 != null)
			{
				class41_0.Dispose();
			}
			smethod_3();
			ilist_1.Clear();
			ilist_0.Clear();
			ilist_2.Clear();
			bool_0 = false;
		}

		private static void smethod_3()
		{
			foreach (SocketAsyncControl item in ilist_0)
			{
				item.Dispose();
			}
			foreach (SocketAsyncControl item2 in ilist_1)
			{
				item2.Dispose();
			}
			foreach (SocketAsyncControl item3 in ilist_2)
			{
				item3.Dispose();
			}
		}

		internal static SocketAsyncControl smethod_4()
		{
			lock (ilist_0)
			{
				int_1++;
				if (int_1 >= ilist_0.Count)
				{
					int_1 = 0;
				}
				return ilist_0[int_1];
			}
		}

		internal static SocketAsyncControl smethod_5()
		{
			lock (ilist_1)
			{
				int_2++;
				if (int_2 >= ilist_1.Count)
				{
					int_2 = 0;
				}
				return ilist_1[int_2];
			}
		}

		public static int GetAsyncEventPoolStatus()
		{
			return class41_0.method_0();
		}

		public static IList<int> GetSendDespatchStatus()
		{
			List<int> list = new List<int>();
			foreach (SocketAsyncControl item in ilist_0)
			{
				list.Add(item.method_2());
			}
			return list;
		}

		public static IList<int> GetReceiveDespatchStatus()
		{
			List<int> list = new List<int>();
			foreach (SocketAsyncControl item in ilist_1)
			{
				list.Add(item.method_2());
			}
			return list;
		}

		public static IList<int> GetWorkDespatchsStatus()
		{
			IList<int> list = new List<int>();
			if (ilist_2 != null)
			{
				for (int i = 0; i < ilist_2.Count; i++)
				{
					list.Add(ilist_2[i].method_2());
				}
			}
			return list;
		}

		public static int GetSendBufferStatus()
		{
			if (class7_0 == null)
			{
				return 0;
			}
			return class7_0.method_0();
		}

		public static int GetReceiveBufferStatus()
		{
			if (class7_1 == null)
			{
				return 0;
			}
			return class7_1.method_0();
		}

		public static void Setup(int maxonlineconnections, int despatchs)
		{
			Setup(maxonlineconnections, Convert.ToInt32(Math.Ceiling((double)maxonlineconnections / 1000.0)) * 2, despatchs);
		}

		public static void Setup(int maxonlineconnections)
		{
			Setup(maxonlineconnections, 1, 1);
		}

		internal static SocketAsyncControl smethod_6()
		{
			lock (ilist_2)
			{
				if (ilist_2 != null && ilist_2.Count != 0)
				{
					int_3++;
					if (int_3 == ilist_2.Count)
					{
						int_3 = 0;
					}
					return ilist_2[int_3];
				}
				throw NetTcpException.NotInitialize();
			}
		}

		internal static object smethod_7()
		{
			return new RSACryptoServiceProvider(2048);
		}

		internal static void smethod_8()
		{
			if (!bool_1 && !ExecutionContext)
			{
				if (!System.Threading.ExecutionContext.IsFlowSuppressed())
				{
					System.Threading.ExecutionContext.SuppressFlow();
				}
				bool_1 = true;
			}
		}
	}
}
