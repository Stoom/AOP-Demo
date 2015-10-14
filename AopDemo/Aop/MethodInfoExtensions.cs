using System;
using System.Reflection;

namespace AopDemo.Aop
{
	public static class MethodInfoExtensions
	{
		public static bool IsGetter(this MethodInfo value)
		{
			return value.IsSpecialName && value.Name.StartsWith("get_");
		}

		public static bool IsSetter(this MethodInfo value)
		{
			return value.IsSpecialName && value.Name.StartsWith("set_");
		}
	}
}

