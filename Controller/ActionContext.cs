using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Beetle.Controller
{
	public class ActionContext : IDisposable
	{
		private static Stack<ActionContext> stack_0;

		private IList<FilterAttribute> ilist_0;

		private BeetleTcpClient class5_0;

		private int int_0 = -1;

		[CompilerGenerated]
		private object object_0;

		[CompilerGenerated]
		private object object_1;

		[CompilerGenerated]
		private IChannel ichannel_0;

		public object Result
		{
			[CompilerGenerated]
			get
			{
				return object_0;
			}
			[CompilerGenerated]
			set
			{
				object_0 = value;
			}
		}

		public object Message
		{
			[CompilerGenerated]
			get
			{
				return object_1;
			}
			[CompilerGenerated]
			set
			{
				object_1 = value;
			}
		}

		public IChannel Channel
		{
			[CompilerGenerated]
			get
			{
				return ichannel_0;
			}
			[CompilerGenerated]
			set
			{
				ichannel_0 = value;
			}
		}

		static ActionContext()
		{
			stack_0 = new Stack<ActionContext>(128);
			for (int i = 0; i < 128; i++)
			{
				stack_0.Push(new ActionContext());
			}
		}

		private ActionContext()
		{
		}

		public static ActionContext GetContext()
		{
			lock (stack_0)
			{
				if (stack_0.Count > 0)
				{
					return stack_0.Pop();
				}
				return new ActionContext();
			}
		}

		internal void method_0(IChannel ichannel_1, object object_2, BeetleTcpClient class5_1)
		{
			int_0 = -1;
			Channel = ichannel_1;
			Message = object_2;
			ilist_0 = class5_1.ilist_0;
			class5_0 = class5_1;
		}

		public void Execute()
		{
			if (ilist_0 != null && ilist_0.Count > 0)
			{
				int_0++;
				if (int_0 >= ilist_0.Count)
				{
					Result = class5_0.method_0(Channel, Message);
				}
				else
				{
					ilist_0[int_0].Execute(this);
				}
			}
			else
			{
				Result = class5_0.method_0(Channel, Message);
			}
		}

		public void Dispose()
		{
			lock (stack_0)
			{
				stack_0.Push(this);
			}
		}
	}
}
