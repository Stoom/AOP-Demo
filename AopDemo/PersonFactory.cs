using System;
using Castle.DynamicProxy;
using AopDemo.Aop.Aspects;
using AopDemo.Aop.CrossCuts;

namespace AopDemo
{
	public class PersonFactory
	{
		public static PersonFactory GetInstance()
		{ 
			return Instance.Value;
		}
		private static readonly Lazy<PersonFactory> Instance = new Lazy<PersonFactory>(() => new PersonFactory());

		private static readonly ProxyGenerator Generator = new ProxyGenerator(new PersistentProxyBuilder());
		private static readonly IInterceptorSelector PropAttrSelector = new PropertyAttributeSelect();

		private PersonFactory()
		{
		}

		public Person CreatePerson()
		{
			var options = new ProxyGenerationOptions { Selector = PropAttrSelector };
			return (Person) Generator.CreateClassProxy(typeof(Person), options, new AuditProperty());
		}

		public Person CreatePerson(String first, String last, int age)
		{
			var options = new ProxyGenerationOptions { Selector = PropAttrSelector };
			return (Person) Generator.CreateClassProxy(typeof(Person), options, new object[] {first, last, age}, new AuditProperty());
		}
	}
}

