using Fakes.Contrib.Collections.Generic;
using Microsoft.QualityTools.Testing.Fakes.Stubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Fakes.Contrib.Extensions
{
    internal static class StubObservedCallExtensions
    {
        private static readonly IEqualityComparer<object> DeepArrayComparer = new DeepArrayComparer();

        public static bool IsEquivalent(this StubObservedCall call, MethodCallExpression methodCallExpression)
        {
            if (call == null) throw new ArgumentNullException(nameof(call));
            if (methodCallExpression == null) throw new ArgumentNullException(nameof(methodCallExpression));

            if (call.StubbedMethod != methodCallExpression.Method)
            {
                return false;
            }

            var callArguments = call.GetArguments().ToArray();
            var methodCallArguments = methodCallExpression.Arguments.Select(GetArgumentValue).ToArray();
            var isEquivalent = callArguments.Length == methodCallArguments.Length && methodCallArguments.SequenceEqual(callArguments, DeepArrayComparer);

            return isEquivalent;
        }

        private static readonly MethodInfo MethodInfoForWithAny = typeof(With).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .First(m => m.Name == nameof(With.Any) && m.IsGenericMethod)
            .GetBaseDefinition();


        private static object GetArgumentValue(Expression expression)
        {
            if (expression is MethodCallExpression callExpression 
                && callExpression.Method.IsGenericMethod
                && callExpression.Method.GetGenericMethodDefinition() == MethodInfoForWithAny)
            {
                var genericType = callExpression.Method.GetGenericArguments().First();
                return new WithProxyPlaceholder {ArgType = genericType};
            }
            
            var lambda = Expression.Lambda(expression);
            var compiledExpression = lambda.Compile();
            var value = compiledExpression.DynamicInvoke();

            return value;
        }
    }
}
