using System;
using System.Security.Cryptography;
using Beetle;

[AttributeUsage(AttributeTargets.All)]
internal class HandlerAttribute : Attribute
{
	private static RSACryptoServiceProvider rsacryptoServiceProvider_0;

	public static RSACryptoServiceProvider smethod_0()
	{
		if (rsacryptoServiceProvider_0 == null)
		{
			rsacryptoServiceProvider_0 = (RSACryptoServiceProvider)TcpUtils.smethod_7();
		}
		return rsacryptoServiceProvider_0;
	}
}
