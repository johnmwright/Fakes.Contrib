using System;
using System.Linq.Expressions;

namespace Fakes.Contrib.Extensions
{
    internal static class ExpressionExtensions
    {
        public static MethodCallExpression AsMethodCallExpression<T>(this Expression<T> expression)
        {
            if (expression == null) throw new ArgumentNullException("expression");

            return expression.Body as MethodCallExpression;
        }

        public static MemberExpression AsMemberExpression<T>(this Expression<T> expression)
        {
            if (expression == null) throw new ArgumentNullException("expression");

            return expression.Body as MemberExpression;
        }
    }
}
