using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Beetle
{
	public abstract class Task : IDisposable
	{
		private Timer timer_0;

		private int int_0;

		private int int_1;

		[CompilerGenerated]
		private Exception exception_0;

		[CompilerGenerated]
		private bool bool_0;

		public Exception Error
		{
			[CompilerGenerated]
			get
			{
				return exception_0;
			}
			[CompilerGenerated]
			internal set
			{
				exception_0 = value;
			}
		}

		public bool IsDisposed
		{
			[CompilerGenerated]
			get
			{
				return bool_0;
			}
			[CompilerGenerated]
			private set
			{
				bool_0 = value;
			}
		}

		public Task()
		{
			IsDisposed = false;
		}

		private void method_0()
		{
			if (timer_0 != null && !IsDisposed)
			{
				timer_0.Change(-1, -1);
			}
		}

		private void method_1()
		{
			if (timer_0 != null && !IsDisposed)
			{
				timer_0.Change(int_0, int_1);
			}
		}

		public void Start(int dueTime, int period)
		{
			lock (this)
			{
				if (!IsDisposed)
				{
					int_0 = dueTime;
					int_1 = period;
					timer_0 = new Timer(method_2, null, dueTime, period);
				}
			}
		}

		private void method_2(object object_0)
		{
			method_0();
			Error = null;
			try
			{
				Execute();
			}
			catch (Exception ex)
			{
				Exception ex3 = (Error = ex);
			}
			finally
			{
				method_1();
			}
		}

		protected abstract void Execute();

		public void Dispose()
		{
			lock (this)
			{
				if (!IsDisposed)
				{
					IsDisposed = true;
				}
				if (timer_0 != null)
				{
					timer_0.Dispose();
				}
			}
		}

		internal static string smethod_0()
		{
			return null;
		}
	}
}
