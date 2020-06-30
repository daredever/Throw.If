using System;
using ThrowIf;
using static ThrowIf.MessageTemplates;

namespace CustomException
{
    class Program
    {
        static void Main(string[] args)
        {
            Verify("msg");
        }

        private static void Verify(string? text)
        {
            try
            {
                Throw.Exception((name, message) => new CustomException(message), name => $"Wrong parameter '{name}'")
                    .If(text.IsNull() || text.StartsWith('A'), nameof(text))
                    .If(text.Length < 100, nameof(text.Length), name => $"{name} is too small");

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