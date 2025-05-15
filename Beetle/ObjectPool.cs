using System;
using System.Collections.Generic;

namespace Beetle
{
	public class ObjectPool<T> : IDisposable where T : new()
	{
		protected Stack<T> mObjects = new Stack<T>();

		public ObjectPool(int counts)
		{
			for (int i = 0; i < counts; i++)
			{
				mObjects.Push(new T());
			}
		}

		public virtual T Pop()
		{
			lock (mObjects)
			{
				if (mObjects.Count > 0)
				{
					return mObjects.Pop();
				}
				return new T();
			}
		}

		public virtual void Push(T gparam_0)
		{
			lock (mObjects)
			{
				if (gparam_0 != null)
				{
					mObjects.Push(gparam_0);
				}
			}
		}

		public void Dispose()
		{
			if (typeof(T) == typeof(IDisposable))
			{
				while (mObjects.Count > 0)
				{
					((IDisposable)(object)mObjects.Pop()).Dispose();
				}
			}
			mObjects.Clear();
		}
	}
}
