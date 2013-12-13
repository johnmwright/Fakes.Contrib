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

            var property = expression.Member as PropertyInfo;

            if (property == null)
            {
                throw new NotSupportedException("Expression that is not a PropertyInfo is not (yet) supported");
            }

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
