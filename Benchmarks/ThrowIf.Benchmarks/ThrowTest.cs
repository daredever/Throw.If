using System;

namespace ThrowIf.Benchmarks
{
    internal static class ThrowTest
    {
        public static void If(bool condition, string name)
        {
            if (condition)
            {
                throw new Exception(IsNotValid(name));
            }
        }

        public static void If(bool condition, Func<string> messageTemplate)
        {
            if (condition)
            {
                throw new Exception(messageTemplate());
            }
        }

        private static string IsNotValid(string name) => $"{name} is not valid";

        public static ArgumentExceptionContext ArgumentException(Func<string, string>? messageTemplate = null)
        {
            return ArgumentExceptionContext.Create(messageTemplate);
        }
        
        public static ref readonly ArgumentExceptionContext IfHardcode(in this ArgumentExceptionContext context,
            bool condition, string name)
        {
            if (condition)
            {
                var message = IsNotValid(name);
                ThrowArgumentException(name, message);
            }

            return ref context;
        }

        public static ref readonly ArgumentExceptionContext If(in this ArgumentExceptionContext context,
            bool condition, string name, Func<string, string>? messageTemplate = null)
        {
            if (condition)
            {
                var message = messageTemplate?.Invoke(name) ??
                              context.MessageTemplate?.Invoke(name) ??
                              IsNotValid(name);
                ThrowArgumentException(name, message);
            }

            return ref context;
        }

        private static string ThrowArgumentException(string name, string message) =>
            throw new ArgumentException(message, name);
    }
}