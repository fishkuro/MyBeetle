using System;

namespace Beetle.Controller
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
	public abstract class FilterAttribute : Attribute
	{
		public abstract void Execute(ActionContext context);
	}
}
