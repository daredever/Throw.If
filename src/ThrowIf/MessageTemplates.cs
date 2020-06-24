using System;

namespace ThrowIf
{
    public static class MessageTemplates
    {
        /// <summary>
        /// Template for message $"{name} can not be null".
        /// </summary>
        /// <returns>Message</returns>
        public static readonly Func<string, string> CanNotBeNull =
            name => $"{name} can not be null";

        /// <summary>
        /// Template for message $"{name} can not be empty".
        /// </summary>
        /// <returns>Message</returns>
        public static readonly Func<string, string> CanNotBeEmpty =
            name => $"{name} can not be empty";
    }
}