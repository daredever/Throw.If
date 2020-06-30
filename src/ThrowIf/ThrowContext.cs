using System;

namespace ThrowIf
{
    /// <summary>
    /// Special struct for Throw.If fluent interface. Do not create instance.
    /// </summary>
    public readonly struct ThrowContext
    {
        internal static ThrowContext Create(
            Func<string, string, Exception> exceptionFactory,
            Func<string, string> messageTemplate)
        {
            return new ThrowContext(exceptionFactory, messageTemplate);
        }

        private ThrowContext(
            Func<string, string, Exception> exceptionFactory,
            Func<string, string> messageTemplate)
        {
            ExceptionFactory = exceptionFactory;
            MessageTemplate = messageTemplate;
        }

        internal Func<string, string, Exception> ExceptionFactory { get; }
        internal Func<string, string> MessageTemplate { get; }
    }
}