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

		public String FirstName
		{ 
			get
			{
				AccessedOn = DateTime.Now;
				return _firstName;
			}
			set
			{
				_firstName = value;
				ModifiedOn = DateTime.Now;
			}
		}
		public String LastName
		{ 
			get
			{
				AccessedOn = DateTime.Now;
				return _lastName;
			}
			set
			{
				_lastName = value;
				ModifiedOn = DateTime.Now;
			}
		}
		public int Age
		{ 
			get
			{
				AccessedOn = DateTime.Now;
				return _age;
			}
			set
			{
				_age = value;
				ModifiedOn = DateTime.Now;
			}
		}

		private String _firstName;
		private String _lastName;
		private int _age;
	}
}

