using System;
using System.Runtime.CompilerServices;

namespace Beetle.Controller
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
	public class SkipFilterAttribute : Attribute
	{
		[CompilerGenerated]
		private Type[] type_0;

		public Type[] Types
		{
			[CompilerGenerated]
			get
			{
				return type_0;
			}
			[CompilerGenerated]
			set
			{
				type_0 = value;
			}
		}

		public SkipFilterAttribute(params Type[] types)
		{
			Types = types;
		}
	}
}
