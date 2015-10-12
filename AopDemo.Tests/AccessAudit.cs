using NUnit.Framework;
using Smocks;
using System;

namespace AopDemo.Tests
{
	[TestFixture]
	public class AccessAudit
	{
		[Test]
		public void ReadingNameUpdatesTimestamp()
		{

			Smock.Run (ctx => {
				var now = DateTime.Now.AddMonths (18);
				var person = new Person { FirstName = "John", LastName = "Doe", Age = 24 };

				ctx.Setup (() => DateTime.Now).Returns (now);

				var name = person.FirstName;

				Assert.AreEqual (now, person.AccessedOn);
			});
		}
	}
}

