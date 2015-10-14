using NUnit.Framework;
using Smocks;
using System;

namespace AopDemo.Tests
{
	[TestFixture]
	public class AccessAuditTests
	{
		private Person _person;

		public void Init()
		{
			_person = PersonFactory.CreatePerson("John", "Doe", 24);
		}

		[Test]
		public void ReadingFirstNameUpdatesTimestamp()
		{
			Smock.Run(ctx => {
				Init();

				var now = DateTime.Now.AddMonths(18);
				ctx.Setup(() => DateTime.Now).Returns(now);

				var name = _person.FirstName;

				Assert.AreEqual(now, _person.AccessedOn);
			});
		}

		[Test]
		public void ReadingLastNameUpdatesTimestamp()
		{
			Smock.Run(ctx => {
				Init();

				var now = DateTime.Now.AddMonths(18);
				ctx.Setup(() => DateTime.Now).Returns(now);

				var name = _person.LastName;

				Assert.AreEqual(now, _person.AccessedOn);
			});
		}

		[Test]
		public void ReadingAgeUpdatesTimestamp()
		{
			Smock.Run(ctx => {
				Init();

				var now = DateTime.Now.AddMonths(18);
				ctx.Setup(() => DateTime.Now).Returns(now);

				var name = _person.Age;

				Assert.AreEqual(now, _person.AccessedOn);
			});
		}
	}
}

