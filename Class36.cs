using System;
using Beetle;

internal class Class36 : Class33
{
	public Package package_0;

	public IMessage imessage_0;

	public object object_0;

	public override void vmethod_0()
	{
		try
		{
			if (!((Class40)package_0.Channel).bool_9)
			{
				package_0.method_2(imessage_0, object_0);
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
		package_0 = null;
		class40_0 = null;
		imessage_0 = null;
	}
}
