namespace Fakes.Contrib.Tests.Classes
{
    public interface IMethodsThatTakeArrays
    {
        void MethodTakesArray<T>(T[] inputs);
        void MethodTakesParams<T>(params T[] inputs);
    }

    public class MethodsThatTakeArrays : IMethodsThatTakeArrays
    {
        public virtual void MethodTakesArray<T>(T[] inputs)
        {
        }

        public virtual void MethodTakesParams<T>(params T[] inputs)
        {
        }

    }

    public class NonVirtualMethodsThatTakeArrays : IMethodsThatTakeArrays
    {
        public void MethodTakesArray<T>(T[] inputs)
        {
        }

        public void MethodTakesParams<T>(params T[] inputs)
        {
        }

    }


}