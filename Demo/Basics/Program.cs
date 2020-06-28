using System;
using ThrowIf;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Verify(text: "msg", guid: Guid.Empty);
        }

        private static void Verify(string? text, Guid? guid)
        {
            try
            {
                Throw.Exception(message => new ArgumentNullException(string.Empty, message))
                    .If(condition: guid.IsNull(), name: nameof(guid), messageTemplate: MessageTemplates.CanNotBeNull);

                Throw.Exception(ExceptionFactories.ArgumentNullException)
                    .If(condition: text.IsNull(), name: nameof(text), messageTemplate: MessageTemplates.CanNotBeNull);

                Throw.Exception<ValidationExceptionFactory>()
                    .If(condition: guid.IsEmpty(), name: nameof(guid), messageTemplate: MessageTemplates.CanNotBeEmpty)
                    .If(condition: text.StartsWith('A'), name: nameof(guid), messageTemplate: CanNotStartWithCharA);

                Throw.Exception(new ValidationExceptionFactory())
                    .If(condition: text.IsEmpty(), name: nameof(text), messageTemplate: MessageTemplates.CanNotBeEmpty)
                    .If(condition: text.Length > 10, message: $"{nameof(text.Length)} is not valid")
                    .If(condition: text.Length < 100, messageTemplate: () => $"{nameof(text.Length)} is not valid");

                PrintMessage(text);
            }
            catch (Exception e)
            {
                Console.WriteLine("Test:");
                Console.WriteLine(e.Message);
                Console.WriteLine(e);
            }
        }

        private static readonly Func<string, string> CanNotStartWithCharA =
            name => $"{name} can not start with char 'A'";

        private static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}