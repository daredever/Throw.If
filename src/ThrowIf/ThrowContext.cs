namespace ThrowIf
{
    public readonly struct ThrowContext
    {
        internal static ThrowContext Create(IExceptionFactory exceptionFactory)
        {
            return new ThrowContext(exceptionFactory);
        }

        private ThrowContext(IExceptionFactory exceptionFactory)
        {
            ExceptionFactory = exceptionFactory;
        }

        internal IExceptionFactory ExceptionFactory { get; }
    }
}