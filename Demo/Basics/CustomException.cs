using System;
using ThrowIf;

namespace Basics
{
    public class CustomException : Exception, IExceptionFactory
    {
        public CustomException()
        {
        }

        public CustomException(string message) : base(message)
        {
        }

        public Exception CreateInstance(string message)
        {
            return new CustomException(message);
        }
    }
}