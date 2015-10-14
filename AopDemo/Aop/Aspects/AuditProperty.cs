using System;
using Castle.DynamicProxy;
using AopDemo.Interfaces;

namespace AopDemo.Aop.Aspects
{
	public class AuditProperty : IInterceptor
	{
		public void Intercept(IInvocation invocation)
		{
			var audit = invocation.InvocationTarget as IAudit;
			if (audit != null && invocation.MethodInvocationTarget.IsGetter())
				audit.AccessedOn = DateTime.Now;
			
			invocation.Proceed();

			if (audit != null && invocation.MethodInvocationTarget.IsSetter())
				audit.ModifiedOn = DateTime.Now;
		}
	}
}

