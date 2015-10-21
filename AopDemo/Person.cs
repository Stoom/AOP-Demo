using System;
using AopDemo.Interfaces;
using AopDemo.Aop.Attributes;

namespace AopDemo
{
    public class Person : IAudit
    {
        #region IAudit implementation
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime AccessedOn { get; set; } = DateTime.Now;
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        #endregion

        [Audit]
        public String FirstName { get; set; }
        [Audit]
        public String LastName { get; set; }
        [Audit]
        public int Age { get; set; }
	}
}

