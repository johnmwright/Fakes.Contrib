using Castle.DynamicProxy;
using System;
using System.Reflection;

namespace Fakes.Contrib.DynamicProxy.Hooks
{
    internal class InterceptEqualsHook : IProxyGenerationHook
    {
        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            if (methodInfo == null) throw new ArgumentNullException("methodInfo");

            return methodInfo.Name == "Equals";
        }
    }
}
