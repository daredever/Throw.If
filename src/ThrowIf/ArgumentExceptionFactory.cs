using System;

namespace ThrowIf
{
    public sealed class ArgumentExceptionFactory : IExceptionFactory
    {
        public Exception CreateInstance(string message)
        {
            return new ArgumentException(message: message);
        }
    }
}