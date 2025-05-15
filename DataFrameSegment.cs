using System;
using System.Threading;
using Beetle;

internal class DataFrameSegment : ProtocolPacketParser
{
	public int int_0;

	public override void vmethod_0()
	{
		if (CommandAttribute.bool_0 && class40_0.Socket != null)
		{
			try
			{
				Interlocked.Decrement(ref class40_0.int_1);
				class40_0.channelReceiveEventArgs_0.byteArraySegment_0.SetInfo(eventArgs0_0.Buffer, 0, int_0);
				class40_0.method_11(class40_0.channelReceiveEventArgs_0);
			}
			catch (Exception exception)
			{
				ConnectionSessionStore @class = class40_0;
				ChannelErrorEventArgs channelErrorEventArgs = new ChannelErrorEventArgs();
				channelErrorEventArgs.Channel = class40_0;
				channelErrorEventArgs.Exception = exception;
				@class.InvokeChannelError(channelErrorEventArgs);
			}
		}
	}

	public override void Dispose()
	{
		eventArgs0_0.method_1();
		class40_0 = null;
		eventArgs0_0 = null;
	}
}
