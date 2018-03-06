using Fakes.Contrib.Extensions;
using Fakes.Contrib.Helpers;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.QualityTools.Testing.Fakes.UnitTestIsolation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Fakes.Contrib
{
    public sealed class ObservableShimsContext : IDisposable
    {
        private readonly IDisposable _innerContext;
        private readonly List<MethodBase> _calls = new List<MethodBase>();
        private bool _disposed;

        private ObservableShimsContext()
        {
            UnitTestIsolationRuntime.AtDetour += UnitTestIsolationRuntime_AtDetour;
            _innerContext = ShimsContext.Create();
        }

        ~ObservableShimsContext()
        {
            Dispose(false);
        }

        public void AssertWasCalled<TResult>(Expression<FakesDelegates.Func<TResult>> expression, string message = null, params object[] parameters)
        {
            if (_disposed) throw new ObjectDisposedException("ObservableShimsContext");

            var memberExpression = expression.AsMemberExpression();
            if (memberExpression != null)
            {
                AssertWasCalled(memberExpression, message, parameters);
                return;
            }

            var methodCallExpression = expression.AsMethodCallExpression();
            if (methodCallExpression != null)
            {
                AssertWasCalled(methodCallExpression, message, parameters);
                return;
            }

            throw new ArgumentException("The expression is not a member expression nor a method call expression.");
        }

        public void AssertWasCalled<T1, TResult>(Expression<FakesDelegates.Func<T1, TResult>> expression, string message = null, params object[] parameters)
        {
            if (_disposed) throw new ObjectDisposedException("ObservableShimsContext");

            var methodCallExpression = expression.AsMethodCallExpression();

            if (methodCallExpression == null)
            {
                throw new ArgumentException("The expression is not a method call expression.");
            }

            AssertWasCalled(methodCallExpression, message, parameters);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public static ObservableShimsContext Create()
        {
            return new ObservableShimsContext();
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    UnitTestIsolationRuntime.AtDetour -= UnitTestIsolationRuntime_AtDetour;
                    _innerContext.Dispose();
                }

                _disposed = true;
            }
        }

        private void AssertWasCalled(MethodCallExpression expression, string message = null, params object[] parameters)
        {
            var wasCalled = _calls.Any(call => call.IsEquivalent(expression));
            if (!wasCalled)
            {
                AssertHelper.HandleFail(message: message, parameters: parameters);
            }
        }

        private void AssertWasCalled(MemberExpression expression, string message = null, params object[] parameters)
        {
            var wasCalled = _calls.Any(call => call.IsEquivalent(expression));
            if (!wasCalled)
            {
                AssertHelper.HandleFail(message: message, parameters: parameters);
            }
        }

        private void UnitTestIsolationRuntime_AtDetour(object optionalReceiver, MethodBase method, Delegate detour)
        {
            _calls.Add(method);
        }
    }
}
