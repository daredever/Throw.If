using ThrowIf;

namespace Validator
{
    /// <summary>
    /// String value validation sample.
    /// </summary>
    public sealed class TextValidator : IConditionGroup<string>
    {
        public void Verify(in ThrowContext context, string text)
        {
            context
                .If(text.Length < 100, nameof(text.Length), name => $"{name} can not be less than 100")
                .If(text.StartsWith('A'), nameof(text), name => $"{name} can not start with char 'A'")
                .If(text.EndsWith('B'), nameof(text), name => $"{name} can not end with char 'B'");
        }
    }
}