using NUnit.Framework;
using Smocks;
using System;

namespace AopDemo.Tests
{
	[TestFixture]
	public class ModifyAuditTests
	{
		[Test]
		public void ModifyingFirstNameUpdatesTimestamp()
		{
			Smock.Run(ctx => {
				var person = new Person();

				var now = DateTime.Now;
				ctx.Setup(() => DateTime.Now).Returns(now);

				person.FirstName = "John";

				Assert.AreEqual(now, person.ModifiedOn);
			});
		}

		[Test]
		public void ModifyingLastNameUpdatesTimestamp()
		{
			Smock.Run(ctx => {
				var person = new Person();

				var now = DateTime.Now;
				ctx.Setup(() => DateTime.Now).Returns(now);

				person.LastName = "Doe";

				Assert.AreEqual(now, person.ModifiedOn);
			});
		}

		[Test]
		public void ModifyingAgeUpdatesTimestamp()
		{
			Smock.Run(ctx => {
				var person = new Person();

				var now = DateTime.Now;
				ctx.Setup(() => DateTime.Now).Returns(now);

				person.Age = 42;

				Assert.AreEqual(now, person.ModifiedOn);
			});
		}
	}
}

