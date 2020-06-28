using System;
using ThrowIf;

namespace CustomException
{
    class Program
    {
        static void Main(string[] args)
        {
            Verify("msg", Guid.Empty);
        }

        private static void Verify(string? text, Guid? guid)
        {
            try
            {
                Throw<CustomExceptionFactory>
                    .If(condition: guid.IsNull(), name: nameof(guid), messageTemplate: MessageTemplates.CanNotBeNull)
                    .If(condition: text.IsNull(), name: nameof(text), messageTemplate: MessageTemplates.CanNotBeNull)
                    .If(condition: text.Length < 10, message: $"{nameof(text.Length)} is not valid");

                PrintMessage(text);
            }
            catch (Exception e)
            {
                Console.WriteLine("Test:");
                Console.WriteLine(e.Message);
                Console.WriteLine(e);
            }
        }

        private static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}