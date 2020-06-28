using System;
using System.ComponentModel.DataAnnotations;

namespace ThrowIf
{
    /// <summary>
    /// <see cref="IExceptionFactory"/> for ValidationException.
    /// </summary>
    public sealed class ValidationExceptionFactory : IExceptionFactory
    {
        public Exception CreateInstance(string message) =>
            new ValidationException(message: message);
    }
}