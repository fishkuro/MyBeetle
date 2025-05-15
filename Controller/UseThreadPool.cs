using System;

namespace Beetle.Controller
{
	[AttributeUsage(AttributeTargets.Method)]
	public class UseThreadPool : Attribute
	{
	}
}
