namespace Fakes.Contrib.DynamicProxy.Interceptors
{
    internal class EqualsAlwaysTrueIfNotNullInterceptor : CustomEqualsInterceptor<object>
    {
        public EqualsAlwaysTrueIfNotNullInterceptor()
            : base(obj => obj != null)
        {
        }
    }
}
