using System;

namespace ThrowIf.Exceptions
{
    /// <summary>
    /// <see cref="IExceptionFactory"/> for ArgumentNullException.
    /// </summary>
    public sealed class ArgumentNullExceptionFactory : IExceptionFactory
    {
        public Exception CreateInstance(string message) =>
            new ArgumentNullException(string.Empty, message: message);
    }
}