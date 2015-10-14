using System;
using AopDemo.Interfaces;
using AopDemo.Aop.Attributes;

namespace AopDemo
{
	public class Person : IAudit
	{
		#region IAudit implementation
		public DateTime CreatedOn { get; set; } = DateTime.Now;
		public DateTime AccessedOn { get; set; } = DateTime.Now;
		public DateTime ModifiedOn { get; set; } = DateTime.Now;
		#endregion

		[Audit]
		public virtual String FirstName { get; set; }
		[Audit]
		public virtual String LastName { get; set; }
		[Audit]
		public virtual int Age { get; set; }

		public Person()
		{
		}

		public Person(String firstName, String lastName, int age)
		{
			FirstName = firstName;
			LastName = lastName;
			Age = age;
		}
	}
}

