using System;

namespace ThrowIf
{
    /// <summary>
    /// Special struct for Throw.If fluent interface. Do not create instance.
    /// </summary>
    public readonly struct ThrowContext
    {
        internal static ThrowContext Create(IExceptionFactory exceptionFactory)
        {
            return new ThrowContext(message => exceptionFactory.CreateInstance(message));
        }

        public static ThrowContext Create(Func<string, Exception> exceptionFactory)
        {
            return new ThrowContext(exceptionFactory);
        }

        private ThrowContext(Func<string, Exception> exceptionFactory)
        {
            ExceptionFactory = exceptionFactory;
        }

        internal Func<string, Exception> ExceptionFactory { get; }
    }
}