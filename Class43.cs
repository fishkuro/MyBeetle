using System.Collections.Generic;
using Beetle;

internal class Class43
{
	public Class7 class7_0;

	public Attribute1 attribute1_0;

	public List<IMessage> list_0;

	public bool method_0()
	{
		if (attribute1_0 != null)
		{
			Attribute1 attribute = attribute1_0;
			attribute1_0 = null;
			Attribute1 attribute2 = attribute.attribute1_0;
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
		Attribute1 attribute = attribute1_0;
		attribute1_0 = null;
		Attribute1 attribute2 = null;
		while (attribute != null)
		{
			attribute2 = attribute.attribute1_0;
			attribute.attribute1_0 = null;
			class7_0.method_3(attribute);
			attribute = attribute2;
		}
	}
}
