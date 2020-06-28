using System;

namespace ThrowIf
{
    /// <summary>
    /// Exception factory.
    /// </summary>
    public interface IExceptionFactory
    {
        /// <summary>
        /// Creates instance of exception with defined message. 
        /// </summary>
        /// <param name="message">Error message</param>
        /// <returns>Exception</returns>
        Exception CreateInstance(string message);
    }
}