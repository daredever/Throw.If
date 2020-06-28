using System;
using System.Diagnostics.CodeAnalysis;

namespace ThrowIf
{
    /// <summary>
    /// Common validation extensions.
    /// </summary>
    public static class ValidationExtensions
    {
        /// <summary>
        /// True if value is empty.
        /// </summary>
        public static bool IsEmpty(this Guid value)
        {
            return value == Guid.Empty;
        }

        /// <summary>
        /// True if value is empty.
        /// </summary>
        public static bool IsEmpty(this Guid? value)
        {
            return value == Guid.Empty;
        }

        /// <summary>
        /// True if value is empty.
        /// </summary>
        public static bool IsEmpty(this string value)
        {
            return value == string.Empty;
        }

        /// <summary>
        /// True if value is null.
        /// </summary>
        public static bool IsNull<T>([NotNullWhen(false)] this T? value) where T : struct
        {
            return value.HasValue != true;
        }


        /// <summary>
        /// True if value is null.
        /// </summary>
        public static bool IsNull<T>([NotNullWhen(false)] this T? value) where T : class
        {
            return value is null;
        }
    }
}