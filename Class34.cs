using System;
using Beetle;

internal class Class34 : Class33
{
	[Attribute8]
	public static string string_0 = "KntezZn3/HTLy0OE4rsKQJAtd7Q9rU8fhn1//PZnJ+RTNMXQ+MkO6QwQJqnn3RqN9ou6CzyfMrZWjXY9HyYCHRZ3CSvJyMY1qvMp1J9trG64OxZeCVcYGpObKBlmULBtct+eQl7GpmLt7sW4mdDuXyYWKu7XJjY893CstYfSgZa9qJnxayzFELm0iQbGDtho3l/Kp1MxUKteGuVzjquNBHG3HeJKbtv1uItsbIZ7vsIwmYb26IybmgjrUY7lPR62sbWxQr";

	[Attribute10]
	public static string string_1 = "baxxfKKgHV9XwOpsrn1uYA==";

	public override void vmethod_0()
	{
		try
		{
			class40_0.method_6();
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
