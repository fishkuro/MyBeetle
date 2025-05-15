namespace Beetle
{
	public class ChannelReceiveEventArgs : ChannelEventArgs
	{
		internal ByteArraySegment byteArraySegment_0;

		public ByteArraySegment Data
		{
			get
			{
				return byteArraySegment_0;
			}
		}

		public ChannelReceiveEventArgs()
		{
			byteArraySegment_0 = new ByteArraySegment();
		}
	}
}
