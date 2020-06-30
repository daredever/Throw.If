using System;
using System.Diagnostics.CodeAnalysis;

namespace ThrowIf
{
    public static class ThrowContextExtensions
    {
        /// <summary>
        /// Throw if a condition is true.
        /// </summary>
        /// <param name="context">Special struct for fluent interface</param>
        /// <param name="condition">The condition</param>
        /// <param name="name">Field name used with the message template</param>
        public static ref readonly ThrowContext If(this in ThrowContext context,
            [DoesNotReturnIf(true)] bool condition, string name)
        {
            if (condition)
            {
                var message = context.MessageTemplate(name);
                var exception = context.ExceptionFactory(name, message);
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
                var exception = context.ExceptionFactory(name, message);
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