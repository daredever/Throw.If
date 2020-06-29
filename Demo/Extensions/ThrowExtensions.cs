using ThrowIf;

namespace Extensions
{
    public static class ThrowExtensions
    {
        public static ref readonly ThrowContext IfEmpty(this in ThrowContext context,
            string value, string name)
        {
            return ref context.If(value.IsEmpty(), name, MessageTemplates.CanNotBeEmpty);
        }
    }
}