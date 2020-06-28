using System;

namespace CustomException
{
    public sealed class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
        }
    }
}