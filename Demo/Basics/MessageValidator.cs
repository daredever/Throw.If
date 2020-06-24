using ThrowIf;

namespace Basics
{
    public sealed class MessageValidator : IConditionGroup<string>
    {
        public static readonly MessageValidator Instance = new MessageValidator();

        private MessageValidator()
        {
        }

        public void Check(in ThrowContext throwContext, string value)
        {
            throwContext
                .If(value.Length < 100, $"{nameof(value.Length)} is not valid");
        }
    }
}