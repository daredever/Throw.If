using System;
using ThrowIf;

namespace Extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            Verify(text: string.Empty);
        }

        private static void Verify(string? text)
        {
            try
            {
                Throw.ArgumentException()
                    .If(condition: text.IsNull(), name: nameof(text), messageTemplate: MessageTemplates.CanNotBeNull)
                    .IfEmpty(value: text, name: nameof(text));

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