using NUnit.Framework;
using Smocks;
using System;

namespace AopDemo.Tests
{
	[TestFixture]
	public class ModifyAuditTests
	{
		private Person _person;

		public void Init()
		{
			_person = PersonFactory.CreatePerson();
		}

		[Test]
		public void ModifyingFirstNameUpdatesTimestamp()
		{
			Smock.Run(ctx => {
				Init();

				var now = DateTime.Now;
				ctx.Setup(() => DateTime.Now).Returns(now);

				_person.FirstName = "John";

				Assert.AreEqual(now, _person.ModifiedOn);
			});
		}

		[Test]
		public void ModifyingLastNameUpdatesTimestamp()
		{

			Smock.Run(ctx => {
				Init();

				var now = DateTime.Now;
				ctx.Setup(() => DateTime.Now).Returns(now);

				_person.LastName = "Doe";

				Assert.AreEqual(now, _person.ModifiedOn);
			});
		}

		[Test]
		public void ModifyingAgeUpdatesTimestamp()
		{
			Smock.Run(ctx => {
				Init();

				var now = DateTime.Now;
				ctx.Setup(() => DateTime.Now).Returns(now);

				_person.Age = 42;

				Assert.AreEqual(now, _person.ModifiedOn);
			});
		}
	}
}

