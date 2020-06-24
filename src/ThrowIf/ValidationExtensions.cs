using System;
using System.Diagnostics.CodeAnalysis;

namespace ThrowIf
{
    /// <summary>
    /// Common validation extensions.
    /// </summary>
    public static class ValidationExtensions
    {
        public static bool IsEmpty(this Guid value)
        {
            return value == Guid.Empty;
        }

        public static bool IsEmpty(this string value)
        {
            return value == string.Empty;
        }

        public static bool IsNull<T>([NotNullWhen(false)] this T? value) where T : struct
        {
            return value.HasValue != true;
        }

        public static bool IsNull<T>([NotNullWhen(false)] this T? value) where T : class
        {
            return value is null;
        }
    }
}