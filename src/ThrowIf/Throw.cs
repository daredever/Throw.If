using System;
using static ThrowIf.Exceptions;
using static ThrowIf.MessageTemplates;

namespace ThrowIf
{
    /// <summary>
    /// Represents methods that can be used to throw exception
    /// if values do not meet expected conditions.
    /// </summary>
    public static class Throw
    {
        /// <summary>
        /// Creates throw context with ArgumentNullException factory and defined message template. 
        /// </summary>
        /// <param name="messageTemplate">Message template</param>
        public static ThrowContext ArgumentNullException(
            Func<string, string>? messageTemplate = null)
        {
            return ThrowContext.Create(ArgumentNullExceptionFactory, messageTemplate ?? CanNotBeNull);
        }

        /// <summary>
        /// Creates throw context with ArgumentException factory and defined message template. 
        /// </summary>
        /// <param name="messageTemplate">Message template</param>
        public static ThrowContext ArgumentException(
            Func<string, string>? messageTemplate = null)
        {
            return ThrowContext.Create(ArgumentExceptionFactory, messageTemplate ?? IsNotValid);
        }

        /// <summary>
        /// Creates throw context with InvalidOperationException factory and defined message template. 
        /// </summary>
        /// <param name="messageTemplate">Message template</param>
        public static ThrowContext InvalidOperationException(
            Func<string, string>? messageTemplate = null)
        {
            return ThrowContext.Create(InvalidOperationExceptionFactory, messageTemplate ?? IsNotValid);
        }

        /// <summary>
        /// Creates throw context with defined exception factory and message template. 
        /// </summary>
        /// <param name="exceptionFactory">Exception factory</param>
        /// <param name="messageTemplate">Message template</param>
        public static ThrowContext Exception(
            Func<string, string, Exception> exceptionFactory,
            Func<string, string>? messageTemplate = null)
        {
            return ThrowContext.Create(exceptionFactory, messageTemplate ?? IsNotValid);
        }
    }
}