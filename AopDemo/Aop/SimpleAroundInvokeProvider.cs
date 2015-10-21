using System;
using LinFu.AOP.Interfaces;


namespace AopDemo.Aop
{
    public class SimpleAroundInvokeProvider : IAroundInvokeProvider
    {
        public Func<IInvocationInfo, bool> MethodInvokePredicate { get; set; }

        private IAroundInvoke _around;

        public SimpleAroundInvokeProvider(IAroundInvoke around)
        {
            _around = around;
        }

        #region IAroundInvokeProvider Members
        public IAroundInvoke GetSurroundingImplementation(IInvocationInfo context)
        {
            if (MethodInvokePredicate == null || !MethodInvokePredicate(context))
                return null;
            return _around;
        }
        #endregion
    }
}

