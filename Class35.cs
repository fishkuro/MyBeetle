using System;
using Beetle;

internal class Class35 : Class33
{
	public override void vmethod_0()
	{
		if (!Attribute1.bool_1 || class40_0.Socket == null)
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
			Class40 @class = class40_0;
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
