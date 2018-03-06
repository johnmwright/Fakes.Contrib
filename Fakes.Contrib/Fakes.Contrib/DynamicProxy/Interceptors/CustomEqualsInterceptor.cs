using Castle.DynamicProxy;
using System;

namespace Fakes.Contrib.DynamicProxy.Interceptors
{
    internal class CustomEqualsInterceptor<T> : IInterceptor
    {
        private readonly Func<T, bool> _equals;

        public CustomEqualsInterceptor(Func<T, bool> equals)
        {
            _equals = equals ?? throw new ArgumentNullException(nameof(equals));
        }

        public void Intercept(IInvocation invocation)
        {
            if (invocation == null) throw new ArgumentNullException(nameof(invocation));

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
