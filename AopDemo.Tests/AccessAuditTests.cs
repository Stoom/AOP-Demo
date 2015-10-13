using NUnit.Framework;
using Smocks;
using System;

namespace AopDemo.Tests
{
	[TestFixture]
	public class AccessAuditTests
	{
		[Test]
		public void ReadingFirstNameUpdatesTimestamp()
		{
			var person = new Person { FirstName = "John", LastName = "Doe", Age = 24 };
			var before = DateTime.Now;
			var name = person.FirstName;
			var after = DateTime.Now;

			Assert.Greater(person.AccessedOn, before);
			Assert.Less(person.AccessedOn, after);
		}

		[Test]
		public void ReadingLastNameUpdatesTimestamp()
		{
			var person = new Person { FirstName = "John", LastName = "Doe", Age = 24 };
			var before = DateTime.Now;
			var name = person.LastName;
			var after = DateTime.Now;

			Assert.Greater(person.AccessedOn, before);
			Assert.Less(person.AccessedOn, after);
		}

		[Test]
		public void ReadingAgeUpdatesTimestamp()
		{
			var person = new Person { FirstName = "John", LastName = "Doe", Age = 24 };
			var before = DateTime.Now;
			var name = person.Age;
			var after = DateTime.Now;

			Assert.Greater(person.AccessedOn, before);
			Assert.Less(person.AccessedOn, after);
		}
	}
}

