using Fakes.Contrib.Extensions;
using Fakes.Contrib.Helpers;
using Microsoft.QualityTools.Testing.Fakes.Stubs;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Fakes.Contrib
{
    public static class StubBaseExtensions
    {
        /// <summary>
        /// Returns the passed stub with its instance observer property initialized with a StubObserver.
        /// </summary>
        /// <typeparam name="T">A type that implements IStubObservable</typeparam>
        /// <param name="stub">The stub</param>
        /// <returns>The stub</returns>
        public static T WithObserver<T>(this T stub)
            where T : class, IStubObservable
        {
            if (stub == null) throw new ArgumentNullException("stub");

            if (stub.InstanceObserver != null)
            {
                if (!(stub.InstanceObserver is StubObserver))
                {
                    throw new InvalidOperationException("This stub's instance observer is already set to an incompatible type.");
                }
            }

            stub.InstanceObserver = new StubObserver();

            return stub;
        }

        /// <summary>
        /// Assert that a method has been called on the stub.
        /// </summary>
        /// <typeparam name="T">The type on which the assertion should be done</typeparam>
        /// <param name="stub">The stub on which the assertion should be done</param>
        /// <param name="expression">The expression that matches the method and its parameters</param>
        /// <param name="message">An optionnal assertion message</param>
        /// <param name="parameters">Optional parameters to the message format</param>
        public static void AssertWasCalled<T>(this StubBase<T> stub, Expression<Action<T>> expression, string message = null, params object[] parameters)
            where T : class
        {
            if (stub == null) throw new ArgumentNullException("stub");

            var observer = stub.InstanceObserver as StubObserver;

            if (observer == null)
            {
                throw new ArgumentException("You must add an instance of StubObserver to stub.InstanceObserver or use the extension method stub.WithObserver().");
            }

            var methodCallExpression = expression.AsMethodCallExpression();

            if (methodCallExpression == null)
            {
                throw new ArgumentException("The expression is not a method call expression.");
            }

            var wasCalled = observer.GetCalls().Any(call => call.IsEquivalent(methodCallExpression));

            if (!wasCalled)
            {
                AssertHelper.HandleFail(message: message, parameters: parameters);
            }
        }
    }
}
