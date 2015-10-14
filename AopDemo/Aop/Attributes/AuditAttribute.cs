using System;

namespace AopDemo.Aop.Attributes
{
	[AttributeUsage(AttributeTargets.Property)]
	public class AuditAttribute : Attribute
	{
	}
}

