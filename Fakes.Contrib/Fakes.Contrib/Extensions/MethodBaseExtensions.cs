using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Fakes.Contrib.Extensions
{
    public static class MethodBaseExtensions
    {
        public static bool IsEquivalent(this MethodBase method, MemberExpression expression)
        {
            if (method == null) throw new ArgumentNullException("method");

            var property = (PropertyInfo)expression.Member;
            var isEquivalent = property.GetMethod == method;

            return isEquivalent;
        }

        public static bool IsEquivalent(this MethodBase method, MethodCallExpression expression)
        {
            if (method == null) throw new ArgumentNullException("method");

            var isEquivalent = expression.Method == method;

            return isEquivalent;
        }
    }
}
