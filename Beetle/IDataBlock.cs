using System.Collections.Generic;

namespace Beetle
{
	public interface IDataBlock
	{
		WriteBlock Allocation2Byte(WriteBlock wblock);

		WriteBlock Allocation4Byte(WriteBlock wblock);

		WriteBlock Allocation8Byte(WriteBlock wblock);

		WriteBlock WriteResultBlock(byte[] buffer, int offset, int count, WriteBlock wblock);

		IList<ByteArraySegment> GetBlock(int count);
	}
}
