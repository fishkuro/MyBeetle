using System.Reflection;

internal class Class24
{
	internal static object smethod_0()
	{
		MethodInfo[] methods = typeof(Class21).GetMethods(BindingFlags.Static | BindingFlags.Public);
		int num = 0;
		MethodInfo methodInfo;
		while (true)
		{
			if (num < methods.Length)
			{
				methodInfo = methods[num];
				if (methodInfo.GetCustomAttributes(typeof(Attribute4), false).Length > 0)
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
		FieldInfo[] fields = typeof(Class42).GetFields(BindingFlags.Static | BindingFlags.Public);
		int num = 0;
		FieldInfo fieldInfo;
		while (true)
		{
			if (num < fields.Length)
			{
				fieldInfo = fields[num];
				if (fieldInfo.GetCustomAttributes(typeof(Attribute9), false).Length > 0)
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
		FieldInfo[] fields = typeof(Class42).GetFields(BindingFlags.Static | BindingFlags.Public);
		int num = 0;
		FieldInfo fieldInfo;
		while (true)
		{
			if (num < fields.Length)
			{
				fieldInfo = fields[num];
				if (fieldInfo.GetCustomAttributes(typeof(Attribute1), false).Length > 0)
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
