using System;
using System.Linq;
using System.Reflection;
using LinFu.AOP.Interfaces;
using AopDemo.Aop.Attributes;

namespace AopDemo.Aop.CrossCuts
{
    public static class PropertyAttributeSelect
    {
        public static bool ShouldReplace(IInvocationInfo context)
        {
            var method = context.TargetMethod;
            if (method.IsProperty())
            {
                var prop = context.Target.GetType().GetProperty(method.Name.Substring(4));
                if (prop.HasAttribute<AuditAttribute>())
                    return true;
            }
            return false;
        }
    }
}

