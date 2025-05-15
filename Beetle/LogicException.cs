using System;

namespace Beetle
{
	public class LogicException : Exception
	{
		public LogicException()
		{
		}

		public LogicException(string string_0)
			: base(string_0)
		{
		}

		public LogicException(Exception innererr, string string_0)
			: base(string_0, innererr)
		{
		}
	}
}
