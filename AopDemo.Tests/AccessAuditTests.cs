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
            _person = PersonFactory.Instance.Create("John", "Doe", 42);
        }

		[Test]
		public void ReadingFirstNameUpdatesTimestamp()
        {
            Init();
			var before = DateTime.Now;
			var name = _person.FirstName;
			var after = DateTime.Now;

			Assert.Greater(_person.AccessedOn, before);
			Assert.Less(_person.AccessedOn, after);
		}

		[Test]
		public void ReadingLastNameUpdatesTimestamp()
        {
            Init();
			var before = DateTime.Now;
			var name = _person.LastName;
			var after = DateTime.Now;

			Assert.Greater(_person.AccessedOn, before);
			Assert.Less(_person.AccessedOn, after);
		}

		[Test]
		public void ReadingAgeUpdatesTimestamp()
		{
            Init();
			var before = DateTime.Now;
			var name = _person.Age;
			var after = DateTime.Now;

			Assert.Greater(_person.AccessedOn, before);
			Assert.Less(_person.AccessedOn, after);
		}
	}
}

