namespace ThrowIf
{
    /// <summary>
    /// Generic condition group.
    /// </summary>
    public interface IConditionGroup<in T>
    {
        /// <summary>
        /// Checks value by conditions with Throw context.
        /// </summary>
        /// <param name="context">Throw context</param>
        /// <param name="value">Value for checking</param>
        void Check(in ThrowContext context, T value);
    }
}