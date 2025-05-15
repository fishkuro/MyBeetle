using System.Reflection;

internal class EventDrivenSocket
{
	internal static object smethod_0()
	{
		MethodInfo[] methods = typeof(CryptoProvider).GetMethods(BindingFlags.Static | BindingFlags.Public);
		int num = 0;
		MethodInfo methodInfo;
		while (true)
		{
			if (num < methods.Length)
			{
				methodInfo = methods[num];
				if (methodInfo.GetCustomAttributes(typeof(ProtocolAttribute), false).Length > 0)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return methodInfo.Invoke(null, null);
	}

	internal static string smethod_1()
	{
		FieldInfo[] fields = typeof(SocketAsyncControl).GetFields(BindingFlags.Static | BindingFlags.Public);
		int num = 0;
		FieldInfo fieldInfo;
		while (true)
		{
			if (num < fields.Length)
			{
				fieldInfo = fields[num];
				if (fieldInfo.GetCustomAttributes(typeof(EventAttribute), false).Length > 0)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return (string)fieldInfo.GetValue(null);
	}

	internal static string smethod_2()
	{
		FieldInfo[] fields = typeof(SocketAsyncControl).GetFields(BindingFlags.Static | BindingFlags.Public);
		int num = 0;
		FieldInfo fieldInfo;
		while (true)
		{
			if (num < fields.Length)
			{
				fieldInfo = fields[num];
				if (fieldInfo.GetCustomAttributes(typeof(CommandAttribute), false).Length > 0)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return (string)fieldInfo.GetValue(null);
	}
}
