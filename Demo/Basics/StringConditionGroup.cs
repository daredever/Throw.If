using ThrowIf;

namespace Basics
{
    public sealed class StringConditionGroup : IConditionGroup<string>
    {
        public static readonly StringConditionGroup Instance = new StringConditionGroup();

        private StringConditionGroup()
        {
        }

        public void Check(in ThrowContext throwContext, string value)
        {
            throwContext
                .If(string.IsNullOrWhiteSpace(value), nameof(StringConditionGroup), name => $"{name} is not valid")
                .If(value.Length > 0, "Length is not valid");
        }
    }
}