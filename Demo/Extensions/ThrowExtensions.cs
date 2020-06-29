using ThrowIf;

namespace Extensions
{
    public static class ThrowExtensions
    {
        public static ref readonly ThrowContext IfNull<T>(this in ThrowContext context,
            T? value, string name) where T : class
        {
            return ref context.If(value.IsNull(), name, MessageTemplates.CanNotBeNull);
        }

        public static ref readonly ThrowContext IfEmpty(this in ThrowContext context,
            string value, string name)
        {
            return ref context.If(value.IsEmpty(), name, MessageTemplates.CanNotBeEmpty);
        }
    }
}