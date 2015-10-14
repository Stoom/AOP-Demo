using System;
using Castle.DynamicProxy;
using AopDemo.Aop.Aspects;
using AopDemo.Aop.CrossCuts;

namespace AopDemo
{
	public static class PersonFactory
	{
		private static readonly ProxyGenerator Generator = new ProxyGenerator(new PersistentProxyBuilder());
		private static readonly IInterceptorSelector PropAttrSelector = new PropertyAttributeSelect();

		public static Person CreatePerson()
		{
			var options = new ProxyGenerationOptions { Selector = PropAttrSelector };
			return (Person) Generator.CreateClassProxy(typeof(Person), options, new AuditProperty());
		}

		public static Person CreatePerson(String first, String last, int age)
		{
			var options = new ProxyGenerationOptions { Selector = PropAttrSelector };
			return (Person) Generator.CreateClassProxy(typeof(Person), options, new object[] {first, last, age}, new AuditProperty());
		}
	}
}

