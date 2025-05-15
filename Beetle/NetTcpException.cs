using System;
using System.Runtime.CompilerServices;

namespace Beetle
{
	public class NetTcpException : Exception
	{
		internal const string string_0 = "<Modulus>{0}<Modulus/>";

		internal const string string_1 = "The message is too long";

		internal const string string_2 = "Cross-border access to data";

		internal const string string_3 = " IPAddress Error!";

		internal const string string_4 = "{0} Type not found!";

		internal const string string_5 = "{0} load data error!";

		internal const string string_6 = "Connection is not available";

		internal const string string_7 = "channel is disposed!";

		internal const string string_8 = "channel receive data timeout!";

		internal const string string_9 = "channel data process error!";

		internal const string string_10 = "channel must be connected";

		internal const string string_11 = "{0} config section not found!";

		internal const string string_12 = "{0} client pool config section not found!";

		internal const int int_0 = 10001;

		internal const int int_1 = 10004;

		internal const int int_2 = 10006;

		[CompilerGenerated]
		private int int_3;

		public int ErrorNumber
		{
			[CompilerGenerated]
			internal get
			{
				return int_3;
			}
			[CompilerGenerated]
			set
			{
				int_3 = value;
			}
		}

		public NetTcpException()
		{
		}

		public NetTcpException(string string_13)
			: base(string_13)
		{
		}

		public NetTcpException(Exception innererr, string string_13)
			: base(string_13, innererr)
		{
		}

		public static NetTcpException ConfigSelectionNotFound(string name)
		{
			return new NetTcpException(string.Format("{0} config section not found!", name));
		}

		public static NetTcpException ConnectionIsNotAvailable()
		{
			return new NetTcpException("Connection is not available");
		}

		public static NetTcpException ObjectLoadError(string type, Exception innerexception)
		{
			return new NetTcpException(innerexception, string.Format("{0} load data error!", type));
		}

		public static NetTcpException ReadToByteArraySegment()
		{
			return new NetTcpException("read to ByteArraySegment error!");
		}

		public static NetTcpException ClientDataProcessError(Exception innerexception)
		{
			return new NetTcpException(innerexception, "channel data process error!");
		}

		public static NetTcpException ClientPoolSectionNotFound(string name)
		{
			return new NetTcpException(string.Format("{0} client pool config section not found!", name));
		}

		public static NetTcpException ClientReceiveTimeout()
		{
			return new NetTcpException("channel receive data timeout!");
		}

		public static NetTcpException ClientMustBeConnected()
		{
			return new NetTcpException("channel must be connected");
		}

		public static NetTcpException ClientIsDisposed()
		{
			return new NetTcpException("channel is disposed!");
		}

		public static NetTcpException StringEncodingError(Exception innerexception)
		{
			return new NetTcpException(innerexception, "string encoding error!");
		}

		public static NetTcpException StringDecodingError(Exception innerexception)
		{
			return new NetTcpException(innerexception, "string decoding error!");
		}

		public static NetTcpException NotInitialize()
		{
			return new NetTcpException("Beetle component did not initialize!\r\nCall TcpUtil.Setup!");
		}

		public static NetTcpException PacketAnyalysisNotInitialize()
		{
			return new NetTcpException("Beetle Anyalysis  did not initialize!\r\nCall PacketAnalysis.Setup!");
		}

		public static NetTcpException TypeNotFound(string name)
		{
			return new NetTcpException(string.Format("{0} Type not found!", name));
		}

		public static NetTcpException DataOverflow()
		{
			NetTcpException ex = new NetTcpException("The message is too long");
			ex.ErrorNumber = 10001;
			return ex;
		}

		public static NetTcpException ReadDataError(Exception innererror)
		{
			NetTcpException ex = new NetTcpException(innererror, "Cross-border access to data");
			ex.ErrorNumber = 10004;
			return ex;
		}

		public static NetTcpException IPAddressError()
		{
			NetTcpException ex = new NetTcpException(" IPAddress Error!");
			ex.ErrorNumber = 10006;
			return ex;
		}
	}
}
