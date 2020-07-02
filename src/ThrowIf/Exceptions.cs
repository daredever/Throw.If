using System;

namespace ThrowIf
{
    internal static class Exceptions
    {
        internal static readonly Func<string, string, Exception> ArgumentExceptionFactory =
            (name, message) => new ArgumentException(message, name);

        internal static readonly Func<string, string, Exception> ArgumentNullExceptionFactory =
            (name, message) => new ArgumentNullException(name, message);

        internal static readonly Func<string, string, Exception> InvalidOperationExceptionFactory =
            (name, message) => new InvalidOperationException(message);
    }
}