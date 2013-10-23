using Microsoft.QualityTools.Testing.Fakes.Stubs;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Fakes.Contrib.Extensions
{
    internal static class StubObservedCallExtensions
    {
        public static bool IsEquivalent(this StubObservedCall call, MethodCallExpression methodCallExpression)
        {
            if (call == null) throw new ArgumentNullException("call");
            if (methodCallExpression == null) throw new ArgumentNullException("methodCallExpression");

            if (call.StubbedMethod != methodCallExpression.Method)
            {
                return false;
            }

            var callArguments = call.GetArguments().ToArray();
            var methodCallArguments = methodCallExpression.Arguments.Select(GetArgumentValue).ToArray();

            return !methodCallArguments.Where((argument, index) => !argument.Equals(callArguments[index])).Any();
        }

        private static object GetArgumentValue(Expression expression)
        {
            var lambda = Expression.Lambda(expression);
            var compiledExpression = lambda.Compile();
            var value = compiledExpression.DynamicInvoke();

            return value;
        }
    }
}
