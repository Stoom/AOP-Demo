using NUnit.Framework;
using System;

namespace AopDemo.Tests
{
	[TestFixture]
	public class ModifyAuditTests
	{
        private Person _person;

        public void Init()
        {
            _person = PersonFactory.Instance.Create();
        }

		[Test]
		public void ModifyingFirstNameUpdatesTimestamp()
		{
            Init();
            var before = DateTime.Now;
            _person.FirstName = "John";
			var after = DateTime.Now;

            Assert.Greater(_person.ModifiedOn, before);
            Assert.Less(_person.ModifiedOn, after);
		}

		[Test]
		public void ModifyingLastNameUpdatesTimestamp()
        {
            Init();
			var before = DateTime.Now;
            _person.LastName = "Doe";
			var after = DateTime.Now;

            Assert.Greater(_person.ModifiedOn, before);
            Assert.Less(_person.ModifiedOn, after);
		}

		[Test]
		public void ModifyingAgeUpdatesTimestamp()
        {
            Init();
			var before = DateTime.Now;
            _person.Age = 42;
			var after = DateTime.Now;

            Assert.Greater(_person.ModifiedOn, before);
            Assert.Less(_person.ModifiedOn, after);
		}
	}
}

