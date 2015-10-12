using System;
using AopDemo.Interfaces;

namespace AopDemo
{
	public class Person : IAudit
	{
		#region IAudit implementation
		public DateTime CreatedOn { get; set; }
		public DateTime AccessedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		#endregion

		public String FirstName { get; set; }
		public String LastName { get; set; }
		public int Age { get; set; }
	}
}

