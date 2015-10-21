using System;
using System.Reflection;

namespace AopDemo.Aop
{
    public static class MethodBaseExensions
    {
        public static bool IsGetter(this MethodBase value)
        {
            return value.IsSpecialName && value.Name.StartsWith("get_");
        }

        public static bool IsSetter(this MethodBase value)
        {
            return value.IsSpecialName && value.Name.StartsWith("set_");
        }

        public static bool IsProperty(this MethodBase value)
        {
            return value.IsGetter() || value.IsSetter();
        }
    }
}

