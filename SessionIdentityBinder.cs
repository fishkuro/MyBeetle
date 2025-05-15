using System.Collections.Generic;
using Beetle;

internal class SessionIdentityBinder
{
	public ClientTokenSession class7_0;

	public CommandAttribute attribute1_0;

	public List<IMessage> list_0;

	public bool method_0()
	{
		if (attribute1_0 != null)
		{
			CommandAttribute attribute = attribute1_0;
			attribute1_0 = null;
			CommandAttribute attribute2 = attribute.attribute1_0;
			attribute.attribute1_0 = null;
			class7_0.method_3(attribute);
			if (attribute2 != null)
			{
				attribute1_0 = attribute2;
				return true;
			}
		}
		return false;
	}

	public void method_1()
	{
		CommandAttribute attribute = attribute1_0;
		attribute1_0 = null;
		CommandAttribute attribute2 = null;
		while (attribute != null)
		{
			attribute2 = attribute.attribute1_0;
			attribute.attribute1_0 = null;
			class7_0.method_3(attribute);
			attribute = attribute2;
		}
	}
}
