using Castle.DynamicProxy;
using System;

namespace Fakes.Contrib.DynamicProxy.Interceptors
{
    internal class CustomEqualsInterceptor<T> : IInterceptor
    {
        private readonly Func<T, bool> _equals;

        public CustomEqualsInterceptor(Func<T, bool> equals)
        {
            if (equals == null) throw new ArgumentNullException("equals");
            _equals = equals;
        }

        public void Intercept(IInvocation invocation)
        {
            if (invocation == null) throw new ArgumentNullException("invocation");

            if (invocation.Method.Name == "Equals")
            {
                invocation.ReturnValue = invocation.Arguments.Length == 1 &&
                                         _equals((T)invocation.Arguments[0]);
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
}
