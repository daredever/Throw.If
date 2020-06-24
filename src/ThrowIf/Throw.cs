using System;
using System.Diagnostics.CodeAnalysis;

namespace ThrowIf
{
    public static class Throw<TFactory> where TFactory : class, IExceptionFactory, new()
    {
        private static readonly IExceptionFactory ExceptionFactory = new TFactory();

        public static ThrowContext If([DoesNotReturnIf(true)] bool condition, string message)
        {
            return ThrowContext.Create(ExceptionFactory).If(condition, message);
        }

        public static ThrowContext If([DoesNotReturnIf(true)] bool condition, Func<string> messageTemplate)
        {
            return ThrowContext.Create(ExceptionFactory).If(condition, messageTemplate);
        }

        public static ThrowContext If([DoesNotReturnIf(true)] bool condition, string name,
            Func<string, string> messageTemplate)
        {
            return ThrowContext.Create(ExceptionFactory).If(condition, name, messageTemplate);
        }

        public static ThrowContext If<T>(IConditionGroup<T> conditionGroup, T value)
        {
            return ThrowContext.Create(ExceptionFactory).If(conditionGroup, value);
        }
    }
}