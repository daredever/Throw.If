using System;
using System.Diagnostics.CodeAnalysis;

namespace ThrowIf
{
    public static class ThrowContextExtensions
    {
        public static ref readonly ThrowContext If(in this ThrowContext context,
            [DoesNotReturnIf(true)] bool condition, string message)
        {
            if (condition)
            {
                var exception = context.ExceptionFactory.CreateInstance(message);
                ThrowException(exception);
            }

            return ref context;
        }

        public static ref readonly ThrowContext If(this in ThrowContext context,
            [DoesNotReturnIf(true)] bool condition, Func<string> messageTemplate)
        {
            if (condition)
            {
                var message = messageTemplate();
                var exception = context.ExceptionFactory.CreateInstance(message);
                ThrowException(exception);
            }

            return ref context;
        }

        public static ref readonly ThrowContext If(this in ThrowContext context,
            [DoesNotReturnIf(true)] bool condition, string name, Func<string, string> messageTemplate)
        {
            if (condition)
            {
                var message = messageTemplate(name);
                var exception = context.ExceptionFactory.CreateInstance(message);
                ThrowException(exception);
            }

            return ref context;
        }

        public static ref readonly ThrowContext If<T>(this in ThrowContext context,
            IConditionGroup<T> conditionGroup, T value)
        {
            conditionGroup.Check(context, value);
            return ref context;
        }

        [DoesNotReturn]
        private static void ThrowException(Exception exception)
        {
            throw exception;
        }
    }
}