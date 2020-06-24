using System;

namespace ThrowIf
{
    public sealed class ExceptionFactory : IExceptionFactory
    {
        public Exception CreateInstance(string message)
        {
            return new Exception(message: message);
        }
    }
}