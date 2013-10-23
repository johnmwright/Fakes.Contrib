using Castle.DynamicProxy;
using System;

namespace Fakes.Contrib.DynamicProxy.Interceptors
{
    internal class EqualsAlwaysTrueIfNotNullInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (invocation == null) throw new ArgumentNullException("invocation");

            if (invocation.Method.Name == "Equals")
            {
                invocation.ReturnValue = invocation.Arguments.Length == 1 &&
                                         invocation.Arguments[0] != null;
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
}
