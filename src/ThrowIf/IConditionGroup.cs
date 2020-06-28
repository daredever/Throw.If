namespace ThrowIf
{
    /// <summary>
    /// Conditions group.
    /// </summary>
    public interface IConditionGroup<in T>
    {
        /// <summary>
        /// Verifies value by conditions with <see cref="ThrowContext"/>.
        /// </summary>
        /// <param name="context">Throw context</param>
        /// <param name="text">Value for verifying</param>
        void Verify(in ThrowContext context, T text);
    }
}