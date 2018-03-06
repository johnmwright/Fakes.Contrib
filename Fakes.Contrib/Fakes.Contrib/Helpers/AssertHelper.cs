using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.CompilerServices;

namespace Fakes.Contrib.Helpers
{
    internal static class AssertHelper
    {
        public static void HandleFail([CallerMemberName] string assertionName = null, string message = "", params object[] parameters)
        {
            var args = string.Format(message ?? "", parameters ?? new object[0]);
            var msg = $"{assertionName} failed. {args}";

            throw new AssertFailedException(msg);
        }
    }
}
