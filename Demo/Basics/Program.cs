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
                Throw<ArgumentNullExceptionFactory>
                    .If(condition: guid.IsNull(), name: nameof(guid), messageTemplate: MessageTemplates.CanNotBeNull)
                    .If(condition: text.IsNull(), name: nameof(text), messageTemplate: MessageTemplates.CanNotBeNull);

                Throw<ValidationExceptionFactory>
                    .If(condition: guid.IsEmpty(), name: nameof(guid), messageTemplate: MessageTemplates.CanNotBeEmpty)
                    .If(condition: guid.Value.ToString().StartsWith("A"), name: nameof(guid), messageTemplate: CanNotStartsWithCharA)
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

        private static readonly Func<string, string> CanNotStartsWithCharA =
            name => $"{name} can not start with char 'A'";

        private static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}