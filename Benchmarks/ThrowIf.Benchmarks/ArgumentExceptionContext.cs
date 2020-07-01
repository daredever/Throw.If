using System;

namespace ThrowIf.Benchmarks
{
    /// <summary>
    /// Special struct for Throw.If fluent interface. Do not create instance.
    /// </summary>
    public readonly struct ArgumentExceptionContext
    {
        internal static ArgumentExceptionContext Create(Func<string, string>? messageTemplate = null)
        {
            return new ArgumentExceptionContext(messageTemplate);
        }

        private ArgumentExceptionContext(Func<string, string>? messageTemplate)
        {
            MessageTemplate = messageTemplate;
        }

        internal Func<string, string>? MessageTemplate { get; }
    }
}