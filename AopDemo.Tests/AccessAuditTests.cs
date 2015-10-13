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
			Smock.Run(ctx => {
				var person = new Person { FirstName = "John", LastName = "Doe", Age = 24 };

				var now = DateTime.Now.AddMonths(18);
				ctx.Setup(() => DateTime.Now).Returns(now);

				var name = person.FirstName;

				Assert.AreEqual(now, person.AccessedOn);
			});
		}

		[Test]
		public void ReadingLastNameUpdatesTimestamp()
		{
			Smock.Run(ctx => {
				var person = new Person { FirstName = "John", LastName = "Doe", Age = 24 };

				var now = DateTime.Now.AddMonths(18);
				ctx.Setup(() => DateTime.Now).Returns(now);

				var name = person.LastName;

				Assert.AreEqual(now, person.AccessedOn);
			});
		}

		[Test]
		public void ReadingAgeUpdatesTimestamp()
		{
			Smock.Run(ctx => {
				var person = new Person { FirstName = "John", LastName = "Doe", Age = 24 };

				var now = DateTime.Now.AddMonths(18);
				ctx.Setup(() => DateTime.Now).Returns(now);

				var name = person.Age;

				Assert.AreEqual(now, person.AccessedOn);
			});
		}
	}
}

