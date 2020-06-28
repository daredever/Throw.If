using System;

namespace ThrowIf.Exceptions
{
    /// <summary>
    /// <see cref="IExceptionFactory"/> for ArgumentException.
    /// </summary>
    public sealed class ArgumentExceptionFactory : IExceptionFactory
    {
        public Exception CreateInstance(string message) =>
            new ArgumentException(message: message);
    }
}