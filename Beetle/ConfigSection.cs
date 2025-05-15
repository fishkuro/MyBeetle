using System.Configuration;

namespace Beetle
{
	public class ConfigSection : ConfigurationSection
	{
		[IntegerValidator(MaxValue = 50000, MinValue = 1)]
		[ConfigurationProperty("Connections", DefaultValue = 1000)]
		public int Connections
		{
			get
			{
				return (int)base["Connections"];
			}
			set
			{
				base["Connections"] = value;
			}
		}

		[IntegerValidator(MaxValue = 100, MinValue = 1)]
		[ConfigurationProperty("Pools", DefaultValue = 1)]
		public int Pools
		{
			get
			{
				return (int)base["Pools"];
			}
			set
			{
				base["Pools"] = value;
			}
		}

		[IntegerValidator(MaxValue = 100, MinValue = 0)]
		[ConfigurationProperty("SocketSendThreads", DefaultValue = 1)]
		public int SocketSendThreads
		{
			get
			{
				return (int)base["SocketSendThreads"];
			}
			set
			{
				base["SocketSendThreads"] = value;
			}
		}

		[IntegerValidator(MaxValue = 100, MinValue = 0)]
		[ConfigurationProperty("SocketReceiveThreads", DefaultValue = 1)]
		public int SocketReceiveThreads
		{
			get
			{
				return (int)base["SocketReceiveThreads"];
			}
			set
			{
				base["SocketReceiveThreads"] = value;
			}
		}

		[IntegerValidator(MaxValue = 1000, MinValue = 0)]
		[ConfigurationProperty("SocketThreadSleep", DefaultValue = 10)]
		public int SocketThreadSleep
		{
			get
			{
				return (int)base["SocketThreadSleep"];
			}
			set
			{
				base["SocketThreadSleep"] = value;
			}
		}

		[ConfigurationProperty("WorkThreads", DefaultValue = 1)]
		[IntegerValidator(MaxValue = 100, MinValue = 0)]
		public int WorkThreads
		{
			get
			{
				return (int)base["WorkThreads"];
			}
			set
			{
				base["WorkThreads"] = value;
			}
		}

		[ConfigurationProperty("WorkThreadSleep", DefaultValue = 10)]
		[IntegerValidator(MaxValue = 1000, MinValue = 0)]
		public int WorkThreadSleep
		{
			get
			{
				return (int)base["WorkThreadSleep"];
			}
			set
			{
				base["WorkThreadSleep"] = value;
			}
		}

		[IntegerValidator(MaxValue = 10248576, MinValue = 1024)]
		[ConfigurationProperty("SendBufferSize", DefaultValue = 2048)]
		public int SendBufferSize
		{
			get
			{
				return (int)base["SendBufferSize"];
			}
			set
			{
				base["SendBufferSize"] = value;
			}
		}

		[ConfigurationProperty("ReceiveBufferSize", DefaultValue = 2048)]
		[IntegerValidator(MaxValue = 10248576, MinValue = 1024)]
		public int ReceiveBufferSize
		{
			get
			{
				return (int)base["ReceiveBufferSize"];
			}
			set
			{
				base["ReceiveBufferSize"] = value;
			}
		}

		[IntegerValidator(MaxValue = 102485760, MinValue = 1024)]
		[ConfigurationProperty("PackageMaxSize", DefaultValue = 8192)]
		public int PackageMaxSize
		{
			get
			{
				return (int)base["PackageMaxSize"];
			}
			set
			{
				base["PackageMaxSize"] = value;
			}
		}

		[IntegerValidator(MaxValue = 65536, MinValue = 1)]
		[ConfigurationProperty("StringEncodingSize", DefaultValue = 512)]
		public int StringEncodingSize
		{
			get
			{
				return (int)base["StringEncodingSize"];
			}
			set
			{
				base["StringEncodingSize"] = value;
			}
		}

		[ConfigurationProperty("EnabledReceiveQueue", DefaultValue = true)]
		public bool EnabledReceiveQueue
		{
			get
			{
				return (bool)base["EnabledReceiveQueue"];
			}
			set
			{
				base["EnabledReceiveQueue"] = value;
			}
		}

		[ConfigurationProperty("EnabledSendQueue", DefaultValue = true)]
		public bool EnabledSendQueue
		{
			get
			{
				return (bool)base["EnabledSendQueue"];
			}
			set
			{
				base["EnabledSendQueue"] = value;
			}
		}

		[ConfigurationProperty("EnabledWorkQueue", DefaultValue = true)]
		public bool EnabledWorkQueue
		{
			get
			{
				return (bool)base["EnabledWorkQueue"];
			}
			set
			{
				base["EnabledWorkQueue"] = value;
			}
		}

		[ConfigurationProperty("Statistics", DefaultValue = false)]
		public bool Statistics
		{
			get
			{
				return (bool)base["Statistics"];
			}
			set
			{
				base["Statistics"] = value;
			}
		}

		[ConfigurationProperty("ChannelMaxQueueData", DefaultValue = 0)]
		public int ChannelMaxQueueData
		{
			get
			{
				return (int)base["ChannelMaxQueueData"];
			}
			set
			{
				base["ChannelMaxQueueData"] = value;
			}
		}

		[ConfigurationProperty("MonitorLock", DefaultValue = false)]
		public bool MonitorLock
		{
			get
			{
				return (bool)base["MonitorLock"];
			}
			set
			{
				base["MonitorLock"] = value;
			}
		}

		[ConfigurationProperty("ExecutionContext", DefaultValue = false)]
		public bool ExecutionContext
		{
			get
			{
				return (bool)base["ExecutionContext"];
			}
			set
			{
				base["ExecutionContext"] = value;
			}
		}

		[ConfigurationProperty("TimeOut", DefaultValue = 30)]
		public int TimeOut
		{
			get
			{
				return (int)base["TimeOut"];
			}
			set
			{
				base["TimeOut"] = value;
			}
		}
	}
}
