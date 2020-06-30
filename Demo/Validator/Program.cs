using System;
using ThrowIf;
using static ThrowIf.MessageTemplates;

namespace Validator
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
                Throw.ArgumentException()
                    .If(condition: text.IsNull(), name: nameof(text), messageTemplate: CanNotBeNull)
                    .If(conditionGroup: new TextValidator(), value: text);

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