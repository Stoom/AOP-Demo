using NUnit.Framework;
using System;
using Smocks;

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
            Smock.Run(ctx => { 
                Init();

                var now = DateTime.Now.AddMonths(18);
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

                var now = DateTime.Now.AddMonths(18);
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

                var now = DateTime.Now.AddMonths(18);
                ctx.Setup(() => DateTime.Now).Returns(now);

                _person.Age = 42;

                Assert.AreEqual(now, _person.ModifiedOn);
            });
		}
	}
}

