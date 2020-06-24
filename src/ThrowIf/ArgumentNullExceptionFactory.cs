using System;

namespace ThrowIf
{
    public sealed class ArgumentNullExceptionFactory : IExceptionFactory
    {
        public Exception CreateInstance(string message)
        {
            return new ArgumentNullException(string.Empty, message: message);
        }
    }
}