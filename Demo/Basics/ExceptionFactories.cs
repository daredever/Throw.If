using System;
using System.ComponentModel.DataAnnotations;

namespace Basics
{
    public static class ExceptionFactories
    {
        public static readonly Func<string, Exception> ArgumentException =
            message => new ArgumentException(message: message);

        public static readonly Func<string, Exception> ArgumentNullException =
            message => new ArgumentNullException(paramName: string.Empty, message: message);

        public static readonly Func<string, Exception> ValidationException =
            message => new ValidationException(message: message);
    }
}