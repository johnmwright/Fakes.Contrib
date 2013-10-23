using System.Collections.Generic;
using Castle.DynamicProxy;
using Fakes.Contrib.DynamicProxy.Hooks;
using Fakes.Contrib.DynamicProxy.Interceptors;
using System;
using System.Linq;

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

        public static With<T, IEnumerable<T>> Enumerable<T>(IEnumerable<T> source)
            where T : class
        {
            return new With<T, IEnumerable<T>>(source);
        }

        /// <summary>
        /// Return a With helper initialized with an Array source.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static With<T, T[]> Array<T>(T[] source)
            where T : class
        {
            return new With<T, T[]>(source, x => x.ToArray());
        }
    }

    /// <summary>
    /// A class to help build custom equality assertions.
    /// </summary>
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

    /// <summary>
    /// A class to help build custom equality assertions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public class With<T, TOut>
        where T : class
    {
        private readonly IEnumerable<T> _source;
        private readonly Func<IEnumerable<T>, TOut> _outputTransform;

        internal With(IEnumerable<T> source)
            : this(source, x => (TOut)x)
        {
        }

        internal With(IEnumerable<T> source, Func<IEnumerable<T>, TOut> outputTransform)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (outputTransform == null) throw new ArgumentNullException("outputTransform");
            _source = source;
            _outputTransform = outputTransform;
        }

        public TOut Like(Func<T, T, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");

            return _outputTransform(_source.Select(item => (Func<T, bool>) (x => predicate(item, x))).Select(With<T>.Like));
        }
    }
}
