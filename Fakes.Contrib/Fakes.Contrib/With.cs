using System;
using Castle.DynamicProxy;
using Fakes.Contrib.DynamicProxy.Hooks;
using Fakes.Contrib.DynamicProxy.Interceptors;

namespace Fakes.Contrib
{
    /// <summary>
    /// A class to help build custom equality assertions.
    /// </summary>
    public static class With
    {
        /// <summary>
        /// Returns a proxy class that overrides equals to return true for any not null object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Any<T>()
            where T : class
        {
            var proxyGenerator = new ProxyGenerator();
            var proxyGenerationOptions = new ProxyGenerationOptions(new InterceptEqualsHook());
            var proxy = proxyGenerator.CreateClassProxy<T>(proxyGenerationOptions, new EqualsAlwaysTrueIfNotNullInterceptor());

            return proxy;
        }
    }

    /// <summary>
    /// A class to help build custom equality assertions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class With<T>
        where T : class
    {
        /// <summary>
        /// Returns a proxy class that overrides equals to return true for any object matching the given predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T Like(Func<T, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");

            var proxyGenerator = new ProxyGenerator();
            var proxyGenerationOptions = new ProxyGenerationOptions(new InterceptEqualsHook());
            var proxy = proxyGenerator.CreateClassProxy<T>(proxyGenerationOptions, new CustomEqualsInterceptor<T>(predicate));

            return proxy;
        }
    }
}
