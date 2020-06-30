using System;
using ThrowIf;

namespace Basics
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Verify(text: "msg", guid: Guid.Empty);
        }

        private static void Verify(string? text, Guid? guid)
        {
            try
            {
                Throw.ArgumentNullException()
                    .If(guid.IsNull(), nameof(guid))
                    .If(text.IsNull(), nameof(text));

                Throw.ArgumentException(name => $"Invalid argument '{name}'")
                    .If(text.IsEmpty(), nameof(text), MessageTemplates.CanNotBeEmpty)
                    .If(text.Length > 1, nameof(text.Length))
                    .If(guid.IsEmpty(), nameof(guid));

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