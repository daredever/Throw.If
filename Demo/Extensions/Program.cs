using System;
using ThrowIf;

namespace Extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            Verify(text: "msg");
        }

        private static void Verify(string? text)
        {
            try
            {
                Throw.Exception<ArgumentExceptionFactory>()
                    .IfNull(value: text, name: nameof(text))
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