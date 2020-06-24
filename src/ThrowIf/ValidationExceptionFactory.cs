using System;
using System.ComponentModel.DataAnnotations;

namespace ThrowIf
{
    public sealed class ValidationExceptionFactory : IExceptionFactory
    {
        public Exception CreateInstance(string message)
        {
            return new ValidationException(message: message);
        }
    }
}