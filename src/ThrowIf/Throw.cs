using System;
using System.Diagnostics.CodeAnalysis;

namespace ThrowIf
{
    /// <summary>
    /// Represents methods that can be used to throw exception
    /// if values do not meet expected conditions.
    /// </summary>
    public static class Throw
    {
        /// <summary>
        /// Creates throw context with defined exception factory. 
        /// </summary>
        /// <param name="exceptionFactory">Exception factory</param>
        public static ThrowContext Exception(Func<string, Exception> exceptionFactory)
        {
            return ThrowContext.Create(exceptionFactory);
        }

        /// <summary>
        /// Creates throw context with defined exception factory. 
        /// </summary>
        /// <param name="exceptionFactory">Exception factory</param>
        public static ThrowContext Exception(IExceptionFactory exceptionFactory)
        {
            return ThrowContext.Create(exceptionFactory);
        }

        /// <summary>
        /// Creates throw context with exception factory from defined type. 
        /// </summary>
        /// <typeparam name="TFactory">Exception factory type (<see cref="IExceptionFactory"/>)</typeparam>
        public static ThrowContext Exception<TFactory>() where TFactory : class, IExceptionFactory, new()
        {
            return ThrowContext.Create<TFactory>();
        }

        /// <summary>
        /// Throw if a condition is true.
        /// </summary>
        /// <param name="context">Special struct for fluent interface</param>
        /// <param name="condition">The condition</param>
        /// <param name="message">The message used with the exception that is thrown if the condition is true</param>
        public static ref readonly ThrowContext If(in this ThrowContext context,
            [DoesNotReturnIf(true)] bool condition, string message)
        {
            if (condition)
            {
                var exception = context.ExceptionFactory(message);
                ThrowException(exception);
            }

            return ref context;
        }

        /// <summary>
        /// Throw if a condition is true.
        /// </summary>
        /// <param name="context">Special struct for fluent interface</param>
        /// <param name="condition">The condition</param>
        /// <param name="messageTemplate">The message template used with the exception that is thrown if the condition is true</param>
        public static ref readonly ThrowContext If(this in ThrowContext context,
            [DoesNotReturnIf(true)] bool condition, Func<string> messageTemplate)
        {
            if (condition)
            {
                var message = messageTemplate();
                var exception = context.ExceptionFactory(message);
                ThrowException(exception);
            }

            return ref context;
        }

        /// <summary>
        /// Throw if a condition is true.
        /// </summary>
        /// <param name="context">Special struct for fluent interface</param>
        /// <param name="condition">The condition</param>
        /// <param name="name">Field name used with the message template</param>
        /// <param name="messageTemplate">The message template used with the exception that is thrown if the condition is true</param>
        public static ref readonly ThrowContext If(this in ThrowContext context,
            [DoesNotReturnIf(true)] bool condition, string name, Func<string, string> messageTemplate)
        {
            if (condition)
            {
                var message = messageTemplate(name);
                var exception = context.ExceptionFactory(message);
                ThrowException(exception);
            }

            return ref context;
        }

        /// <summary>
        /// Throw if any condition in condition group is true.
        /// </summary>
        /// <param name="context">Special struct for fluent interface</param>
        /// <param name="conditionGroup">Conditions group</param>
        /// <param name="value">Value for verifying</param>
        public static ref readonly ThrowContext If<T>(this in ThrowContext context,
            IConditionGroup<T> conditionGroup, T value)
        {
            conditionGroup.Verify(context, value);
            return ref context;
        }

        [DoesNotReturn]
        private static void ThrowException(Exception exception)
        {
            throw exception;
        }
    }
}