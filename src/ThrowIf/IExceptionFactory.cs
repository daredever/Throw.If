using System;

namespace ThrowIf
{
    public interface IExceptionFactory
    {
        Exception CreateInstance(string message);
    }
}