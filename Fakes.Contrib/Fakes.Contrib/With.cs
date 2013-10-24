using Castle.DynamicProxy;
using Fakes.Contrib.DynamicProxy.Hooks;
using Fakes.Contrib.DynamicProxy.Interceptors;
using System;
using System.Collections.Generic;

namespace Fakes.Contrib
{
    public static class With
    {
        public static TValue Any<TValue>()
            where TValue : class
        {
            var proxyGenerator = new ProxyGenerator();
            var proxyGenerationOptions = new ProxyGenerationOptions(new InterceptEqualsHook());
            var proxy = proxyGenerator.CreateClassProxy<TValue>(proxyGenerationOptions, new EqualsAlwaysTrueIfNotNullInterceptor());

            return proxy;
        }

        public static IEnumerableWith<TValue> Enumerable<TValue>(IEnumerable<TValue> source)
            where TValue : class
        {
            return new EnumerableWith<TValue>(source);
        }
    }

    public static class With<TValue>
        where TValue : class
    {
        public static TValue Like(Func<TValue, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");

            var proxyGenerator = new ProxyGenerator();
            var proxyGenerationOptions = new ProxyGenerationOptions(new InterceptEqualsHook());
            var proxy = proxyGenerator.CreateClassProxy<TValue>(proxyGenerationOptions, new CustomEqualsInterceptor<TValue>(predicate));

            return proxy;
        }
    }
}
