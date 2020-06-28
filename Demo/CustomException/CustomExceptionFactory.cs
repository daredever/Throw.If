using System;
using ThrowIf;

namespace CustomException
{
    public sealed class CustomExceptionFactory : IExceptionFactory
    {
        public Exception CreateInstance(string message) => new CustomException(message);
    }
}