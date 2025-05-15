using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

internal class Class7
{
	public static int int_0;

	private int int_1;

	private ConcurrentStack<Attribute1> concurrentStack_0 = new ConcurrentStack<Attribute1>();

	public Class7(int int_2, int int_3)
	{
		int_1 = int_3;
		for (int i = 0; i < int_2; i++)
		{
			concurrentStack_0.Push(method_1());
		}
	}

	[SpecialName]
	public int method_0()
	{
		return concurrentStack_0.Count;
	}

	private Attribute1 method_1()
	{
		return new Attribute1(int_1);
	}

	public Attribute1 method_2()
	{
		Attribute1 result;
		if (!concurrentStack_0.TryPop(out result))
		{
			return method_1();
		}
		return result;
	}

	public void method_3(Attribute1 attribute1_0)
	{
		if (attribute1_0 != null)
		{
			if (attribute1_0.eventArgs0_0 != null)
			{
				attribute1_0.eventArgs0_0.class40_0 = null;
			}
			attribute1_0.method_7();
			concurrentStack_0.Push(attribute1_0);
		}
	}

	public void method_4()
	{
		concurrentStack_0.Clear();
	}
}
