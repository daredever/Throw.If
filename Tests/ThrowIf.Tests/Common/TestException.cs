using System;

namespace ThrowIf.Tests.Common
{
    internal class TestException : Exception
    {
        public TestException(string message) : base(message)
        {
        }

        public static Func<string, string, Exception> Factory = (name, msg) => new TestException(msg);
    }
}