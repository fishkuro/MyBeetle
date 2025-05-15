using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

internal class ClientTokenSession
{
	public static int int_0;

	private int int_1;

	private ConcurrentStack<CommandAttribute> concurrentStack_0 = new ConcurrentStack<CommandAttribute>();

	public ClientTokenSession(int int_2, int int_3)
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

	private CommandAttribute method_1()
	{
		return new CommandAttribute(int_1);
	}

	public CommandAttribute method_2()
	{
		CommandAttribute result;
		if (!concurrentStack_0.TryPop(out result))
		{
			return method_1();
		}
		return result;
	}

	public void method_3(CommandAttribute attribute1_0)
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
