using System;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;
using Castle.DynamicProxy;

namespace AopDemo.Aop.CrossCuts
{
	public class PropertyAttributeSelect : IInterceptorSelector
	{
		public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
		{
			if (method.IsGetter() || method.IsSetter())
			{
				var prop = method.DeclaringType.GetProperty(method.Name.Substring(4));
				if (prop.HasAttribute<Aop.Attributes.AuditAttribute>())
					return interceptors;
			}
			return interceptors.Where(x => !(x is Aop.Aspects.AuditProperty)).ToArray();
		}
	}
}

