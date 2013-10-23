using Castle.DynamicProxy;
using Fakes.Contrib.DynamicProxy.Hooks;
using Fakes.Contrib.DynamicProxy.Interceptors;

namespace Fakes.Contrib
{
    public static class With
    {
        public static T Any<T>()
            where T : class, new()
        {
            var proxyGenerator = new ProxyGenerator();
            var proxyGenerationOptions = new ProxyGenerationOptions(new InterceptEqualsHook());
            var proxy = proxyGenerator.CreateClassProxy<T>(proxyGenerationOptions, new EqualsAlwaysTrueIfNotNullInterceptor());

            return proxy;
        }
    }
}
