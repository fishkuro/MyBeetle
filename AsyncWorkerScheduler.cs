using System;
using Beetle;

internal class AsyncWorkerScheduler : ProtocolPacketParser
{
	public override void vmethod_0()
	{
		if (!CommandAttribute.bool_1 || class40_0.Socket == null)
		{
			return;
		}
		try
		{
			if (!class40_0.IsDisposed)
			{
				class40_0.method_9();
			}
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

	public override void Dispose()
	{
	}
}
