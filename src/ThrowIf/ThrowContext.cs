using System;

namespace ThrowIf
{
    /// <summary>
    /// Special struct for Throw.If fluent interface. Do not create instance.
    /// </summary>
    public readonly struct ThrowContext
    {
        public static ThrowContext Create(Func<string, Exception> exceptionFactory)
        {
            return new ThrowContext(exceptionFactory);
        }

        internal static ThrowContext Create(IExceptionFactory exceptionFactory)
        {
            return new ThrowContext(message => exceptionFactory.CreateInstance(message));
        }

        internal static ThrowContext Create<TFactory>() where TFactory : class, IExceptionFactory, new()
        {
            return new ThrowContext(message =>
            {
                var exceptionFactory = new TFactory();
                return exceptionFactory.CreateInstance(message);
            });
        }

        private ThrowContext(Func<string, Exception> exceptionFactory)
        {
            ExceptionFactory = exceptionFactory;
        }

        internal Func<string, Exception> ExceptionFactory { get; }
    }
}