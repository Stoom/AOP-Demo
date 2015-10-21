using System;
using LinFu.AOP.Interfaces;
using AopDemo.Aop;
using AopDemo.Aop.Aspects;

namespace AopDemo
{
    public class PersonFactory
    {
        public static PersonFactory Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        private static Lazy<PersonFactory> _instance = new Lazy<PersonFactory>(() => new PersonFactory());

        private PersonFactory()
        {
        }

        public Person Create()
        {
            return Create(String.Empty, String.Empty, 0);
        }

        public Person Create(string first, string last, int age)
        {
            var person = new Person
            {
                FirstName = first,
                LastName = last,
                Age = age
            };

            var modified = person as IModifiableType;
            if (modified != null)
            {
                modified.IsInterceptionDisabled = false;
                modified.AroundMethodBodyProvider = new SimpleAroundInvokeProvider(new AuditProperty())
                {
                    MethodInvokePredicate = Aop.CrossCuts.PropertyAttributeSelect.ShouldReplace
                };
            }

            return person;
        }
    }
}

