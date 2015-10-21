using System;
using LinFu.AOP.Interfaces;
using AopDemo.Interfaces;

namespace AopDemo.Aop.Aspects
{
	public class AuditProperty : IAroundInvoke
    {
        public void BeforeInvoke(IInvocationInfo info)
        {
            var audit = info.Target as IAudit;
            if (audit != null && info.TargetMethod.IsGetter())
                audit.AccessedOn = DateTime.Now;
        }

        public void AfterInvoke(IInvocationInfo info, Object returnValue)
        {
            var audit = info.Target as IAudit;
            if (info.Target is IAudit && info.TargetMethod.IsSetter())
                audit.ModifiedOn = DateTime.Now;
        }
    }
}

