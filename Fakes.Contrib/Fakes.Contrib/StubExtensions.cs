using Fakes.Contrib.Extensions;
using Fakes.Contrib.Helpers;
using Microsoft.QualityTools.Testing.Fakes.Stubs;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Fakes.Contrib
{
    public static class StubExtensions
    {
        [Obsolete("Use AsObservable() to set up the stub as observable.", true)]
        public static T WithObserver<T>(this T stub)
            where T : class, IStubObservable
        {
            return stub.AsObservable();
        }

        public static T AsObservable<T>(this T stub)
            where T : class, IStubObservable
        {
            if (stub == null) throw new ArgumentNullException(nameof(stub));

            if (stub.InstanceObserver != null && !(stub.InstanceObserver is StubObserver))
            {
                throw new InvalidOperationException("This stub's instance observer is already set to an incompatible type.");                
            }

            stub.InstanceObserver = new StubObserver();

            return stub;
        }

        public static void AssertWasCalled<T>(this IStub<T> stub, Expression<Action<T>> expression, string message = null, params object[] parameters)
            where T : class
        {
            if (stub == null) throw new ArgumentNullException(nameof(stub));

            if (!(stub.InstanceObserver is StubObserver observer))
            {
                throw new ArgumentException("You must add an instance of StubObserver to stub.InstanceObserver or use the extension method stub.AsObservable().");
            }

            var methodCallExpression = expression.AsMethodCallExpression();

            if (methodCallExpression == null)
            {
                throw new ArgumentException("The expression is not a method call expression.");
            }

            var calls = observer.GetCalls();
            var wasCalled = calls.Any(call => call.IsEquivalent(methodCallExpression));

            if (!wasCalled)
            {
                AssertHelper.HandleFail(message: message, parameters: parameters);
            }
        }

        public static void AssertWasNotCalled<T>(this IStub<T> stub, Expression<Action<T>> expression, string message = null, params object[] parameters)
            where T : class
        {
            if (stub == null) throw new ArgumentNullException(nameof(stub));

            if (!(stub.InstanceObserver is StubObserver observer))
            {
                throw new ArgumentException("You must add an instance of StubObserver to stub.InstanceObserver or use the extension method stub.AsObservable().");
            }

            var methodCallExpression = expression.AsMethodCallExpression();

            if (methodCallExpression == null)
            {
                throw new ArgumentException("The expression is not a method call expression.");
            }

            var wasCalled = observer.GetCalls().All(call => !call.IsEquivalent(methodCallExpression));

            if (!wasCalled)
            {
                AssertHelper.HandleFail(message: message, parameters: parameters);
            }
        }
    }
}
