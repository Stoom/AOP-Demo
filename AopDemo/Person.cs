using System;
using AopDemo.Interfaces;

namespace AopDemo
{
	public class Person : IAudit
	{
		#region IAudit implementation
		public DateTime CreatedOn { get; set; } = DateTime.Now;
		public DateTime AccessedOn { get; set; } = DateTime.Now;
		public DateTime ModifiedOn { get; set; } = DateTime.Now;
		#endregion

		public String FirstName { get; set; }
		public String LastName { get; set; }
		public int Age { get; set; }

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

