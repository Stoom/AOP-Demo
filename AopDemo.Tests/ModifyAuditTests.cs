using NUnit.Framework;
using System;

namespace AopDemo.Tests
{
	[TestFixture]
	public class ModifyAuditTests
	{
		[Test]
		public void ModifyingFirstNameUpdatesTimestamp()
		{
			var person = new Person();
			var before = DateTime.Now;
			person.FirstName = "John";
			var after = DateTime.Now;

			Assert.Greater(person.ModifiedOn, before);
			Assert.Less(person.ModifiedOn, after);
		}

		[Test]
		public void ModifyingLastNameUpdatesTimestamp()
		{
			var person = new Person();
			var before = DateTime.Now;
			person.LastName = "Doe";
			var after = DateTime.Now;

			Assert.Greater(person.ModifiedOn, before);
			Assert.Less(person.ModifiedOn, after);
		}

		[Test]
		public void ModifyingAgeUpdatesTimestamp()
		{
			var person = new Person();
			var before = DateTime.Now;
			person.Age = 42;
			var after = DateTime.Now;

			Assert.Greater(person.ModifiedOn, before);
			Assert.Less(person.ModifiedOn, after);
		}
	}
}

