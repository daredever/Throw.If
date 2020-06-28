using System;

namespace ThrowIf.Exceptions
{
    /// <summary>
    /// <see cref="IExceptionFactory"/> for ArgumentOutOfRangeException.
    /// </summary>
    public class ArgumentOutOfRangeExceptionFactory : IExceptionFactory
    {
        public Exception CreateInstance(string message) =>
            new ArgumentOutOfRangeException(paramName: string.Empty, message: message);
    }
}