using System;
using System.Diagnostics.CodeAnalysis;

namespace ThrowIf
{
    /// <summary>
    /// Represents methods that can be used to throw exception
    /// if values do not meet expected conditions.
    /// </summary>
    /// <typeparam name="TFactory">Inherits IExceptionFactory</typeparam>
    public static class Throw<TFactory> where TFactory : class, IExceptionFactory, new()
    {
        private static readonly IExceptionFactory ExceptionFactory = new TFactory();

        /// <summary>
        /// Throw if a condition is true.
        /// </summary>
        /// <param name="condition">The condition</param>
        /// <param name="message">The message used with the exception that is thrown if the condition is true</param>
        public static ThrowContext If([DoesNotReturnIf(true)] bool condition, string message)
        {
            return ThrowContext.Create(ExceptionFactory).If(condition, message);
        }

        /// <summary>
        /// Throw if a condition is true.
        /// </summary>
        /// <param name="condition">The condition</param>
        /// <param name="messageTemplate">The message template used with the exception that is thrown if the condition is true</param>
        public static ThrowContext If([DoesNotReturnIf(true)] bool condition, Func<string> messageTemplate)
        {
            return ThrowContext.Create(ExceptionFactory).If(condition, messageTemplate);
        }

        /// <summary>
        /// Throw if a condition is true.
        /// </summary>
        /// <param name="condition">The condition</param>
        /// <param name="name">Field name used with the message template</param>
        /// <param name="messageTemplate">The message template used with the exception that is thrown if the condition is true</param>
        public static ThrowContext If([DoesNotReturnIf(true)] bool condition, string name,
            Func<string, string> messageTemplate)
        {
            return ThrowContext.Create(ExceptionFactory).If(condition, name, messageTemplate);
        }

        /// <summary>
        /// Throw if any condition in condition group is true.
        /// </summary>
        /// <param name="conditionGroup">Conditions group</param>
        /// <param name="value">Value for verifying</param>
        public static ThrowContext If<T>(IConditionGroup<T> conditionGroup, T value)
        {
            return ThrowContext.Create(ExceptionFactory).If(conditionGroup, value);
        }
    }
}