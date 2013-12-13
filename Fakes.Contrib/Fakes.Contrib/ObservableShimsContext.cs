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
    public class ObservableShimsContext : IDisposable
    {
        private readonly IDisposable _innerContext;
        private bool _disposed;

        private ObservableShimsContext()
        {
            UnitTestIsolationRuntime.AtDetour += UnitTestIsolationRuntime_AtDetour;
            _innerContext = ShimsContext.Create();
        }

        public void AssertWasCalled<T>(Expression<FakesDelegates.Func<T>> expression, string message = null, params object[] parameters)
        {
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

        public void AssertWasCalled(MethodCallExpression expression, string message = null, params object[] parameters)
        {
            var wasCalled = _calls.Any(call => call.IsEquivalent(expression));

            if (!wasCalled)
            {
                AssertHelper.HandleFail(message: message, parameters: parameters);
            }
        }

        public void AssertWasCalled(MemberExpression expression, string message = null, params object[] parameters)
        {
            var wasCalled = _calls.Any(call => call.IsEquivalent(expression));

            if (!wasCalled)
            {
                AssertHelper.HandleFail(message: message, parameters: parameters);
            }
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

        protected void Dispose(bool disposing)
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

        private readonly List<MethodBase> _calls = new List<MethodBase>();

        private void UnitTestIsolationRuntime_AtDetour(object optionalReceiver, MethodBase method, Delegate detour)
        {
            _calls.Add(method);
        }
    }
}
